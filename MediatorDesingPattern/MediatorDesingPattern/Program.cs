using System;

namespace MediatorDesingPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();

            // creando colegas
            Colleague oUserPepe = new User(mediator);
            Colleague oAdminJose = new UserAdmin(mediator);

            // agregando colegas al mediador

            mediator.Add(oUserPepe);
            mediator.Add(oAdminJose);

            oUserPepe.Communicate("Oye Admin tengo un problema");

        }
    }
}
