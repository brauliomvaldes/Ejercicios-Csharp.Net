using ChatWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UtilityChat.Models.WS;

namespace ChatWS.Controllers
{
    public class MessagesController : BaseController
    {
        [HttpPost]
        public Reply Get([FromBody] MessagesRequest model)
        {
            Reply oReply = new Reply();
            oReply.result = 0;

            if (!VerifyToken(model))
            {
                oReply.message = "No esta autorizado";
                return oReply;
            }

            
            try
            {
                using (ChatDBEntities db = new ChatDBEntities())
                {
                    List<MessagesResponse> lst = (from m in db.message.ToList()
                                                where m.idState == 1
                                                orderby m.date_created descending
                                                select new MessagesResponse
                                                {
                                                    Message = m.text,
                                                    Id = m.id,
                                                    IdUser = m.idUser,
                                                    UserName = m.User.name,
                                                    DateCreated = m.date_created,
                                                    TypeMessage = (
                                                       new Func<int>(
                                                        () => {
                                                            try
                                                            {
                                                                if (m.idUser == oUserSession.Id)
                                                                    return 1;
                                                                else
                                                                    return 2;
                                                            }
                                                            catch
                                                            {
                                                                return 2;
                                                            }
                                                        }
                                                        )()
                                                    )
                                                }).Take(20).ToList();
                    oReply.result = 1;
                    oReply.data = lst;
                   
                }
            }
            catch  
            {
                oReply.message = "Ocurrio un error";
            }




            return oReply;
        }
    }
}
