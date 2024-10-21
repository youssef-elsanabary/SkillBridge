using System.ComponentModel.DataAnnotations;
namespace Backend.Models
{
    public class TransferRequest
    {
        [Required]
        public decimal Amount { get; set; } // Amount in dollars
        [Required]
        public string Currency { get; set; } // e.g., "usd"
        [Required]
        public string DestinationAccountId { get; set; } // Connected account ID
    }

}
