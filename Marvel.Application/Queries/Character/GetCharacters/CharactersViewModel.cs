namespace Marvel.Application.Queries.Character.GetCharacters;

public class CharactersViewModel
{
    public IReadOnlyCollection<CharacterDto> Characters { get; init; } = new List<CharacterDto>();
}