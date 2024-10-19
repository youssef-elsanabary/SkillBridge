using Backend.DTO;
using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _userRepository.AddUserAsync(user);
            await _userRepository.SaveAsync();
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User updatedUser)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return NotFound();

           
            _mapper.Map(updatedUser, user);

            await _userRepository.UpdateUserAsync(user);
            await _userRepository.SaveAsync();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            await _userRepository.DeleteUserAsync(id);
            await _userRepository.SaveAsync();
            return NoContent();
        }

        [HttpGet("{id}/profiles")]
        public async Task<IActionResult> GetUserProfile(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            var profileDto = _mapper.Map<ProfileDto>(user);
            return Ok(profileDto);
        }

        [HttpPost("{id}/profiles")]
        public async Task<IActionResult> CreateUserProfile(int id, [FromBody] ProfileDto profileDto)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return NotFound();

           
            _mapper.Map(profileDto, user);

            await _userRepository.UpdateUserAsync(user);
            await _userRepository.SaveAsync();
            return CreatedAtAction(nameof(GetUserProfile), new { id = user.Id }, profileDto);
        }

        [HttpPut("{id}/profiles")]
        public async Task<IActionResult> UpdateUserProfile(int id, [FromBody] ProfileDto profileDto)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            
            _mapper.Map(profileDto, user);

            await _userRepository.UpdateUserAsync(user);
            await _userRepository.SaveAsync();
            return Ok(profileDto);
        }

        [HttpDelete("{id}/profiles")]
        public async Task<IActionResult> DeleteUserProfile(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return NotFound();

           
            var profileDto = new ProfileDto
            {
                Image = null,
                Description = null,
                Bio = null,
                Skills = null,
                CvFile = null
            };

           
            _mapper.Map(profileDto, user);

            await _userRepository.UpdateUserAsync(user);
            await _userRepository.SaveAsync();
            return NoContent();
        }
    }
}
