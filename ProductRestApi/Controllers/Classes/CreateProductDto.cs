using ProductRestApi.Classes;

public class CreateProductDto
{
    public string ProductName { get; set; } = default!;
    public string ProductDescription { get; set; } = default!;
    public float ProductPrice { get; set; }
    public float ProductDiscount { get; set; }
    public ProductType proType { get; set; }
}
