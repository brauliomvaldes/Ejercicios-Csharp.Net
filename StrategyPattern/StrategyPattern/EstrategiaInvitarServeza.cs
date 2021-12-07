using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class EstrategiaInvitarServeza : IBorracho
    {
        // Estrategia invitar cerveza
        public void Conquistar()
        {
            Console.WriteLine("Le invito una cerveza");
        }
    }
}
