namespace Marvel.Web.Models;

public class MarvelResponse<T>
{
    public int Code { get; set; }
    public string Status { get; set; } = string.Empty;
    public Data<T> Data { get; set; } = new();

    public override string ToString()
    {
        return $"Code: {Code}, Status: {Status}, Data: {Data}";
    }
}

public class Data<T>
{
    public int Offset { get; set; }
    public int Limit { get; set; }
    public int Total { get; set; }
    public int Count { get; set; }
    public List<T> Results { get; set; } = new();
    
    public bool HasMore()
    {
        return Offset + Limit < Total;
    }

    public override string ToString()
    {
        return $"Offset: {Offset}, Limit: {Limit}, Total: {Total}, Count: {Count}, Results: {Results}";
    }
}