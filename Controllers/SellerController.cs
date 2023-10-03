using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SellerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetSellers")]
        public async Task<ActionResult<IEnumerable<Seller>>> GetSellers() => Ok(await _unitOfWork.Sellers.GetAsync());

        [HttpGet("GetSeller/{id}")]
        public async Task<ActionResult<Seller>> GetSeller(int id)
        {
            var seller = await _unitOfWork.Sellers.GetByIdAsync(id);

            if (seller == null) return NotFound();

            return seller;
        }

        [HttpPost("AddSeller")]
        public async Task<ActionResult<Seller>> AddSeller([FromBody] SellerDto sellerDto)
        {
            var seller = new Seller
            {
                Name = sellerDto.Name,
                Description = sellerDto.Description
            };

            _unitOfWork.Sellers.Add(seller);

            await _unitOfWork.SaveAsync();

            return Ok(seller);
        }

        [HttpPut("UpdateSeller/{id}")]
        public async Task<IActionResult> UpdateSeller(int id, [FromBody] SellerDto sellerDto)
        {
            var seller = new Seller
            {
                ID = id,
                Name = sellerDto.Name,
                Description = sellerDto.Description
            };

            _unitOfWork.Sellers.Update(seller);

            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(seller);
        }

        [HttpDelete("DeleteSeller/{id}")]
        public async Task<IActionResult> DeleteSeller(int id)
        {
            var seller = await _unitOfWork.Sellers.DeleteAsync(id);

            if (!seller) return NotFound();

            await _unitOfWork.SaveAsync();

            return Ok();
        }

        private bool SellerExists(int id)
        {
            var sellers = _unitOfWork.Sellers.Get();
            return sellers.Any(e => e.ID == id);
        }
    }
}
