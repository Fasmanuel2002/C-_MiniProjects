using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ProductRestApi.Models;
using ProductRestApi.Classes;

namespace ProductRestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        // GET api/product/search?productId=5&productType=Electronics
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Product>>> SearchProduct(
            [FromQuery] int productId,
            [FromQuery] ProductType? productType)
        {
            try
            {
                var result = await productRepository.SearchProduct(productId, productType);
                if (!result.Any())
                    return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        // GET api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            try
            {
                var all = await productRepository.GetAllProducts();
                return Ok(all);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        // POST api/product
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            try
            {
                if (product == null)
                    return BadRequest();

                var createdProduct = await productRepository.AddProduct(product);
                // Ubica el nuevo recurso usando SearchProduct (query string)
                return CreatedAtAction(
                    nameof(GetProduct),
                    new { productId = createdProduct.ProductId },
                    createdProduct
                );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        // GET api/product/5/discount?productType=Electronics
        [HttpGet("discount/{id:int}")]
        public async Task<ActionResult<Product>> GetDiscountProduct(
            int id,
            [FromQuery] ProductType? productType)
        {
            try
            {
                var list = await productRepository.SearchProduct(id, productType);
                if (!list.Any())
                    return BadRequest();

                var discounted = await productRepository.GetPriceDiscountProduct(id);
                if (discounted == null)
                    return BadRequest();

                return Ok(discounted.ProductPrice);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        // DELETE api/product/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                var toDelete = await productRepository.GetProduct(id);
                if (toDelete == null)
                    return NotFound($"Product id={id} is not found");

                await productRepository.DeleteProductById(id);
                return Ok("Product is deleted");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var result = await productRepository.GetProduct(id);
                if (result == null)
                {
                    return NotFound();

                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }
    }
}
