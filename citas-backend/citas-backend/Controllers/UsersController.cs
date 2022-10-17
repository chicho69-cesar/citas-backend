using citas_backend.Data;
using citas_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace citas_backend.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {
        private readonly citasContext _context;

        public UsersController(citasContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _context.Users.ToListAsync());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var searchedUser = await _context.Users
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();

                if (searchedUser is null)
                {
                    return NotFound();
                }

                return Ok(searchedUser);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(AddAndUpdateUser model)
        {
            try
            {
                var user = new User {
                    Name = model.Name,
                    LastName = model.LastName,
                    Token = model.Token,
                    Email = model.Email,
                    NormalizedEmail = model.NormalizedEmail,
                    UserName = model.UserName,
                    NormalizedUserName = model.NormalizedUserName,
                    Password = model.Password,
                    BirthDate = model.BirthDate,
                    Description = model.Description,
                    Genre = model.Genre,
                    ImageProfile = model.ImageProfile,
                    IdDegree = model.IdDegree
                };

                var added = await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return Created($"/api/Users/get/{ added.Entity.Id }", added);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(AddAndUpdateUser model)
        {
            try
            {
                var modified = await _context.Users
                    .Where(pi => pi.Id == model.Id)
                    .FirstAsync();

                if (modified is null)
                {
                    return NotFound();
                }

                modified.Name = model.Name;
                modified.LastName = model.LastName;
                modified.Token = model.Token;
                modified.Email = model.Email;
                modified.NormalizedEmail = model.NormalizedEmail;
                modified.UserName = model.UserName;
                modified.NormalizedUserName = model.NormalizedUserName;
                modified.Password = model.Password;
                modified.BirthDate = model.BirthDate;
                modified.Description = model.Description;
                modified.Genre = model.Genre;
                modified.ImageProfile = model.ImageProfile;
                modified.IdDegree = model.IdDegree;

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
                var searchedToDelete = await _context.Users
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