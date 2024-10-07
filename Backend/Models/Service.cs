
namespace Backend.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public int UserId { get; set; }  // Freelancer ID
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string Status { get; set; } = "Active"; 
        public  DateTime CreatedDate { get; set; }

        public virtual User Freelancer { get; set; }
       
    }

}
