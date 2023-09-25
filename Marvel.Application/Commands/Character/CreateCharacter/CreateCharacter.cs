using Marvel.Domain.Repositories;
using MediatR;

namespace Marvel.Application.Commands.Character.CreateCharacter;

public record CreateCharacterCommand(string Name, string Description) : IRequest<CreateCharacterResponse>;

public record CreateCharacterResponse(int Id);

public class CreateCharacterCommandHandler : IRequestHandler<CreateCharacterCommand, CreateCharacterResponse>
{
    private readonly ICharacterRepository _characterRepository;

    public CreateCharacterCommandHandler(ICharacterRepository characterRepository)
    {
        _characterRepository = characterRepository;
    }

    public async Task<CreateCharacterResponse> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
    {
        var character = new Domain.Entities.Character
        {
            Name = request.Name,
            Description = request.Description,
        };

        await _characterRepository.AddCharacter(character);

        return new CreateCharacterResponse(character.Id);
    }
}