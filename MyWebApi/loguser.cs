using System.ComponentModel.DataAnnotations;

namespace MyWebApi
{
    //In C#, class names are written in PascalCase, and a full name is clearer: LoginUser (in LoginUser.cs).
    //Properties too: Email, Password
    public class loguser
    {
        //[EmailAddress]
        public string email { get; set; }
      //  [Required]
        public string password { get; set; }
    }
}
