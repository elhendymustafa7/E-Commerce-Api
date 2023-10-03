global using Microsoft.AspNetCore.Mvc;
global using E_Commerce_Api.DTO;

namespace E_Commerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        //private readonly IBaseRepository<Category> _baseRepository;
        //public CategoriesController(IBaseRepository<Category> baseRepository)
        //{
        //    _baseRepository = baseRepository;
        //}

        private readonly IUnitOfWork _unitOfWork;
        public CategoriesController(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllCategories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories() => Ok(await _unitOfWork.Categories.GetAsync());

        [HttpGet("GetCategory/{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);

            if (category == null) return NotFound();

            return category;
        }

        [HttpPost("AddCategory")]
        public async Task<ActionResult<Category>> AddCategory([FromBody] CategoryDto categoryDto)
        {
            var category = new Category { Name = categoryDto.Name, Description = categoryDto.Description };

            _unitOfWork.Categories.Add(category);

            await _unitOfWork.SaveAsync();

            return Ok(category);
        }

        [HttpPut("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryDto categoryDto)
        {
            var category = new Category { ID = id, Name = categoryDto.Name, Description = categoryDto.Description };
            _unitOfWork.Categories.Update(category);
            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(category);
        }

        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _unitOfWork.Categories.DeleteAsync(id);

            if (!category) return NotFound();

            await _unitOfWork.SaveAsync();

            return Ok(); 
        }

        private bool CategoryExists(int id)
        {
            var categories =  _unitOfWork.Categories.Get();
            return categories.Any(e => e.ID == id);
        }
    }

   
}
