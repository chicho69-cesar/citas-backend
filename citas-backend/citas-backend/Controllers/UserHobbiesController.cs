using citas_backend.Data;
using citas_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace citas_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserHobbiesController : ControllerBase
    {
        private readonly citasContext _context;

        public UserHobbiesController(citasContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.UserHobbies.ToListAsync());
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var searchedMessage = await _context.UserHobbies
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


        
    }   
}
