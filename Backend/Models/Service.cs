
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Service
    {

        [Required]
        public int ServiceId { get; set; }
        [Required]
        public int UserId { get; set; } 
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Status { get; set; } = "Active";
        [Required]
        public  DateTime CreatedDate { get; set; }


        public virtual User? Freelancer { get; set; }
       
    }

}
