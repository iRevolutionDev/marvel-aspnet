using Marvel.Application.Abstractions.Models;
using Marvel.Domain.Entities;

namespace Marvel.Application.Abstractions.Interfaces;

public interface IMarvelApiService
{ 
    Task<IMarvelApiResponse<Character>?> GetCharactersAsync(int offset, int limit);
    
    Task IngestCharactersAsync();
}