using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public class Singleton
    {

        private static Singleton instancia = null;
        public string mensaje = "";

        protected Singleton() {
            mensaje = "Valor de creación";
        }

        public static Singleton Instancia
        {
            get{
                if (instancia == null)
                {
                    instancia = new Singleton();
                }
 
                return instancia;
            }
        }
    }
}
