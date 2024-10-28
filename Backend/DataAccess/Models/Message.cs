using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Message
    {
        [Required]
        public int MessageId { get; set; }
        [Required]
        public int SenderId { get; set; }
        [Required]
        public int ReceiverId { get; set; }
  
        public string? Content { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public virtual User? Sender { get; set; }
        public virtual User? Receiver { get; set; }
       
    }

}
