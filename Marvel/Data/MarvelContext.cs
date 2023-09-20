using System.Globalization;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using Marvel.Models;
using Newtonsoft.Json;

namespace Marvel.Data;

public class MarvelContext
{
    private readonly IConfiguration _configuration;

    public MarvelContext(IConfiguration configuration)
    {
        Client.BaseAddress = new Uri("http://gateway.marvel.com/v1/public/");
        Client.DefaultRequestHeaders.Accept.Clear();
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
        _configuration = configuration;
    }
    
    public HttpClient Client { get; } = new();

    private string GetHash(string ts, string privateKey, string publicKey)
    {
        var hash = MD5.HashData(Encoding.UTF8.GetBytes($"{ts}{privateKey}{publicKey}"));
        return string.Concat(hash.Select(x => x.ToString("x2")));
    }
    
    private static long UnixTimeNow()
    {
        var timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
        return (long)timeSpan.TotalSeconds;
    }

    private string GetDefaultQuery()
    {
        var ts = UnixTimeNow().ToString(CultureInfo.InvariantCulture);
        var privateKey = _configuration.GetValue<string>("Marvel:PrivateKey");
        var publicKey = _configuration.GetValue<string>("Marvel:PublicKey");
        
        if (string.IsNullOrEmpty(privateKey) || string.IsNullOrEmpty(publicKey))
            throw new Exception("Missing Marvel API keys");
        
        var hash = GetHash(ts, privateKey, publicKey);
        
        return $"ts={ts}&apikey={publicKey}&hash={hash}";
    }
    
    public async Task<List<Character>?> GetCharactersAsync()
    {
        var response = await Client.GetAsync($"characters?{GetDefaultQuery()}");
        
        if (!response.IsSuccessStatusCode) throw new Exception("Characters not found");
        
        var json = await response.Content.ReadAsStringAsync();
        var characters = JsonConvert.DeserializeObject<MarvelResponse<Character>>(json);
        
        return characters?.Data.Results ?? throw new Exception("Characters not found");
    }

    public async Task<Character> GetCharacterAsync(int id)
    {
        var response = await Client.GetAsync($"characters/{id}?{GetDefaultQuery()}");
        if (!response.IsSuccessStatusCode) throw new Exception("Character not found");
        var json = await response.Content.ReadAsStringAsync();
        var characters = JsonConvert.DeserializeObject<MarvelResponse<Character>>(json);
        return characters?.Data.Results.FirstOrDefault() ?? throw new Exception("Character not found");
    }
}