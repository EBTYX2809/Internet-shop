namespace Internet_shop.Domain.Models.Categorization;

public class CategoryInfo
{
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public CategoryInfo(string name)
    {
        Id = Guid.NewGuid();

        if (string.IsNullOrWhiteSpace(name) || name.Length > 20)
            throw new ArgumentException("Name can't be null or longer than 20 symbols.");

        Name = name;
    }

    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > 20)
            throw new ArgumentException("Name can't be null or longer than 20 symbols.");

        Name = name;
    }
}
