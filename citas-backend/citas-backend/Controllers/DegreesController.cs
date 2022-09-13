using citas_backend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace citas_backend.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DegreesController : ControllerBase {
        private readonly citasContext _context;

        public DegreesController(citasContext context) {
            _context = context;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll() {
            return Ok(await _context.Degrees.ToListAsync());
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get(int id) {
            try {
                var searchedDegree = await _context.Degrees
                    .Where(d => d.Id == id)
                    .FirstOrDefaultAsync();

                if (searchedDegree is null) {
                    return NotFound();
                }

                return Ok(searchedDegree);
            } catch (Exception) {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(Degree degree) {
            try {
                var addedDegree = await _context.Degrees.AddAsync(degree);
                await _context.SaveChangesAsync();
                return Created($"/api/degrees/{ addedDegree.Entity.Id }", addedDegree.Entity);
            } catch(Exception) {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(Degree degree) {
            try {
                var searchedDegree = await _context.Degrees
                    .FindAsync(degree.Id);

                if (searchedDegree is null) {
                    return NotFound();
                }

                var modified = await _context.Degrees
                    .Where(d => d.Id == searchedDegree.Id)
                    .FirstAsync();

                if (modified is null) {
                    return NotFound();
                }

                modified.Name = degree.Name;
                modified.Users = degree.Users;

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
                var searchedToDelete = await _context.Degrees
                    .Where(d => d.Id == id)
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