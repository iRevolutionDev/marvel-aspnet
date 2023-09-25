using AutoMapper;
using Marvel.Domain.Entities;

namespace Marvel.Application.Queries.Character.GetCharacters;

public class ThumbnailDto
{
    public string? Path { get; init; }
    public string? Extension { get; init; }
    
    public string Url => $"{Path}.{Extension}";

    private class ThumbnailDtoProfile : Profile
    {
        public ThumbnailDtoProfile()
        {
            CreateMap<Thumbnail, ThumbnailDto>();
        }
    }
}