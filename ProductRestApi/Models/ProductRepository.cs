using Microsoft.EntityFrameworkCore;
using ProductRestApi.Classes;

namespace ProductRestApi.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext appDbContext;
        
        public ProductRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Product> AddProduct(Product product)
        {

            var result = await appDbContext.Products.AddAsync(product);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteProductById(int productId)
        {
            var result = await appDbContext
                .Products.FirstOrDefaultAsync(p => p.ProductId == productId);

            if (result != null) 
            { 

                appDbContext.Products.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await appDbContext.Products.ToListAsync();
        }

        public async Task<Product> GetPriceDiscountProduct(int productId)
        {
            var result = await appDbContext.Products.FirstOrDefaultAsync(
                p => p.ProductId == productId);

            if (result != null) {
                result.ProductPrice *= 1 - result.ProductDiscount;
                return result;
            }
            return null;

        }

        public async Task<Product> GetProduct(int ProductId)
        {
            return await appDbContext.Products.
                            FirstOrDefaultAsync(e => e.ProductId == ProductId);
        }

        public async Task<IEnumerable<Product>> SearchProduct(int productId, ProductType? productType)
        {
            IQueryable<Product> query = appDbContext.Products;

            query = query.Where(e => e.ProductId == productId);

            if (productType != null)
            {
                query = query.Where(e => e.proType == productType);
            }
            return await query.ToListAsync();

        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var result = await appDbContext.Products.FirstOrDefaultAsync(
                p => p.ProductId == product.ProductId);

            if (result != null) {
                result.ProductName = product.ProductName;
                result.ProductDescription = product.ProductDescription;

                if (product.ProductPrice != 0 && product.ProductDiscount != 0)
                    (result.ProductPrice, result.ProductDiscount) = (product.ProductPrice, product.ProductDiscount);

                result.proType = product.proType;

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
