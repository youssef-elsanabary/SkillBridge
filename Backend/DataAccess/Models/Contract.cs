using Backend.Models;
using System.ComponentModel.DataAnnotations;

public class Contract
{
    [Required]
    public int ContractId { get; set; }

    public int ServiceId { get; set; }


    public int ClientId { get; set; }
    public int FreelancerId { get; set; }  

    public string Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public double? Price { get; set; }
    public int? Duration { get; set; }

 
    public virtual User Client { get; set; }   
    public virtual User Freelancer { get; set; }   
    public virtual Service? Service { get; set; }  
}
