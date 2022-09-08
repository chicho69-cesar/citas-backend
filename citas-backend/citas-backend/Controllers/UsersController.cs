using citas_backend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace citas_backend.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {
        private readonly citasContext _context;

        public UsersController(citasContext context) {
            _context = context;
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> Get() {
            return Ok(await _context.Degrees.ToListAsync());
        }
    }
}