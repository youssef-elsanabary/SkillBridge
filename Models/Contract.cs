namespace Backend.Models
{
    public class Contract
    {
        public int ContractId { get; set; }
        public int ServiceId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; } // Pending, Active, Completed, Cancelled
        public DateTime CreatedDate { get; set; }

     
        public virtual User Users { get; set; }
        public virtual Service Services { get; set; }
    }
}
