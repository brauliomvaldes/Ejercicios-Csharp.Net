using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    // segunda forma de utilizar estrategia
    // utilizando enum 

    class EstrategiasDelBorrachoContexto
    {
        private IBorracho oBorracho;

        public enum Comportamiento
        {
            HacerOjitos, InvitarCerveza , HacerCaraDeGalan
        }


        /*
        // forma sin enum

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

        */

        public void Conquistar(Comportamiento opcion)
        {
            switch (opcion)
            {
                case (Comportamiento.HacerOjitos):
                    this.oBorracho = new EstrategiaOjitos();
                    break;
                case (Comportamiento.InvitarCerveza):
                    this.oBorracho = new EstrategiaInvitarServeza();
                    break;
                case (Comportamiento.HacerCaraDeGalan):
                    this.oBorracho = new EstrategiaHacerCaraDeGalan();
                    break;
            }

            this.oBorracho.Conquistar();
        }

    }
}
