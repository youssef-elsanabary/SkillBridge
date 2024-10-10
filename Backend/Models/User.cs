using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
  
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }

        public virtual List<Service>? Services { get; set; } = new List<Service>();
        public virtual Profile? Profile { get; set; }
        public virtual List<Contract>? Contracts { get; set; } = new List<Contract>();
        public virtual List<Message>? SentMessages { get; set; } = new List<Message>();
        public virtual List<Message>? ReceivedMessages { get; set; } = new List<Message>();
        public virtual List<Review>? Reviews { get; set; } = new List<Review>();
        public virtual List<Proposal>? Proposals { get; set; } = new List<Proposal>();
    }
}
