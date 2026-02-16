using Linq_ASSIGMENT_1_.Models;

namespace Linq_ASSIGMENT_1_.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto MapToDto(Product product)
        {
            return new ProductDto(product.ProductName, product.Category, product.UnitPrice);
        }
    }
}
