using Hackeru_Student_Teacher.API.Models_API;
using Hackeru_Student_Teacher.API.Models_Connect;
using Hackeru_Student_Teacher.ClientWPF.Progarm;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hackeru_Student_Teacher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentTeacherController : ControllerBase
    {
        List<User> users = new List<User>();

        /*
        // GET: api/<StudentTeacherController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StudentTeacherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentTeacherController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        */


        /// <summary>
		/// 1) Login API That Gets email and password and return OK if the user found or NotFound if not.
		/// /api/StudentTeacher/login
		/// </summary>
		/// <param name="userLogin"></param>
		/// <returns></returns>
		[HttpPost("login")]
        public ActionResult<User> Login([FromBody] LoginUser userLogin)
        {
            bool UserFound = true; //ValidationChecksApi.IsLoginValid(users, userLogin);  // Your validation logic here.
            if (UserFound)
            {
                //IUser existsUser = users.FirstOrDefault(user => user.Email == userLogin.Email && user.Password == userLogin.Password);
                User existsUser = new Teacher("Lior Teacher", "LiorT@gmail.com", "LiorTeacher");
                //User existsUser = new Student("Lior Student", "LiorS@gmail.com", "LiorStudent"));
                return Ok(existsUser);
            }
            else
                //404 Error
                return NotFound("User Not Found");
        }


        /*
        // PUT api/<StudentTeacherController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentTeacherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
