namespace MyWebApi
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
       
       // [Required]
        public string firstName { get; set; }
      //  [Required]
        public string lastName { get; set; }
       // [EmailAddress]
        public string email { get; set; }
       // [Required]
        public string password { get; set; }
        public int id { get; set; }

    }
}
