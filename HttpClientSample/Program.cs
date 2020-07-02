using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HttpClientSample
{
    class Program
    {
        private const string NorthwindUrl = "";
        private const string IncorrectUrl = "";

        static void Main(string[] args)
        {

        }
        private async Task GetDataSimpleAsync()
        {
            using (var client=new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(NorthwindUrl);

                if (response.IsSuccessStatusCode)
                {
                    WriteLine($"Response Status code: {(int)response.StatusCode} "+
                        $"{response.ReasonPhrase}");
                    string responseBodyAsText = await response.Content.ReadAsStringAsync();
                    WriteLine($"Received payload of {responseBodyAsText.Length} character");
                    WriteLine();
                    WriteLine(responseBodyAsText);
                }
            }
        }
    }
}
