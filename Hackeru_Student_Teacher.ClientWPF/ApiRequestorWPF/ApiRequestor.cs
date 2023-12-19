using Hackeru_Student_Teacher.ClientWPF.Models_Connect;
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
        ///3) Call Server API And Get JSON TEXT By LOGIN
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        public async Task<DeserializerUser> LoginRequestAsync(UserLogin userLogin)
        {
            try
            {
                //3.1) Convert login data (inside UserLogin Object) to JSON.
                string jsonLoginData = JsonSerializer.Serialize<UserLogin>(userLogin);
                using StringContent loginContent = new StringContent(jsonLoginData, Encoding.UTF8, @"application/json");

                //3.2 Get response from the server.
                using HttpResponseMessage response = await httpClient.PostAsync("/api/StudentTeacher/login", loginContent);

                // Check the status code that returned is 200 types.
                response.EnsureSuccessStatusCode();

                //3.3 Get Json Data (as DeserializerUser) From Server Response.
                DeserializerUser? userResponse = await response.Content.ReadFromJsonAsync<DeserializerUser>();

                return userResponse;
            }
            catch
            {
                // Handle exception
                return null;
            }
        }


    }
}
