
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Service
    {

        [Required]
        public int ServiceId { get; set; }
      
        public int UserId { get; set; } 
       
        public string? Title { get; set; }
        
        public string? Description { get; set; }
       
        public double Price { get; set; }
        
        public string? Category { get; set; }
       
        public string? Status { get; set; } = "Active";
        
        public  DateTime CreatedDate { get; set; }

        public virtual Contract? Contract { get; set; }
        public virtual User? Freelancer { get; set; }
       
    }

}
