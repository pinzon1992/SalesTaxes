public class ProductType
{
    public string Name { get; set; }

    public ICollection<string> AssociatedProductNames { get; set; }
}