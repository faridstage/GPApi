using GP_Project.Data;
using GP_Project.Dtos;
using GP_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GP_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MarksController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var marks = await _context.marks.OrderBy(m=>m.Name).ToListAsync();
            return Ok(marks);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody]CreateMarkDto dto)
        {
            var mark1 = new Mark1
            {
                Name = dto.Name
            };
            await _context.marks.AddAsync(mark1);
            _context.SaveChanges();

            return Ok(mark1);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id,[FromBody] CreateMarkDto dto)
        {
            var mark = await _context.marks.FindAsync(id);
            if(mark == null)
            {
                return NotFound($"No mark with found with id : {id}");
            }

            mark.Name = dto.Name;
            _context.SaveChanges();
            return Ok(mark);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var mark = await _context.marks.FindAsync(id);
            if (mark == null)
            {
                return NotFound($"No mark with found with id : {id}");
            }

            _context.marks.Remove(mark);
            _context.SaveChanges();
            return Ok(mark);
        }
    }
}
