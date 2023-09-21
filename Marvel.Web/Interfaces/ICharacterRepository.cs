using Marvel.Web.Models;

namespace Marvel.Web.Interfaces;

public interface ICharacterRepository
{
    public Task<List<Character>?> GetCharacters();
    public Task<Character> GetCharacter(int id);
}