using Marvel.Domain.Entities;

namespace Marvel.Domain.Repositories;

public interface ICharacterRepository
{
    public Task<List<Character>?> GetCharacters();
    public Task<Character?> GetCharacter(int id);
    
    public Task AddCharacter(Character character);
    public Task AddCharacters(List<Character> characters);
    public Task UpdateCharacter(Character character);
    public Task UpdateCharacters(List<Character> characters);
}