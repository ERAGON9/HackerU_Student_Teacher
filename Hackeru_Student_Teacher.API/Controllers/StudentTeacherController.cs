﻿using Hackeru_Student_Teacher.API.DataBase;
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
        /// <summary>
        /// Register API That Gets DeserializerUser object newUser,
        /// if the user not already exists it will add him to the dataBase.
        /// /api/StudentTeacher/register
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns>'OK' if the user Added to dataBase or 'BadRequest' if not.</returns>
        [HttpPost("register")]
        public ActionResult Register([FromBody] DeserializerUser newUser)
        {
            using (var dataBase = new DbStudentTeacher())
            {

                bool dataValid = ValidationChecksApi.IsRegisterValid(dataBase, newUser);

                if (dataValid)
                {
                    if (newUser.IsTeacher == Enums.UserRole.Teacher)
                        dataBase.Teachers.Add(new Teacher(newUser));
                    else
                        dataBase.Students.Add(new Student(newUser));
                    dataBase.SaveChanges();
                    return Ok();
                }

                return BadRequest();
            }
        }


        /// <summary>
		/// Login API That Gets email and password and return OK if the user found or NotFound if not.
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
                //User existsUser = users.FirstOrDefault(user => user.Email == userLogin.Email && user.Password == userLogin.Password);

                User existsUser = new Teacher("Lior Teacher", "LiorT@gmail.com", "LiorTeacher");
                //User existsUser = new Student("Lior Student", "LiorS@gmail.com", "LiorStudent");

                return Ok(existsUser);
            }

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
