using First.API.DAL;
using First.API.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace First.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == null || id<1) return BadRequest();
            Category category = await _context.Categories.FirstOrDefaultAsync( c => c.Id == id);
            if (category == null) return NotFound(); 
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, category);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id < 1) return BadRequest();
            Category category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) return NotFound();

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, string name)
        {
            if(id == null || id < 1) return BadRequest();
            Category category = await _context.Categories.FirstOrDefaultAsync(c=>c.Id == id);
            if (category == null) return NotFound();

            category.Name = name;
            await _context.SaveChangesAsync();

            return NoContent();
        }
      
    }
}
