using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDesingPattern
{
    public abstract class Colleague
    {
        private IMediator mediator;

        public Colleague(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IMediator Mediator
        {
            get;
        }

        public void Communicate(string message)
        {
            this.mediator.Send(message, this);
        }

        public abstract void Receive(string message);
    }
}
