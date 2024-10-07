namespace Backend.Models
{
    public class Contract
    {
        public int ContractId { get; set; }
        public int ServiceId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; } 
        public DateTime CreatedDate { get; set; }

     
        public virtual User User { get; set; }
        public virtual Service Service { get; set; }
    }
}
