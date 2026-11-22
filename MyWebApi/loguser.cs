using System.ComponentModel.DataAnnotations;

namespace MyWebApi
{
    //In C#, class names are written in PascalCase: Loguser, and the file is named Loguser.cs
    public class loguser
    {
        //[EmailAddress]
        public string email { get; set; }
      //  [Required]
        public string password { get; set; }
    }
}
