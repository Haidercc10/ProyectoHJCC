using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Status_TypeController : ControllerBase
    {
        private readonly DataContext _context;

        public Status_TypeController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Status_Type
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status_Type>>> GetStatus_Types()
        {
            return await _context.Status_Types.ToListAsync();
        }

        // GET: api/Status_Type/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Status_Type>> GetStatus_Type(int id)
        {
            var status_Type = await _context.Status_Types.FindAsync(id);

            if (status_Type == null)
            {
                return NotFound();
            }

            return status_Type;
        }

        // PUT: api/Status_Type/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatus_Type(int id, Status_Type status_Type)
        {
            if (id != status_Type.Staty_Id)
            {
                return BadRequest();
            }

            _context.Entry(status_Type).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Status_TypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Status_Type
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Status_Type>> PostStatus_Type(Status_Type status_Type)
        {
            _context.Status_Types.Add(status_Type);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatus_Type", new { id = status_Type.Staty_Id }, status_Type);
        }

        // DELETE: api/Status_Type/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus_Type(int id)
        {
            var status_Type = await _context.Status_Types.FindAsync(id);
            if (status_Type == null)
            {
                return NotFound();
            }

            _context.Status_Types.Remove(status_Type);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Status_TypeExists(int id)
        {
            return _context.Status_Types.Any(e => e.Staty_Id == id);
        }
    }
}
