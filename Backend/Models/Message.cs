namespace Backend.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Content { get; set; }


        public virtual User Sender { get; set; }
        public virtual User Receiver { get; set; }
       
    }

}
