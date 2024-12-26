using First.API.DTOs.Category;
using First.API.DTOs.Color;
using First.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace First.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _service;

        public ColorsController(IColorService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            return Ok(await _service.GetAllAsync(page, take));
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateColorDTO colorDTO)
        {
            if (!await _service.CreateAsync(colorDTO)) return BadRequest();

            return StatusCode(StatusCodes.Status201Created);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1) return BadRequest();

            var colorDTO = await _service.GetByIdAsync(id);

            if (colorDTO== null) return NotFound();
            return Ok(colorDTO);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateColorDTO colorDTO)
        {
            if (id < 1) return BadRequest();

            await _service.UpdateAsync(id, colorDTO);

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
