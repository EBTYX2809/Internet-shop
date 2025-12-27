namespace Internet_shop.Infrastructure.Entities.CategoryEntities;

internal class SpecificationValueEntity
{
    public Guid Id { get; set; }
    public string Value { get; set; } = string.Empty;
    public Guid SpecificationId { get; set; }
    public SpecificationEntity Specification { get; set; } = new();
}