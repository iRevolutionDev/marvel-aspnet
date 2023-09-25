using AutoMapper;
using Marvel.Application.Services;
using Marvel.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace Marvel.Application.Queries.Character.GetCharacters;

[Authorize]
public record GetCharactersQuery : IRequest<CharactersViewModel>
{
    public int Id { get; init; }
}

public class GetCharactersQueryHandler : IRequestHandler<GetCharactersQuery, CharactersViewModel>
{
    private readonly CharacterService _characterService;
    private readonly ILogger<GetCharactersQueryHandler> _logger;

    public GetCharactersQueryHandler(CharacterService characterService, ILogger<GetCharactersQueryHandler> logger)
    {
        _characterService = characterService;
        _logger = logger;
    }

    public async Task<CharactersViewModel> Handle(GetCharactersQuery request, CancellationToken cancellationToken)
    {
        if (request.Id > 0)
        {
            var character = await _characterService.GetCharacterByIdAsync(request.Id);
            return new CharactersViewModel
            {
                Characters = new List<CharacterDto> { character }
            };
        }
        
        var characters = await _characterService.GetCharactersAsync();

        return new CharactersViewModel
        {
            Characters = characters
        };
    }
}