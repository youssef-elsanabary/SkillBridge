using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{

        public class Payment
        {

            [Required]
            public int PaymentId { get; set; }
          
            public int UserId { get; set; }
         
            public int ContractId { get; set; }
     
            public DateTime PaymentDate { get; set; } = DateTime.Now;
      
            public double Amount { get; set; }
            
            public string PaymentStatus { get; set; }

            
                public  User? User { get; set; } 
                public  Contract? Contract { get; set; }
        }
   

}



