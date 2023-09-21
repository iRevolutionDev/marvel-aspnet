using Marvel.Web.Interfaces;
using Marvel.Web.Models;

namespace Marvel.Web.Data;

public class CharacterRepository : ICharacterRepository
{
    private readonly MarvelContext _context;
    
    public CharacterRepository(MarvelContext context)
    {
        _context = context;
    }
    
    public async Task<List<Character>?> GetCharacters()
    {
        return await _context.GetCharactersAsync();
    }

    public Task<Character> GetCharacter(int id)
    {
        return _context.GetCharacterAsync(id);
    }
}