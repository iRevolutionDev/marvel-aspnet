using AutoMapper;

namespace Marvel.Application.Queries.Character.GetCharacters;

public class CharacterDto
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public ThumbnailDto Thumbnail { get; init; } = new();

    private class CharacterDtoProfile : Profile
    {
        public CharacterDtoProfile()
        {
            CreateMap<Domain.Entities.Character, CharacterDto>();
        }
    }
}