using First.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace First.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _repository;

        public CategoriesController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page=1, int take=3)
        {
            //var categories = await _repository.GetAll(includes:"Products").ToListAsync();
            var categories = await _repository.GetAll(skip:(page-1)*take,take:take).ToListAsync();
            return Ok(categories);
        }



        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id<1) return BadRequest();

            Category category = await _repository.GetByIdAsync(id);

            if (category == null) return NotFound(); 
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCategoryDTO categoryDTO)
        {

            await _repository.AddAsync(new Category
            {
                Name = categoryDTO.Name
            });
            await _repository.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return BadRequest();
            Category category = await _repository.GetByIdAsync(id);
               

            if (category == null) return NotFound();

            _repository.Delete(category);
            await _repository.SaveChangesAsync();
            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, string name)
        {
            if(id < 1) return BadRequest();
            Category category = await _repository.GetByIdAsync(id);
            if (category == null) return NotFound();

            category.Name = name;
            await _repository.SaveChangesAsync();

            return NoContent();
        }
      
    }
}
