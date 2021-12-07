using System;
using System.Collections.Generic;
using System.Text;

namespace inyecciondedependencia
{
    public class MediasDeSeda : IBebida
    {
        public string tipo { get; set; }

        public MediasDeSeda(string tipo)
        {
            this.tipo = tipo;
        }

        public void Preparar()
        {
            Console.WriteLine("Se hace una Media de Seda, "+this.tipo);
        }
    }
}

