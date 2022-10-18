using citas_backend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace citas_backend.Controllers {
    public class DateController : ControllerBase{

        private readonly citasContext _context;

        public CommentsController(citasContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _context.Date.ToListAsync());
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
                var searchedImage = await _context.Date
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();

                if (searchedImage is null)
                {
                    return NotFound();
                }

                return Ok(searchedImage);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(AddAndUpdateDate model)
        {
            try
            {
                var _date = new Date
                {
                    _Date = model._Date,
                    Place = model.Place,
                    Description = model.Description, 
                    Grade = model.Grade,
                    IdUserFirst = model.IdUserFirst, 
                    IdUserSecond = model.IdUserSecond
                };

                var added = await _context.Date.AddAsync(_date);
                await _context.SaveChangesAsync();
                return Created($"/api/Date/get/{ added.Entity.Id }", added);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(AddAndUpdateDate model)
        {
            try
            {
                var modified = await _context.Date
                    .Where(pi => pi.Id == model.Id)
                    .FirstAsync();

                if (modified is null)
                {
                    return NotFound();
                }

                modified._Date = model._Date;
                modified.Place = model.Place;
                modified.Description = model.Description;
                modified.Grade = model.Grade;
                modified.IdUserFirst = model.IdUserFirst;
                modified.IdUserSecond = model.IdUserSecond;
                modified.ImageUrl = model.ImageUrl;
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
                var searchedToDelete = await _context.Date
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
