using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{

        public class Payment
        {

            [Required]
            public int PaymentId { get; set; }
            [Required]
            public int UserId { get; set; }
            [Required]
            public int ContractId { get; set; }
            [Required]
            public DateTime PaymentDate { get; set; } = DateTime.Now;
            [Required]
            public double Amount { get; set; }
            
            public string PaymentStatus { get; set; }

            
                public  User? User { get; set; } 
                public  Contract? Contract { get; set; }
        }
   

}



