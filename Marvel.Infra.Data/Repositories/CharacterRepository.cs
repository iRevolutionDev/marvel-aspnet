using AutoMapper;
using AutoMapper.QueryableExtensions;
using Marvel.Domain.Entities;
using Marvel.Domain.Repositories;
using Marvel.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Marvel.Infra.Data.Repositories;

public class CharacterRepository : ICharacterRepository
{
    private readonly MarvelDbContext _context;
    private readonly IMapper _mapper;
    public CharacterRepository(MarvelDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<Character>?> GetCharacters()
    {
        return await _context.Characters
            .Include(c => c.Thumbnail)
            .ToListAsync();
    }

    public async Task<Character?> GetCharacter(int id)
    {
        return await _context.Characters
            .Include(c => c.Thumbnail)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddCharacter(Character character)
    {
        await _context.Characters.AddAsync(character);
        await _context.SaveChangesAsync();
    }

    public async Task AddCharacters(List<Character> characters)
    {
        await _context.Characters.AddRangeAsync(characters);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCharacter(Character character)
    {
        _context.Characters.Update(character);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCharacters(List<Character> characters)
    {
        _context.Characters.UpdateRange(characters);
        await _context.SaveChangesAsync();
    }
}