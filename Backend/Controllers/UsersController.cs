using Backend.Context;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            user.Username = updatedUser.Username;
            user.Email = updatedUser.Email;
            user.Role = updatedUser.Role;

            _context.Users.Update(user);
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("profile/{id}")]
        public IActionResult GetUserProfile(int id)
        {
            var user = _context.Users.Find(id);
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

        [HttpPost("profile/{id}")]
        public IActionResult CreateUserProfile(int id, [FromBody] ProfileDto profileDto)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            user.Image = profileDto.Image;
            user.Description = profileDto.Description;
            user.Bio = profileDto.Bio;
            user.Skills = profileDto.Skills;
            user.CvFile = profileDto.CvFile;

            _context.Users.Update(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUserProfile), new { id = user.Id }, profileDto);
        }

        [HttpPut("profile/{id}")]
        public IActionResult UpdateUserProfile(int id, [FromBody] ProfileDto profileDto)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            user.Image = profileDto.Image;
            user.Description = profileDto.Description;
            user.Bio = profileDto.Bio;
            user.Skills = profileDto.Skills;
            user.CvFile = profileDto.CvFile;

            _context.Users.Update(user);
            _context.SaveChanges();
            return Ok(profileDto);
        }

        [HttpDelete("profile/{id}")]
        public IActionResult DeleteUserProfile(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            user.Image = null;
            user.Description = null;
            user.Bio = null;
            user.Skills = null;
            user.CvFile = null;

            _context.Users.Update(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
