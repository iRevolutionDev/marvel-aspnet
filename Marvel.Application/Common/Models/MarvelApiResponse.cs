using Marvel.Application.Abstractions.Models;

namespace Marvel.Application.Common.Models;

public class MarvelApiResponse<T> : IMarvelApiResponse<T>
{
    public int Code { get; set; }
    public string? Status { get; set; }
    public IMarvelApiData<T> Data { get; set; } = new MarvelApiData<T>();
}