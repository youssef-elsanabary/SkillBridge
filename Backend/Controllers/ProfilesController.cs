using Backend.Context;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly AppDbContext _context;
       public ProfilesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProfiles()
        {
            var profiles = _context.Profiles.ToList();
            return Ok(profiles);
        }

        [HttpGet("{id}")]
        public IActionResult GetProfile(int id)
        {
            var profile = _context.Profiles.Find(id);
            if (profile == null) return NotFound();
            return Ok(profile);
        }

        [HttpPost]
        public IActionResult CreateProfile([FromBody] Profile profile)
        {
            _context.Profiles.Add(profile);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProfile), new { id = profile.ProfileId }, profile);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProfile(int id, [FromBody] Profile updatedProfile)
        {
            var profile = _context.Profiles.Find(id);
            if (profile == null) return NotFound();

            profile.Name = updatedProfile.Name;
            profile.Image = updatedProfile.Image;
            profile.Description = updatedProfile.Description;
            profile.Bio = updatedProfile.Bio;
            profile.Skills = updatedProfile.Skills;
            profile.CvFile = updatedProfile.CvFile;

            _context.Profiles.Update(profile);
            _context.SaveChanges();

            return Ok(profile);
        }
    }

}
    

