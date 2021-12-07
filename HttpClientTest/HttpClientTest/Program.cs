using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string uri = "https://jsonplaceholder.typicode.com/todos/1";

            var httpClient = new HttpClient();

            var consulta = await httpClient.GetAsync(uri);

            var json = await consulta.Content.ReadAsStringAsync();

            // imprimimos resultado

            Console.WriteLine(json);






        }
    }
}
