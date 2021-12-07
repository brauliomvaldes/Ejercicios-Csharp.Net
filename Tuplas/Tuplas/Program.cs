using System;

namespace Tuplas
{
    class Program
    {
        static void Main(string[] args)
        {
            //opcion
            // (int, string) tupla = (10, "hola");
            var tupla = (
                // alternativa agregar etiqueta para acceder a ellos 
                entero:1,
                saludo:"hola", 
                peso: 72.4, 
                nacimiento:DateTime.Now, 
                persona: new Person() { Name = "Héctor"}
                );
            
            Console.WriteLine(tupla.Item1);
            Console.WriteLine(tupla.Item2);
            Console.WriteLine(tupla.Item5.Name);
            Console.WriteLine(Person.getSome().Item2)
        }
    }

    class Person
    {
        public string Name { get; set; }

        // crear un metodo para devolver una tupla y evitar
        // crear una clase para devolver es
        public static (int, string) getSome() => (1,"papas");

    }
}
