using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class SaturadoServerState : ServerState
    {
        public override void Respuesta()
        {
            Task.Delay(500);
            Console.WriteLine("Respuesta 200 con delay 500");
        }
    }
}
