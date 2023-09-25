using AutoMapper;
using Marvel.Application.Queries.Character.GetCharacters;
using Marvel.Domain.Entities;
using Marvel.Domain.Repositories;

namespace Marvel.Application.Services;

public class CharacterService
{
    private readonly ICharacterRepository _characterRepository;
    private readonly IMapper _mapper;

    public CharacterService(ICharacterRepository characterRepository, IMapper mapper)
    {
        _characterRepository = characterRepository;
        _mapper = mapper;
    }

    public async Task<List<CharacterDto>> GetCharactersAsync()
    {
        var characters = await _characterRepository.GetCharacters();
        return _mapper.Map<List<CharacterDto>>(characters);
    }

    public async Task<CharacterDto> GetCharacterByIdAsync(int id)
    {
        var character = await _characterRepository.GetCharacter(id);
        return _mapper.Map<CharacterDto>(character);
    }
}