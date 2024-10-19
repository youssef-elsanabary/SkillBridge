using Backend.Models;
using Backend.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Backend.DTO;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtHelper _jwtHelper;
        public AuthController(AppDbContext context, JwtHelper jwtHelper)
        {
            _context = context;
            _jwtHelper = jwtHelper;
        }
    
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {       
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == dto.Email);
            if (existingUser != null)
                return BadRequest(" email already exists.");

            if (dto.Role != "Client" && dto.Role != "Freelancer")
                return BadRequest("Role should be 'Client' or 'Freelancer'.");

            var user = new User
            {
                Username = dto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Email = dto.Email,
                Role = dto.Role
            };
        
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { userId = user.Id });
        }
     
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {        
            var user = _context.Users.FirstOrDefault(u => u.Email == dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return Unauthorized("Invalid username or password.");
       
            var token = _jwtHelper.GenerateToken(user);
            return Ok(new { token, userId = user.Id });
        }
    }
}
