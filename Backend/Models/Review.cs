using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Review
    {
        [Required]
        public int ReviewId  { get; set; }
        [Required]
        public int ServiceId { get; set; }
        [Required]
        public int BuyerId { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public string Comment { get; set; }
        

        
        public virtual Service? Service { get; set; }
        public virtual User? Buyer { get; set; }
    }

}
