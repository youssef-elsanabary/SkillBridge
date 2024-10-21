using System.ComponentModel.DataAnnotations;

namespace Backend.DTO
{
    public class ProfileDto
    {
        public string? Image { get; set; }
        public string? Description { get; set; }
        public string? Bio { get; set; }
        public string? Skills { get; set; }
        public string? CvFile { get; set; }
    }



}
