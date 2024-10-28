using AutoMapper;
using Backend.DTO;
using Backend.Models;
using Backend.Repository;
using Backend.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;  
        private readonly CloudinaryService _cloudinaryService; 

        public UsersController(IUserRepository userRepository, IMapper mapper, CloudinaryService cloudinaryService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
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

            var profileDto = _mapper.Map<ProfileDto>(user);


            return Ok(profileDto);
        }


        [HttpPost("{id}/profiles")]
        public async Task<IActionResult> CreateUserProfile(int id, [FromForm] ProfileDto profileDto, IFormFile imageFile = null)
        {

            var user = await _userRepository.GetUserByIdAsync(id);
            if (user != null)
            {
                return BadRequest("User already exists. Use PUT to update the profile.");
            }


            var newUser = new User
            {
                Id = id,
                Description = profileDto.Description,
                Bio = profileDto.Bio,
                Skills = profileDto.Skills,
                CvFile = profileDto.CvFile
            };


            if (imageFile != null)
            {
                var uploadResult = await _cloudinaryService.UploadImageAsync(imageFile);
                newUser.Image = uploadResult.SecureUrl.ToString();
            }

            await _userRepository.AddUserAsync(newUser);
            await _userRepository.SaveAsync();

            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
        }



        [HttpPut("{id}/profiles")]
        public async Task<IActionResult> CreateOrUpdateUserProfile(int id, [FromForm] ProfileDto profileDto, IFormFile imageFile = null)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return NotFound();

           
            _mapper.Map(profileDto, user);

      
            if (imageFile != null)
            {
                var uploadResult = await _cloudinaryService.UploadImageAsync(imageFile);
                user.Image = uploadResult.SecureUrl.ToString(); 
            }

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
