using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class PastelComposite : Component
    {
        private List<Component> ingredientes = new List<Component>();

        public decimal Costo
        {
            get
            {
                decimal costo = 0;
                foreach(var oElemento in ingredientes)
                {
                    if (oElemento.GetType().Name == "PastelComposite")
                        costo += ((PastelComposite)oElemento).Costo;
                    else
                        costo += oElemento.Costo;
                }
                return costo;
            }
        }

        public PastelComposite(string Nombre, decimal Costo = 0) : base(Nombre, Costo)
        {
        }

        public void Add(Component oElemento)
        {
            ingredientes.Add(oElemento);
        }

        public void Remove(Component oElemento)
        {
            ingredientes.Remove(oElemento);
        }



    }
}
