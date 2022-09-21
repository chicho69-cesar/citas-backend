using citas_backend.Data;
using citas_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace citas_backend.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase {
        private readonly citasContext _context;

        public MessagesController(citasContext context) {
            _context = context;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll() {
            return Ok(await _context.Messages.ToListAsync());
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get(int id) {
            try {
                var searchedMessage = await _context.Messages
                    .Where(d => d.IdMessage == id)
                    .FirstOrDefaultAsync();

                if (searchedMessage is null) {
                    return NotFound();
                }

                return Ok(searchedMessage);
            } catch (Exception) {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("get-conversation/")]
        public async Task<IActionResult> GetConversation(Conversation model) {
            try {
                var messages = await _context.Messages
                    .Where(m => m.IdUserSend == model.IdSend && m.IdUserRecieve == model.IdReceive)
                    .OrderByDescending(m => m.Date)
                    .Skip(model.NumberSkip * 40)
                    .Take(40)
                    .ToListAsync();

                return Ok(messages);
            } catch(Exception) {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(AddAndUpdateMessage model) {
            try {
                var message = new Message {
                    Message1 = model.Message1,
                    Date = DateTime.Now,
                    IdUserSend = model.IdUserSend,
                    IdUserRecieve = model.IdUserRecieve
                };

                var addedMessage = await _context.Messages.AddAsync(message);
                await _context.SaveChangesAsync();

                return Created($"/api/messages/{addedMessage.Entity.IdMessage}", addedMessage.Entity);
            } catch (Exception) {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(AddAndUpdateMessage model) {
            try {
                var searchedMessage = await _context.Messages
                    .FindAsync(model.IdMessage);

                if (searchedMessage is null) {
                    return NotFound();
                }

                var modified = await _context.Messages
                    .Where(d => d.IdMessage == searchedMessage.IdMessage)
                    .FirstAsync();

                if (modified is null) {
                    return NotFound();
                }

                modified.Message1 = model.Message1;
                modified.Date = DateTime.Now;

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
                var searchedToDelete = await _context.Messages
                    .Where(d => d.IdMessage == id)
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