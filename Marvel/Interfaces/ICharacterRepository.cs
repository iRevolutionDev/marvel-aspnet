using Marvel.Models;

namespace Marvel.Interfaces;

public interface ICharacterRepository
{
    public Task<List<Character>?> GetCharacters();
    public Task<Character> GetCharacter(int id);
}