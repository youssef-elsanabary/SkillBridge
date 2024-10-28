using Backend.BusinessLogic;
using Backend.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class Contract
{
    [Required]
    public int ContractId { get; set; }

    public int ServiceId { get; set; }
    public int ClientId { get; set; }
    public int FreelancerId { get; set; }

    public ContractStatus Status { get; set; } = ContractStatus.InProgress;
    public DateTime CreatedDate { get; set; } = DateTime.Now; 
    public double? Price { get; set; }
    public int? Duration { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual User? Client { get; set; }
    public virtual User? Freelancer { get; set; }
    public virtual Service? Service { get; set; }
}
