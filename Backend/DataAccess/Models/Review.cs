using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
        public class Review
        {
            [Required]
            public int ReviewId { get; set; }

            [Required]
            public int FreelancerId { get; set; }  

            public int BuyerId { get; set; } 

            [Range(1, 5)]
            public int Rating { get; set; }

            public string? Comment { get; set; }

            public virtual User? Freelancer { get; set; }  
            public virtual User? Buyer { get; set; }       
        }
    }


