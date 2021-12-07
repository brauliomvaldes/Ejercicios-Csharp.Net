using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDesingPattern
{
    public class Mediator : IMediator
    {
        List<Colleague> colleagues;
        public Mediator()
        {
            colleagues = new List<Colleague>();
        }

        public void Add(Colleague collegue)
        {
            this.colleagues.Add(collegue);
        }

        public void Send(string message, Colleague colleage)
        {
            foreach(var c in this.colleagues)
            {
                if(colleage != c)
                {
                    colleage.Receive(message);
                }
            }
        }
    }
}
