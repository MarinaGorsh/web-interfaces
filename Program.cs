using System;
using System.Net;
using System.Threading.Tasks;

namespace Lr
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url1 = $"https://languagetool.org/api/v2/languages";
            ApiClient apiClient1 = new ApiClient(url1);

            var responseGet = await apiClient1.GetAsync<LangDetails>();

            if (responseGet.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("GET Request Success!");
                foreach (var lang in responseGet.Results)
                {
                    Console.WriteLine($"Name: {lang.Name}, Code: {lang.Code}, LongCode: {lang.LongCode}");
                }
            }
            else
            {
                Console.WriteLine($"GET Request Failed. Status Code: {responseGet.StatusCode}, Message: {responseGet.Message}");
            }

            string url2 = $"https://languagetool.org/api/v2/check";
            ApiClient apiClient2 = new ApiClient(url2);

            Console.WriteLine("define language");
            string word = Console.ReadLine();

            var responsePost = await apiClient2.GetAsyncWithParam<LanguageToolResponse>(word, "auto");

            if (responsePost != null)
            {
                if (responsePost.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine($"Post Request Success!");
                    foreach (var res in responsePost.Results)
                    {
                        Console.WriteLine($"Language: {res.Language.Name}, Code: {res.Language.Code}");
                    }
                }
                else
                {
                    Console.WriteLine($"POST Request Failed. Status Code: {responsePost.StatusCode}, Message: {responsePost.Message}");
                }
            }
            else
            {
                Console.WriteLine($"POST Request Failed. Status Code: {responsePost.StatusCode}, Message: {responsePost.Message}");
            }
        }
    }
}
