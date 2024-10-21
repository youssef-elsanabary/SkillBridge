using Backend.DTO;
using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
            if (user == null) return NotFound("User not found.");


            user.Username = updatedUser.Username ?? user.Username;
            user.Email = updatedUser.Email ?? user.Email;
            user.PasswordHash = updatedUser.PasswordHash ?? user.PasswordHash;
            user.Role = updatedUser.Role ?? user.Role;
            user.Image = updatedUser.Image ?? user.Image;
            user.Description = updatedUser.Description ?? user.Description;
            user.Bio = updatedUser.Bio ?? user.Bio;
            user.Skills = updatedUser.Skills ?? user.Skills;
            user.CvFile = updatedUser.CvFile ?? user.CvFile;

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

            var profile = new ProfileDto
            {
                Image = user.Image,
                Description = user.Description,
                Bio = user.Bio,
                Skills = user.Skills,
                CvFile = user.CvFile
            };

            return Ok(profile);
        }

     
        [HttpPost("{id}/profiles")]
        public async Task<IActionResult> CreateOrUpdateUserProfile(int id, [FromBody] ProfileDto profileDto)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            user.Image = profileDto.Image?? user.Image;
            user.Description = profileDto.Description ?? user.Description;
            user.Bio = profileDto.Bio ?? user.Bio;
            user.Skills = profileDto.Skills ?? user.Skills;
            user.CvFile = profileDto.CvFile ?? user.CvFile;

            await _userRepository.UpdateUserAsync(user);
            await _userRepository.SaveAsync();

            return Ok(user);
        }

  
        [HttpDelete("{id}/profiles")]
        public async Task<IActionResult> DeleteUserProfile(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return NotFound();


            user.Image = null;
            user.Description = null;
            user.Bio = null;
            user.Skills = null;
            user.CvFile = null;

            await _userRepository.UpdateUserAsync(user);
            await _userRepository.SaveAsync();
            return NoContent();
        }
    }
}
