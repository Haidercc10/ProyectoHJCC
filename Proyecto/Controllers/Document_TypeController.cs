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
    public class Document_TypeController : ControllerBase
    {
        private readonly DataContext _context;

        public Document_TypeController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Document_Type
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document_Type>>> GetDocuments_Types()
        {
            return await _context.Documents_Types.ToListAsync();
        }

        // GET: api/Document_Type/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Document_Type>> GetDocument_Type(string id)
        {
            var document_Type = await _context.Documents_Types.FindAsync(id);

            if (document_Type == null)
            {
                return NotFound();
            }

            return document_Type;
        }

        // PUT: api/Document_Type/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocument_Type(string id, Document_Type document_Type)
        {
            if (id != document_Type.DocType_Id)
            {
                return BadRequest();
            }

            _context.Entry(document_Type).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Document_TypeExists(id))
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

        // POST: api/Document_Type
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Document_Type>> PostDocument_Type(Document_Type document_Type)
        {
            _context.Documents_Types.Add(document_Type);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Document_TypeExists(document_Type.DocType_Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDocument_Type", new { id = document_Type.DocType_Id }, document_Type);
        }

        // DELETE: api/Document_Type/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument_Type(string id)
        {
            var document_Type = await _context.Documents_Types.FindAsync(id);
            if (document_Type == null)
            {
                return NotFound();
            }

            _context.Documents_Types.Remove(document_Type);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Document_TypeExists(string id)
        {
            return _context.Documents_Types.Any(e => e.DocType_Id == id);
        }
    }
}
