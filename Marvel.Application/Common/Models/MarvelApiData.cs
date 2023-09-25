using Marvel.Application.Abstractions.Models;

namespace Marvel.Application.Common.Models;

public class MarvelApiData<T> : IMarvelApiData<T>
{
    public int Offset { get; set; }
    public int Limit { get; set; }
    public int Total { get; set; }
    public int Count { get; set; }
    public List<T> Results { get; set; }
    
    public bool HasMore()
    {
        return Offset + Limit < Total;
    }
}