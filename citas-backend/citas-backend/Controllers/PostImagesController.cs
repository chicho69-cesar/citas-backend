using citas_backend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace citas_backend.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PostImagesController : ControllerBase {
        private readonly citasContext _context;

        public PostImagesController(citasContext context) {
            _context = context;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll() {
            try {
                return Ok(await _context.PostImages.ToListAsync());
            } catch (Exception) {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get(int id) {
            try {
                var searchedImage = await _context.PostImages
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();

                if (searchedImage is null) {
                    return NotFound();
                }

                return Ok(searchedImage);
            } catch(Exception) {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(PostImage postImage) {
            try {
                var added = await _context.PostImages.AddAsync(postImage);
                await _context.SaveChangesAsync();
                return Created($"/api/PostImages/get/{ added.Entity.Id }", added);
            } catch(Exception) {
                return BadRequest();
            }
        }
    }
}