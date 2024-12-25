using First.API.DTOs.Category;
using First.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace First.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page=1, int take=3)
        {           
            return Ok(await _service.GetAllAsync(page, take));
        }



        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id<1) return BadRequest();

            var getCategoryDTO = await _service.GetByIdAsync(id);

            if (getCategoryDTO == null) return NotFound(); 
            return Ok(getCategoryDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCategoryDTO categoryDTO)
        {
            if(!await _service.CreateAsync(categoryDTO)) return BadRequest();
       
            return StatusCode(StatusCodes.Status201Created);

        }

     

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm]UpdateCategroryDTO categroryDTO)
        {
            if(id < 1) return BadRequest();
            
            await _service.UpdateAsync(id, categroryDTO);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return BadRequest();
            
            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}
