using System.Text.Json.Serialization;

namespace Marvel.Application.Abstractions.Models;

public interface IMarvelApiResponse<T>
{
    public int Code { get; set; }
    public string? Status { get; set; }
    public IMarvelApiData<T> Data { get; set; }
}