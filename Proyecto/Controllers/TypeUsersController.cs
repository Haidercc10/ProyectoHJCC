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
    public class TypeUsersController : ControllerBase
    {
        private readonly DataContext _context;

        public TypeUsersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TypeUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeUser>>> GetTypeUser()
        {
            return await _context.TypeUser.ToListAsync();
        }

        // GET: api/TypeUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeUser>> GetTypeUser(int id)
        {
            var typeUser = await _context.TypeUser.FindAsync(id);

            if (typeUser == null)
            {
                return NotFound();
            }

            return typeUser;
        }

        // PUT: api/TypeUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeUser(int id, TypeUser typeUser)
        {
            if (id != typeUser.TypeUser_Id)
            {
                return BadRequest();
            }

            _context.Entry(typeUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeUserExists(id))
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

        // POST: api/TypeUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeUser>> PostTypeUser(TypeUser typeUser)
        {
            _context.TypeUser.Add(typeUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeUser", new { id = typeUser.TypeUser_Id }, typeUser);
        }

        // DELETE: api/TypeUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeUser(int id)
        {
            var typeUser = await _context.TypeUser.FindAsync(id);
            if (typeUser == null)
            {
                return NotFound();
            }

            _context.TypeUser.Remove(typeUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeUserExists(int id)
        {
            return _context.TypeUser.Any(e => e.TypeUser_Id == id);
        }
    }
}
