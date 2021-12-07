using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("valor:" + Singleton.Instancia.mensaje);
            Singleton.Instancia.mensaje = "Nuevo valor misma instancia";
            Console.WriteLine("valor:" + Singleton.Instancia.mensaje);
        }
    }
}
