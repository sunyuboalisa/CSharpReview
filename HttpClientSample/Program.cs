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

        static async void Main(string[] args)
        {
            await GetDataSimpleAsync();
        }
        private static async Task GetDataSimpleAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(NorthwindUrl);
                    response.EnsureSuccessStatusCode();

                    WriteLine($"Response Status code: {(int)response.StatusCode} " +
                            $"{response.ReasonPhrase}");
                    string responseBodyAsText = await response.Content.ReadAsStringAsync();
                    WriteLine($"Received payload of {responseBodyAsText.Length} character");
                    WriteLine();
                    WriteLine(responseBodyAsText);
                }
            }
            catch (Exception ex)
            {

            }
            
        }
        private static async Task GetDataWithHeadersAsync()
        {
            try
            {
                using (var client=new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Accept",
                        "application/json;odata=verbose");
                    ShowHeaders("Request Headers:", client.DefaultRequestHeaders);
                    HttpResponseMessage response = await client.GetAsync(NorthwindUrl);
                    response.EnsureSuccessStatusCode();
                    ShowHeaders("Response Headers:", response.Headers);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private static void ShowHeaders(string title,HttpHeaders headers)
        {
            WriteLine(title);
            foreach (var header in headers)
            {
                string value = string.Join(" ", header.Value);
                WriteLine($"Header: {header.Key} Value: {value}");
            }
            WriteLine();
        }
    }
}
