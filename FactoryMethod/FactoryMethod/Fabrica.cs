using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class Fabrica
    {
        public const int VINO_TINTO = 1;
        public const int CERVEZA = 2;

        public static BebidaEmbriagante CreadorBebida(int Tipo)
        {
            switch (Tipo)
            {
                case VINO_TINTO:
                    return new VinoTinto();
                case CERVEZA:
                    return new Cerveza();
                default:
                    return null;
            }
        }

    }
}
