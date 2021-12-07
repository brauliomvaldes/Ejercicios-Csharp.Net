using System;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            EstrategiasDelBorrachoContexto oBorracho = new EstrategiasDelBorrachoContexto();

            oBorracho.Conquistar(EstrategiasDelBorrachoContexto.Comportamiento.HacerOjitos);
            oBorracho.Conquistar(EstrategiasDelBorrachoContexto.Comportamiento.InvitarCerveza);
            oBorracho.Conquistar(EstrategiasDelBorrachoContexto.Comportamiento.HacerCaraDeGalan);

        }
    }
}
