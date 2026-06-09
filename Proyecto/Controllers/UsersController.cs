using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;
using Proyecto.Data;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly DataContext _context;
    public UsersController(DataContext context)
    {
        _context = context;
    }

    // GET: api/User
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUser()
    {
        return await _context.Users.ToListAsync();
    }

    // GET: api/User/5
    [HttpGet("{us_id}")]
    public async Task<ActionResult<User>> GetUser(long us_id)
    {
        var user = await _context.Users.FindAsync(us_id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    // PUT: api/User/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{us_id}")]
    public async Task<IActionResult> PutUser(long? us_id, User user)
    {
        if (us_id != user.Us_Id)
        {
            return BadRequest();
        }

        _context.Entry(user).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExists(us_id))
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

    // POST: api/User
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetUser", new { us_id = user.Us_Id }, user);
    }

    // DELETE: api/User/5
    [HttpDelete("{us_id}")]
    public async Task<IActionResult> DeleteUser(long? us_id)
    {
        var user = await _context.Users.FindAsync(us_id);
        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private int Example() 
    {
        int a = 10;
        int b = a;

        b = 20;

        Console.WriteLine(a);
        return a;
    }

    private bool UserExists(long? us_id)
    {
        return _context.Users.Any(e => e.Us_Id == us_id);
    }
}
