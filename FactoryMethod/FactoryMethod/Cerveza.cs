using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Cerveza : BebidaEmbriagante
    {
        public override int CuantoMeEmbriagaPorHora()
        {
            return 5;
        }
    }
}
