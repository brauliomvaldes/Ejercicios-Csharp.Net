using System;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            EstrategiasDelBorrachoContexto oBorracho = new EstrategiasDelBorrachoContexto();

            oBorracho.Conquistar();

            oBorracho.EstablecerConquistaInvitarCerveza();

            oBorracho.Conquistar();



        }
    }
}
