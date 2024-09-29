using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private static List<User> _users = new List<User>();
        private readonly JwtHelper _jwtHelper;

        public AuthController(JwtHelper jwtHelper)
        {
            _jwtHelper = jwtHelper;
        }

        // Register a new user
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            var existingUser = _users.FirstOrDefault(u => u.Username == dto.Username);
            if (existingUser != null)
                return BadRequest("Username already exists.");

            var user = new User
            {
                Id = _users.Count + 1,
                Username = dto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Email = dto.Email,
                Role = dto.Role 
            };

            _users.Add(user);
            var token = _jwtHelper.GenerateToken(user);
            return Ok(new { token });
        }

        // Login with username and password
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = _users.FirstOrDefault(u => u.Username == dto.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return Unauthorized("Invalid username or password.");

            var token = _jwtHelper.GenerateToken(user);
            return Ok(new { token });
        }

        // prototype
        [HttpGet("client")]
        [Authorize(Roles = "Client")]
        public IActionResult ClientEndpoint()
        {
            return Ok();
        }

        // prototype
        [HttpGet("freelancer")]
        [Authorize(Roles = "Freelancer")]
        public IActionResult FreelancerEndpoint()
        {
            return Ok();
        }
    }

}
