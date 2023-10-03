
using E_Commerce_Api.Service;

namespace E_Commerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts() => Ok(await _unitOfWork.Products.GetAsync());

        [HttpGet("GetProduct/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null) return NotFound();

            return product;
        }

        [HttpPost("AddProduct")]
        public async Task<ActionResult<Product>> AddProduct([FromBody] ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                //Price = productDto.IsDiscountActive != false ? ProductServices.PriceAfterDiscount(productDto.Price, productDto.DiscountPercent ?? 0 ) : productDto.Price,
                StockQuantity = productDto.StockQuantity,
                DiscountDescription = productDto.IsDiscountActive != false ? productDto.DiscountDescription : null,
                DiscountPercent = productDto.IsDiscountActive != false ? productDto.DiscountPercent : null,
                IsDiscountActive = productDto.IsDiscountActive,
                CategoryId = productDto.CategoryId,
                SellerID = productDto.SellerID
            };

            _unitOfWork.Products.Add(product);

            await _unitOfWork.SaveAsync();

            return Ok(product);
        }

        [HttpPut("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            var product = new Product 
            {
                ID = id,
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                StockQuantity = productDto.StockQuantity,
                DiscountDescription = productDto.IsDiscountActive != false ? productDto.DiscountDescription : null,
                DiscountPercent = productDto.IsDiscountActive != false ? productDto.DiscountPercent : null,
                IsDiscountActive = productDto.IsDiscountActive,
                CategoryId = productDto.CategoryId,
                SellerID = productDto.SellerID
            };

            _unitOfWork.Products.Update(product);

            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(product);
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _unitOfWork.Products.DeleteAsync(id);

            if (!product) return NotFound();

            await _unitOfWork.SaveAsync();

            return Ok();
        }

        private bool ProductExists(int id)
        {
            var products = _unitOfWork.Products.Get();
            return products.Any(e => e.ID == id);
        }

        
    }
}
