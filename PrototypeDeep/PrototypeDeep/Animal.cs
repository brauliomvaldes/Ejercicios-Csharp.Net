using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeDeep
{

    // patron prototype clonado profundo
    public class Animal : ICloneable
    {
        public int Patas { get; set; }
        public string Nombre { get; set; }
        public Detalle Rasgos { get; set; }

        public object Clone()
        {
            // clonado profundo forma simple
            Animal clonado = this.MemberwiseClone() as Animal;
            Detalle detalle = new Detalle();
            detalle.Color = this.Rasgos.Color;
            detalle.Raza = this.Rasgos.Raza;
            clonado.Rasgos = detalle;
            
            return clonado;
        }
    }

    public class Detalle
    {
        public string Color { get; set; }
        public string Raza { get; set; }

    }

}
