using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class SuperSaturadoServerState : ServerState
    {
        public override void Respuesta()
        {
            Task.Delay(1000);
            Console.WriteLine("Respuesta 200 con delay 1000");
        }
    }
}
