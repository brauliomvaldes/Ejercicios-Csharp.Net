using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class EstrategiasDelBorrachoContexto
    {
        private IBorracho oBorracho;

        public EstrategiasDelBorrachoContexto()
        {
            // establece estrategia por defecto
            this.oBorracho = new EstrategiaOjitos();
        }

        // establece atributo con estragia1
        public void EstablecerConquistaOjitos()
        {
            this.oBorracho = new EstrategiaOjitos();
        }

        // establece atributo con estrategia2
        public void EstablecerConquistaInvitarCerveza()
        {
            this.oBorracho = new EstrategiaInvitarServeza();
        }

        public void Conquistar()
        {
            this.oBorracho.Conquistar();
        }

    }
}
