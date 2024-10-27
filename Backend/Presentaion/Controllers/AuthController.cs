using Backend.Models;
using Backend.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Backend.DTO;
using AutoMapper;
using Backend.Repository;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtHelper _jwtHelper;
        private readonly IMapper _mapper;


        public AuthController(IUserRepository userRepository, JwtHelper jwtHelper, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtHelper = jwtHelper;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(dto.Email);
            if (existingUser != null)
                return BadRequest("Email already exists.");

            if (dto.Role != "Client" && dto.Role != "Freelancer")
                return BadRequest("Role should be 'Client' or 'Freelancer'.");

            var user = _mapper.Map<User>(dto);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            await _userRepository.AddUserAsync(user);
            await _userRepository.SaveAsync();

            return Ok(new { userId = user.Id });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _userRepository.GetUserByEmailAsync(dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return Unauthorized("Invalid username or password.");

            var token = _jwtHelper.GenerateToken(user);
            return Ok(new { token, userId = user.Id });
        }
    }
}