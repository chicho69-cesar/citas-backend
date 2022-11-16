using citas_backend.Data;
using citas_backend.Models;
using citas_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace citas_backend.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase {
        private readonly citasContext _context;

        public CommentsController(citasContext context) {
            _context = context;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll() {
            try {
                return Ok(await _context.Comments.ToListAsync());
            } catch (Exception) {
                return BadRequest();
            }
        }

        
        

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var searchedComment = await _context.Comments
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();

                if (searchedComment is null)
                {
                    return NotFound();
                }

                return Ok(searchedComment);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(AddAndUpdateComment model)
        {
            try
            {
                var comment = new Comment {
                    Comment1 = model.Comment1,
                    Date = model.Date,
                    IdUser = model.IdUser,
                    IdPost = model.IdPost
                };

                var added = await _context.Comments.AddAsync(comment);
                await _context.SaveChangesAsync();
                return Created($"/api/Comments/get/{ added.Entity.Id }", added);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(AddAndUpdateComment model)
        {
            try
            {
                var modified = await _context.Comments
                    .Where(pi => pi.Id == model.Id)
                    .FirstAsync();

                if (modified is null)
                {
                    return NotFound();
                }

                modified.Comment1 = model.Comment1;
                modified.Date = model.Date;
                modified.IdUser = model.IdUser;
                modified.IdPost = model.IdPost;

                _context.Entry(modified).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var searchedToDelete = await _context.Comments
                    .Where(pi => pi.Id == id)
                    .FirstAsync();

                if (searchedToDelete is null)
                {
                    return NotFound();
                }

                _context.Remove(searchedToDelete);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}