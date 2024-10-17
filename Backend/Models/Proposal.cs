using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Proposal
    {
        [Required]
        public int ProposalId { get; set; }
        [Required]
        public int ServiceId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime ProposalDate { get; set; }
        [Required]
        public string? Status { get; set; }

        public virtual Service? Service { get; set; }
        public virtual User? User { get; set; }
    }

}
