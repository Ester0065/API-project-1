using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Runtime.Intrinsics.Arm;


// For more informati on on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //The assignment asks to split the code into four projects: the API, Entities, Services and Repositories
    public class UsersController : ControllerBase
    {
        static string filePath = "Users.txt";
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
                            //GET by id returns 201 Created here, but the assignment asks for 200: which result returns the found user with 200?
                            return CreatedAtAction(nameof(Get), new { id = user.id },user);
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
                        textToReplace = currentUserInFile;
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
