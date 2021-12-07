using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDesingPattern
{
    public class User : Colleague
    {
        // base invoca al constructor de la clase padre
        public User(IMediator mediator) : base(mediator)
        {

        }

        public override void Receive(string message)
        {
            Console.WriteLine("Un usuario recibe un: "+message);
        }
    }
}
