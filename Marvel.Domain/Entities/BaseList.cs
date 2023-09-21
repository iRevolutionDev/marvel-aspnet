using Marvel.Domain.Common;

namespace Marvel.Domain.Entities;

public class BaseList<T> : BaseAuditableEntity
{
    public int Available { get; set; }
    public int Returned { get; set; }
    public string? CollectionUri { get; set; }
    public List<T>? Items { get; set; }
}