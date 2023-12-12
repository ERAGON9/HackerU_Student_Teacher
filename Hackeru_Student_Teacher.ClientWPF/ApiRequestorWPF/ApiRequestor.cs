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
        {
        }

        public ApiRequestor(string apiUrl)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(apiUrl);
        }

        /// <summary>
        ///3) Call Server API And Get JSON TEXT By LOGIN
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public async Task<DeserializerUser> LoginRequestAsync(UserLogin userLogin)
        {
            try
            {
                //3.1) Convert credentials Object to JSON
                string jsonLoginData = JsonSerializer.Serialize<UserLogin>(userLogin);
                using StringContent loginContent = new StringContent(jsonLoginData, Encoding.UTF8, @"application/json");

                //3.2 Get response 
                using HttpResponseMessage response = await httpClient.PostAsync("/api/StudentTeacher/login", loginContent);

                response.EnsureSuccessStatusCode(); // Check the status code that returned is 200 types.

                //3.3 Get Json Data From Server Result
                DeserializerUser userResponse = await response.Content.ReadFromJsonAsync<DeserializerUser>();

                return userResponse;
            }
            catch (Exception ex)
            {
                // Handle exception
                return null;
            }
        }


    }
}
