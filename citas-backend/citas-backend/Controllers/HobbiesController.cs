using citas_backend.Data;
using citas_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace citas_backend.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class HobbiesController : ControllerBase {
        private readonly citasContext _context;

        public HobbiesController(citasContext context) {
            _context = context;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll() {
            return Ok(await _context.Hobbies.ToListAsync());
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get(int id) {
            try {
                var searchedHobbie = await _context.Hobbies
                    .Where(d => d.Id == id)
                    .FirstOrDefaultAsync();

                if (searchedHobbie is null) {
                    return NotFound();
                }

                return Ok(searchedHobbie);
            } catch (Exception) {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(AddAndUpdateHobby model) {
            try {
                var hobby = new Hobby {
                    Name = model.Name
                };

                var addedHobby = await _context.Hobbies.AddAsync(hobby);
                await _context.SaveChangesAsync();

                return Created($"/api/hobbies/{addedHobby.Entity.Id}", addedHobby.Entity);
            } catch (Exception) {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(AddAndUpdateHobby model) {
            try {
                var searchedHobby = await _context.Hobbies
                    .FindAsync(model.Id);

                if (searchedHobby is null) {
                    return NotFound();
                }

                var modified = await _context.Hobbies
                    .Where(d => d.Id == searchedHobby.Id)
                    .FirstAsync();

                if (modified is null) {
                    return NotFound();
                }

                modified.Name = model.Name;

                _context.Entry(modified).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            } catch (Exception) {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id) {
            try {
                var searchedToDelete = await _context.Hobbies
                    .Where(d => d.Id == id)
                    .FirstAsync();

                if (searchedToDelete is null) {
                    return NotFound();
                }

                _context.Remove(searchedToDelete);
                await _context.SaveChangesAsync();

                return Ok();
            } catch (Exception) {
                return BadRequest();
            }
        }
    }
}