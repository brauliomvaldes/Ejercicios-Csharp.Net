using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static async Task Main(string[] args)
        {

            // formas de definir una variable, var no es lo mismo que var de javascript
            // una vez definido el tipo no se puede cambiar si se inicializan 

            /*
            var nombre1 = new string("");
            nombre1 = "patito";
            string nombre2 = "";
            nombre2 = "gatito";

            // tambien es posible definir un objeto con una clase anónima
            var nombre3 = new
            {
                nombre = "jose",
                edad = 43
            };

            */
            // es posible definir variables de forma dinñamica con el tipo dynamic
            /*
            dynamic some = new string("");
            some = "saludo";
            Console.WriteLine(some);

            some = 2500;
            Console.WriteLine(some);
            */
            // consultar una API asincronamente (multihilos)
            // utilizando ASYN TASK en la definición del método
            // y await delante de la instrucción que debe esperar hasta que se concrete las lineas anteriores
            // 

            // definir variable

            var url = "https://jsonplaceholder.typicode.com/todos/1";

            // crear objeto tipo httpclient

            var httpClient = new HttpClient();
            
            // await esperar hasta que se concrete la instrucción señalada
            // significa que no se vanza hasta concluir el proceso
            var respuesta = await httpClient.GetAsync(url);
            // castear respuesta en formato json
            string json = await respuesta.Content.ReadAsStringAsync();

            Console.WriteLine(json);

            // utilizar paradigma funcional
            var numbers = new List<int> { 1, 2, 4, 5, 6, 7 };

            numbers.ForEach((n) => { Console.WriteLine(n); });

















        }
    }
}
