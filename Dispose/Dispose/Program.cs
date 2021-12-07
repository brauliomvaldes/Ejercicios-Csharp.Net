using System;

namespace Dispose
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\brauliomariano\source\repos\Dispose\MyText.txt";

            using(var escritor1 = new Writer(path)){
                escritor1.Write("Primera linea de texto");
            }


            using (var escritor2 = new Writer(path))
            {
                escritor2.Write("Segunda linea de texto");
            }
                

        }
    }
}
