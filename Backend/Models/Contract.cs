using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Contract
    {

        [Required]
        public int ContractId { get; set; }
        [Required]
        public int ServiceId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Status { get; set; } 
        [Required]
        public DateTime CreatedDate { get; set; }

     
        public virtual User? User { get; set; }
        public virtual Service? Service { get; set; }
    }
}
