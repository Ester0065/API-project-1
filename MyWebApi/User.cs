namespace MyWebApi
{
    using System.ComponentModel.DataAnnotations;

    //In C#, public properties are written in PascalCase (FirstName, LastName, Email, Password, Id).
    //If you rename them, Users.txt still has the old names, so read it with
    //new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
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
