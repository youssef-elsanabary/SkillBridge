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
        
        public virtual HashSet<Service> Services { get; set; }
        
        public virtual Profile Profiles { get; set; }
        public virtual Contract Contracts { get; internal set; }
    }
}
