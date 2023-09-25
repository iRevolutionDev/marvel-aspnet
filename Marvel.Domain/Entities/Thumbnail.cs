using Marvel.Domain.Common;

namespace Marvel.Domain.Entities;

public class Thumbnail : BaseAuditableEntity
{
    public string? Path { get; set; }
    public string? Extension { get; set; }
}