using Marvel.Domain.Common;

namespace Marvel.Domain.Entities;

public class ComicSummary : BaseAuditableEntity
{
    public string? ResourceUri { get; set; }
    public string? Name { get; set; }
}