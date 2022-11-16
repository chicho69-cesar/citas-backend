using citas_backend.Data;
using citas_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace citas_backend.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase {
        private readonly citasContext _context;

        public PostsController(citasContext context) {
            _context = context;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Posts.ToListAsync());
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var searchedMessage = await _context.Posts 
                    .Where(d => d.Id == id)
                    .FirstOrDefaultAsync();

                if (searchedMessage is null)
                {
                    return NotFound();
                }

                return Ok(searchedMessage);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(AddAndUpdatePost model)
        {
            try
            {
                var post = new Post
                {
                    Description = model.Description,
                    Date = DateTime.Now,
                    Likes = model.Likes,
                    IdUser = model.IdUser
                };

                var addedMessage = await _context.Posts.AddAsync(post);
                await _context.SaveChangesAsync();

                return Created($"/api/messages/{addedMessage.Entity.Id}", addedMessage.Entity);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(AddAndUpdatePost model)
        {
            try
            {
                var searchedMessage = await _context.Posts
                    .FindAsync(model.Id);

                if (searchedMessage is null)
                {
                    return NotFound();
                }

                var modified = await _context.Posts
                    .Where(d => d.Id == searchedMessage.Id)
                    .FirstAsync();

                if (modified is null)
                {
                    return NotFound();
                }

                modified.Id = model.Id;
                modified.Date = DateTime.Now;
                modified.Likes = model.Likes;
                modified.IdUser = model.IdUser;


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
                var searchedToDelete = await _context.Posts
                    .Where(d => d.Id == id)
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
