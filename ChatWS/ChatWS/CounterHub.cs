using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ChatWS.Models;
using UtilityChat.Models.WS;

namespace ChatWS
{
    public class CounterHub : Hub
    {
        public override Task OnConnected()
        {
            Clients.All.enterUser();

            return base.OnConnected();
        }

        // agrupar las conecciones según salas a medida que se ingresa a una de ellas
        // el id de la sala crea un grupo
        public void AddGroup(int idRoom)
        {
            Groups.Add(Context.ConnectionId, idRoom.ToString());
        }



        public void Send(int idRoom, string userName, int idUser, string message, string AccessToken)
        {
            if (VerifyToken(AccessToken))
            {
                string fecha = DateTime.Now.ToString();

                using (ChatDBEntities db = new ChatDBEntities())
                {
                    // se puede instancia un clase del modelo de la base de datos 
                    // para contener los datos agrabar
                    var oMessage = new message();
                    oMessage.date_created = DateTime.Now;
                    oMessage.idRoom = idRoom;
                    oMessage.idState = 1;
                    oMessage.text = message;
                    oMessage.idUser = idUser;
                    db.message.Add(oMessage);
                    db.SaveChanges();
                }

                // envia el mensajes a todas las conecciones
                //Clients.All.sendChat(userName, message, fecha, idUser);

                // envia el mensaje sólo al grupo al cual ha ingresado el usurio

                
                Clients.Group(idRoom.ToString()).sendChat(userName, message, fecha, idUser);

            }
  
        }

        public bool VerifyToken(string AccessToken)
        {
            using (ChatDBEntities db = new ChatDBEntities())
            {
                var oUser = db.User.Where(d => d.access_token == AccessToken).FirstOrDefault();

                if (oUser == null)
                    return false;
            }
            return true;
        }
    }
}