using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UtilityChat.Models.WS;
using ChatWS.Models;


namespace ChatWS.Controllers
{
    public class RoomController : BaseController
    {
        [HttpPost]
        public Reply List([FromBody]SecurityRequest model)
        {
            Reply oReply = new Reply();
            oReply.result = 0;
            if (!VerifyToken(model))
            {
                oReply.message = "Acceso no permitido, no tiene autorización";
                return oReply;
            }

            using (ChatDBEntities db = new ChatDBEntities())
            {
                // se buscan todas las salas (room) que tengan estado 1 y se agregan a una lista tipo Room
                List<ListRoomsResponse> lstRoomsResponse = (from d in db.room
                                              where d.idState == 1
                                              orderby d.name
                                              select new ListRoomsResponse
                                              {
                                                  Name = d.name,
                                                  Description = d.description,
                                                  Id = d.id
                                              }).ToList();

                oReply.message = "Acceso autorizado";
                oReply.data = lstRoomsResponse;
            }

            oReply.result = 1;
            return oReply; 
        }
    }
}
