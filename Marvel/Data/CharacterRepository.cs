using Marvel.Interfaces;
using Marvel.Models;

namespace Marvel.Data;

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