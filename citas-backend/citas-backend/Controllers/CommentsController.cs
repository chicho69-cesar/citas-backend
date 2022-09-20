using citas_backend.Data;
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
    }
}