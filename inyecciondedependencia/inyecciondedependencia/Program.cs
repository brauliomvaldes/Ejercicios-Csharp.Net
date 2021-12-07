using System;

namespace inyecciondedependencia
{
    class Program
    {
        static void Main(string[] args)
        {
            IBebida oBebida = new PiñaColada();
            Cantinero oCantinero = new Cantinero(oBebida);
            oCantinero.Preparar();

            oBebida = new MediasDeSeda("picante");
            oCantinero = new Cantinero(oBebida);
            oCantinero.Preparar();

        }
    }
}
