using System;
using System.Net.Http;
using System.Threading.Tasks;
using serviceA.Application.Interfaces;
using serviceA.Domain;

namespace serviceA.Application
{
    public class Application : IApplication
    {
        static readonly HttpClient client = new HttpClient();

        public async Task<string> GetResponse()
        {
            try
            {
                var uri = "http://serviceb.docker.localhost/Main";
                HttpResponseMessage response = await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);

                throw new Exception($"Failed to call service B. {e.Message}");
            }
        }
    }
}
