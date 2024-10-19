using Backend.DTO;
using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _userRepository.AddUser(user);
            _userRepository.Save();
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null) return NotFound();

            user.Username = updatedUser.Username;
            user.Email = updatedUser.Email;
            user.Role = updatedUser.Role;

            _userRepository.UpdateUser(user);
            _userRepository.Save();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null) return NotFound();

            _userRepository.DeleteUser(id);
            _userRepository.Save();
            return NoContent();
        }

        [HttpGet("{id}/profiles")]
        public IActionResult GetUserProfile(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null) return NotFound();

            var profileDto = new ProfileDto
            {
                UserId = user.Id,
                Image = user.Image,
                Description = user.Description,
                Bio = user.Bio,
                Skills = user.Skills,
                CvFile = user.CvFile
            };

            return Ok(profileDto);
        }

        [HttpPost("{id}/profiles")]
        public IActionResult CreateUserProfile(int id, [FromBody] ProfileDto profileDto)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null) return NotFound();

            user.Image = profileDto.Image;
            user.Description = profileDto.Description;
            user.Bio = profileDto.Bio;
            user.Skills = profileDto.Skills;
            user.CvFile = profileDto.CvFile;

            _userRepository.UpdateUser(user);
            _userRepository.Save();
            return CreatedAtAction(nameof(GetUserProfile), new { id = user.Id }, profileDto);
        }

        [HttpPut("{id}/profiles")]
        public IActionResult UpdateUserProfile(int id, [FromBody] ProfileDto profileDto)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null) return NotFound();

            user.Image = profileDto.Image;
            user.Description = profileDto.Description;
            user.Bio = profileDto.Bio;
            user.Skills = profileDto.Skills;
            user.CvFile = profileDto.CvFile;

            _userRepository.UpdateUser(user);
            _userRepository.Save();
            return Ok(profileDto);
        }

        [HttpDelete("{id}/profiles")]
        public IActionResult DeleteUserProfile(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null) return NotFound();

            user.Image = null;
            user.Description = null;
            user.Bio = null;
            user.Skills = null;
            user.CvFile = null;

            _userRepository.UpdateUser(user);
            _userRepository.Save();
            return NoContent();
        }
    }
}
