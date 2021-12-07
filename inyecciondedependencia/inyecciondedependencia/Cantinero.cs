using System;
using System.Collections.Generic;
using System.Text;

namespace inyecciondedependencia
{
    public class Cantinero
    {
        IBebida bebida;
        public Cantinero(IBebida _bebida) {

            this.bebida = _bebida;
        }


        public void Preparar()
        {
            this.bebida.Preparar();
        }
    }
}
