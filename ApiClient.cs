using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;

namespace Lr
{
    internal class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(string baseUrl)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseUrl);
        }

        public async Task<Lang<T>> GetAsync<T>()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("");
                response.EnsureSuccessStatusCode();
                string responseContent = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<List<T>>(responseContent);

                return new Lang<T>
                {
                    Message = "Success",
                    StatusCode = response.StatusCode,
                    Results = responseData
                };
            }
            catch (Exception ex)
            {
                return new Lang<T>
                {
                    Message = ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        public async Task<Lang<T>> GetAsyncWithParam<T>(string word, string lang)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"?text={word}&language={lang}");
                response.EnsureSuccessStatusCode();
                string responseContent = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<T>(responseContent);

                return new Lang<T>
                {
                    Message = "Success",
                    StatusCode = response.StatusCode,
                    Results = new List<T> { responseData }
                };
            }
            catch (Exception ex)
            {
                return new Lang<T>
                {
                    Message = ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
