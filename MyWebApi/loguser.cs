using System.ComponentModel.DataAnnotations;

namespace MyWebApi
{
    //In C#, class names are PascalCase and the file is named after the class: Loguser, Loguser.cs
    public class loguser
    {
        //[EmailAddress]
        public string email { get; set; }
      //  [Required]
        public string password { get; set; }
    }
}
