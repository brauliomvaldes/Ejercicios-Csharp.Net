using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            BebidaEmbriagante oBebida1 = Fabrica.CreadorBebida(Fabrica.CERVEZA);
            Console.WriteLine(oBebida1.CuantoMeEmbriagaPorHora());

            BebidaEmbriagante oBebida2 = Fabrica.CreadorBebida(Fabrica.VINO_TINTO);
            Console.WriteLine(oBebida2.CuantoMeEmbriagaPorHora());

        }
    }
}
