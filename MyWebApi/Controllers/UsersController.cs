using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
//fix: Removed "using System.Runtime.Intrinsics.Arm;" - it was added by mistake and is not used


// For more informati on on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //fix: The path never changes, so it can be readonly
        static readonly string filePath = "Users.txt";
        // GET: api/<Users>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "esty", "miri" };
        }

        // GET api/<Users>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
               

                using (StreamReader reader = System.IO.File.OpenText(filePath))
                {
                    string? currentUserInFile;
                    while ((currentUserInFile = reader.ReadLine()) != null)
                    {
                        User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                        if (user.id == id)
                            //fix: GET only reads, so it returns 200 Ok and not 201 Created
                            return Ok(user);
                }
            } 

            return NotFound();
        }        
        
        // POST api/<Users>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson +
            Environment.NewLine);
            
            return Ok(user);
            // return CreatedAtAction(nameof(Get), new { id = user.id },
            // user);
        }


        // [HttpPost("{email} {password}")]
        [HttpPost("login")]
       // public ActionResult<User> PostLog([FromBody] loguser loginUser)
        public ActionResult<User> PostLog([FromBody] loguser loginUser)

        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.email == loginUser.email && user.password == loginUser.password)
                        return user;
                }
            }
            return NoContent();
        }

        // PUT api/<Users>/5
        [HttpPut("{id}")]
        //The route has {id}, but the method doesn't use it: add int id as a parameter, look for the user
        //with this id, and set userToUpdate.id = id before saving.
        //The assignment asks PUT to return Ok(): change void to IActionResult and return Ok() at the end
        public void Put( [FromBody] User userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader =
            System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.id == userToUpdate.id)
                    {
                        textToReplace = currentUserInFile;
                        //fix: Found- break
                        break;
                    }
                }
            }
            
                if(textToReplace != string.Empty)
                {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace,
                JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(filePath, text);
                }
        }

        // DELETE api/<Users>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
