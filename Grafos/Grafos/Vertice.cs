using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos
{
    public class Vertice
    {
        public int Valor { get; set; }

        public List<Vertice> Aristas { get; set; }

        public Vertice(int Valor)
        {
            this.Valor = Valor;
            Aristas = new List<Vertice>();
        }
    }
}
