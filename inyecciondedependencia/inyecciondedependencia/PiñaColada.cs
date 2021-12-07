using System;
using System.Collections.Generic;
using System.Text;

namespace inyecciondedependencia
{
    public class PiñaColada : IBebida
    {

        public void Preparar()
        {
            Console.WriteLine("Se hace una piña colada");
        }
    }
}
