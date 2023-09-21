namespace Marvel.Web.Models;

public class Character
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public Thumbnail Thumbnail { get; set; } = new();
    public string Image { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}