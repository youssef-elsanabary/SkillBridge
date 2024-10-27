using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Proposal
    {
        [Required]
        public int ProposalId { get; set; }

        public int ServiceId { get; set; }

        public int UserId { get; set; }

        public DateTime ProposalDate { get; set; }

        public string? Status { get; set; }

        public virtual Service? Service { get; set; }
        public virtual User? User { get; set; }
    }
}
