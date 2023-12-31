﻿using Hackeru_Student_Teacher.ClientWPF.Models_Connect;
using Hackeru_Student_Teacher.ClientWPF.Models_WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hackeru_Student_Teacher.ClientWPF.ApiRequestorWPF
{
    public class ApiRequestor
    {
        readonly HttpClient httpClient;

        public ApiRequestor() : this("https://localhost:7216")
        {}

        public ApiRequestor(string apiUrl)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(apiUrl);
        }


        /// <summary>
        ///  Send register request to server with DeserializerUser and get answer the server response.
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns>'true' if the response returned is ok (succeeded) or 'false' if not.</returns>
        public async Task<bool> RegisterRequestAsync(DeserializerUser newUser)
        {
            try
            {
                //4) Convert Register data (inside DeserializerUser Object) to JSON.
                string jsonRegisterData = JsonSerializer.Serialize<DeserializerUser>(newUser);
                using StringContent registerContent = new StringContent(jsonRegisterData, Encoding.UTF8, @"application/json");

                //4.1) Get response from the server.
                using HttpResponseMessage response = await httpClient.PostAsync("/api/StudentTeacher/register", registerContent);

                //4.2) Check the status code that returned is 200 types.
                response.EnsureSuccessStatusCode();

                //4.3) If we got to here it means The server return 'OK' so the new user added to dataBase!
                return true;
            }
            catch
            {
                //4.3) If we got to here it means The server return 'BadRequest' so the new user not added to dataBase!
                return false;
            }
        }


        /// <summary>
        /// Send login request to server with UserLogin and get answer the server response.
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns> DeserializerUser with the user data if exists at the database or null if not.</returns>
        public async Task<DeserializerUser?> LoginRequestAsync(UserLogin userLogin)
        {
            try
            {
                //4) Convert login data (inside UserLogin Object) to JSON.
                string jsonLoginData = JsonSerializer.Serialize<UserLogin>(userLogin);
                using StringContent loginContent = new StringContent(jsonLoginData, Encoding.UTF8, @"application/json");

                //4.1) Get response from the server.
                using HttpResponseMessage response = await httpClient.PostAsync("/api/StudentTeacher/login", loginContent);

                //4.2) Check the status code that returned is 200 types.
                response.EnsureSuccessStatusCode();

                //4.3) Get Json Data (as DeserializerUser) From Server Response.
                DeserializerUser? userResponse = await response.Content.ReadFromJsonAsync<DeserializerUser>();

                return userResponse;
            }
            catch(Exception ex)
            {
                //4.3) If we got to here it means The server return 'NotFound', user with this details not found at the dataBase!
                return null;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="newExam"></param>
        /// <param name="teacherToUpdate"></param>
        /// <returns></returns>
        public async Task<bool> AddExamAsync(Exam newExam, Teacher teacherToUpdate)
        {
            try
            {
                //4) Convert login data (inside TeacherAndExam Object) to JSON.
                TeacherAndExam teacherAndExam = new TeacherAndExam(teacherToUpdate, newExam);
                string jsonAddExamData = JsonSerializer.Serialize<TeacherAndExam>(teacherAndExam);
                using StringContent addExamContent = new StringContent(jsonAddExamData, Encoding.UTF8, @"application/json");

                //4.1) Get response from the server.
                using HttpResponseMessage response = await httpClient.PostAsync("/api/StudentTeacher/addExam", addExamContent);

                //4.2) Check the status code that returned is 200 types.
                response.EnsureSuccessStatusCode();

                return true;
            }
            catch (Exception ex)
            {
                //4.3) If we got to here it means The server return 'BadRequest'.
                return false;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Exam>> GetAllExams()
        {
            try
            {
                //4) Get response from the server.
                using HttpResponseMessage response = await httpClient.GetAsync("/api/StudentTeacher/getAllExams");

                //4.1) Check the status code that returned is 200 types.
                response.EnsureSuccessStatusCode();

                //4.2) Get Json Data (as DeserializerUser) From Server Response.
                List<Exam> allExamsResponse = await response.Content.ReadFromJsonAsync<List<Exam>>();

                return allExamsResponse;
            }
            catch (Exception ex)
            {
                //4.2) If we got to here it means The server return 'BadRequest'.
                return null;
            }
        }
    }
}
