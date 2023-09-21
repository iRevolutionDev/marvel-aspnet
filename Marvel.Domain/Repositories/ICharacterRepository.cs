using Marvel.Domain.Entities;

namespace Marvel.Domain.Repositories;

public interface ICharacterRepository
{
    public Task<List<Character>?> GetCharacters();
    public Task<Character?> GetCharacter(int id);
}