using citas_backend.Data;
using citas_backend.Models;
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
        public async Task<IActionResult> Add(AddAndUpdatePostImages model) {
            try {
                var postImage = new PostImage {
                    ImageUrl = model.ImageUrl,
                    IdPost = model.IdPost
                };

                var added = await _context.PostImages.AddAsync(postImage);
                await _context.SaveChangesAsync();

                return Created($"/api/postimages/get/{ added.Entity.Id }", added);
            } catch(Exception) {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(AddAndUpdatePostImages model) {
            try {
                var modified = await _context.PostImages
                    .Where(pi => pi.Id == model.Id)
                    .FirstAsync();

                if (modified is null) {
                    return NotFound();
                }

                modified.ImageUrl = model.ImageUrl;
                modified.IdPost = model.IdPost;

                _context.Entry(modified).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            } catch(Exception) {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id) {
            try {
                var searchedToDelete = await _context.PostImages
                    .Where(pi => pi.Id == id)
                    .FirstAsync();

                if (searchedToDelete is null) {
                    return NotFound();
                }

                _context.Remove(searchedToDelete);
                await _context.SaveChangesAsync();

                return Ok();
            } catch(Exception) {
                return BadRequest();
            }
        }
    }
}