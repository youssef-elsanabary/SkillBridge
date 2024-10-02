namespace Backend.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Bio { get; set; }
        public string Skills { get; set; }
        public string CvFile { get; set; } // Path to the CV file
        public DateTime CreatedDate { get; set; }

      
        public virtual User Users { get; set; }
    }

}
