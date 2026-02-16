namespace Linq_ASSIGMENT_1_.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

        public ProductDto ToDto()
        {
            return new ProductDto(ProductName, Category, UnitPrice);
        }
    }

    public record ProductDto(string Name, string Category, decimal Price);
    
    public record ProductSummary(string ProductName, string Category, decimal Price);
}
