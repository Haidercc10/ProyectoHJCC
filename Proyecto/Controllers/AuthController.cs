using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.DTOs;
using Proyecto.Services;

namespace Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly JwtService _jwtService;

        public AuthController(DataContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        // Function to login user
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _context.Users
                .AsNoTracking()
                .Include(x => x.Role)
                .FirstOrDefaultAsync(u => u.Us_Id == dto.Us_Id);

            if (user == null)
            {
                return Unauthorized(new
                {
                    message = "Usuario no encontrado"
                });
            }

            if (user.Us_Password != dto.Us_Password)
            {
                return Unauthorized(new
                {
                    message = "Contraseña incorrecta"
                });
            }

            var token = _jwtService.GenerateToken(user);

            return Ok(new
            {
                token,
                Id = user.Us_Id,
                Name = user.Us_Name,
                Rol = user.Rol_Id,
                Email = user.Us_Email,
            });
        }
    }
}
