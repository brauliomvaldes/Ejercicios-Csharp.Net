using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class EstrategiaOjitos : IBorracho
    {
        // estrategia haciendo ojitos
        public void Conquistar()
        {
            Console.WriteLine("Le hago ojitos a la muchacha");
        }
    }
}
