using Marvel.Domain.Entities;
using Marvel.Domain.Repositories;

namespace Marvel.Infra.Data.Repositories;

public class CharacterRepository : ICharacterRepository
{
    public Task<List<Character>?> GetCharacters()
    {
        throw new NotImplementedException();
    }

    public Task<Character?> GetCharacter(int id)
    {
        throw new NotImplementedException();
    }
}