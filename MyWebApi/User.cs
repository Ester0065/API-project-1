namespace MyWebApi
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
       
       // [Required]
        //In C#, public properties are PascalCase (FirstName). Keep the stored names: System.Text.Json is case-sensitive, so use the PropertyNameCaseInsensitive option when reading the file
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
