using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Marvel.Application.Abstractions.Interfaces;
using Marvel.Application.Abstractions.Models;
using Marvel.Application.Common.Models;
using Marvel.Domain.Entities;
using Marvel.Domain.Repositories;
using Marvel.Infra.Data.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Marvel.Application.Services;

public class MarvelApiService : IMarvelApiService
{
    private readonly ILogger<MarvelApiService> _logger;
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ICharacterRepository _characterRepository;
    
    public MarvelApiService(
            ILogger<MarvelApiService> logger,
            HttpClient httpClient,
            IConfiguration configuration,
            ICharacterRepository characterRepository
        ) 
    {
        _httpClient = httpClient;
        _logger = logger;
        _characterRepository = characterRepository;
        _configuration = configuration;
    }
    
    private static long UnixTimeNow()
    {
        var timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
        return (long)timeSpan.TotalSeconds;
    }

    private string GetHash()
    {
        var ts = UnixTimeNow();
        var privateKey = _configuration.GetValue<string>("Marvel:PrivateKey");
        var publicKey = _configuration.GetValue<string>("Marvel:PublicKey");
        
        var hash = MD5.HashData(Encoding.UTF8.GetBytes($"{ts}{privateKey}{publicKey}"));
        return string.Concat(hash.Select(x => x.ToString("x2")));
    }
    
    private string DefaultQuery => $"ts={UnixTimeNow()}&apikey={_configuration.GetValue<string>("Marvel:PublicKey")}&hash={GetHash()}";
    
    public async Task<IMarvelApiResponse<Character>?> GetCharactersAsync(int offset, int limit)
    {
        var response = await _httpClient.GetAsync($"characters?offset={offset}&limit={limit}&{DefaultQuery}");
        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("Error getting characters from Marvel API: {StatusCode}", response.StatusCode);
            return null;
        }
        
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<MarvelApiResponse<Character>>(content);
    }

    public async Task IngestCharactersAsync()
    {
        const int offset = 0;
        const int limit = 100;
        
        var charactersResponse = await GetCharactersAsync(offset, limit);
        
        _logger.LogInformation("Ingesting characters from Marvel API");
        
        if (charactersResponse == null || charactersResponse.Data.Results.Count == 0)
        {
            _logger.LogError("Error getting characters from Marvel API");
            return;
        }
        
        var characters = charactersResponse.Data.Results;
        
        var charactersInDb = await _characterRepository.GetCharacters();
        if (charactersInDb != null && charactersInDb.Count == characters.Count)
        {
            _logger.LogInformation("No new characters to ingest");
            return;
        }
        
        await _characterRepository.AddCharacters(characters);
    }
}