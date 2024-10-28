using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Backend.BusinessLogic;

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

        public ServiceStatus Status { get; set; } = ServiceStatus.Pending;


        public DateTime CreatedDate { get; set; }

        public virtual Contract? Contract { get; set; }
        public virtual User? Freelancer { get; set; }

        
        public virtual ICollection<Proposal> Proposals { get; set; } = new List<Proposal>();
    }
}
