using System.Collections.ObjectModel;
using Marvel.Domain.Common;

namespace Marvel.Domain.Entities;

public class Character : BaseAuditableEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime Modified { get; set; }
    public string? ResourceUri { get; set; }
    public string? Thumbnail { get; set; }
    public ComicList? Comics { get; set; }
    public StoriesList? Stories { get; set; }
}