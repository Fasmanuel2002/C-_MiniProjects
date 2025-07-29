using ProductRestApi.Classes;

namespace ProductRestApi.Models
{
    public interface IProductRepository
    {

        Task<IEnumerable<Product>> SearchProduct(int productId, ProductType? productType);


        Task<IEnumerable<Product>> GetAllProducts();

        Task<Product> GetProduct(int ProductId);

        Task<Product> AddProduct(Product product);

        Task<Product> UpdateProduct(Product product);

        Task<Product> GetPriceDiscountProduct(int productId);
        Task DeleteProductById(int productId);
    }
}
