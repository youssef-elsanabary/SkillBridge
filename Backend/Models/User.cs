using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Contracts;

namespace Backend.Models
{
  
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public virtual List<Service> Services { get; set; } = new List<Service>();
        public virtual Profile Profile { get; set; }
        public virtual List<Contract> Contracts { get; set; } = new List<Contract>();
        public virtual List<Message> SentMessages { get; set; } = new List<Message>();
        public virtual List<Message> ReceivedMessages { get; set; } = new List<Message>();
        public virtual List<Review> Reviews { get; set; } = new List<Review>();
        public virtual List<Proposal> Proposals { get; set; } = new List<Proposal>();
    }
}
