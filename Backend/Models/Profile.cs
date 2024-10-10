using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Profile
    {
        [Required]
        public int ProfileId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Bio { get; set; }
        [Required]
        public string Skills { get; set; }
        [Required]
        public string CvFile { get; set; } 
        [Required]
        public DateTime CreatedDate { get; set; }

      
        public virtual User? User { get; set; }
    }

}
