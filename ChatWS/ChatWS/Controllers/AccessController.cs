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
    public class AccessController : ApiController
    {
        [HttpPost]
        public Reply Login(AccessRequest model)
        {
            Reply oReply = new Reply();
            UserResponse oUserResponse = new UserResponse();
            oReply.result = 0;
            using (ChatDBEntities db = new ChatDBEntities())
            {
                var oUser = (from d in db.User
                             where model.Email == d.email && model.Password == d.password
                             select d).FirstOrDefault();

                if (oUser != null)
                {
                    // se genera un Token único con la clase Guid
                    string AccessToken = Guid.NewGuid().ToString();
                    oUser.access_token = AccessToken;

                    // para modificar el campo en la DB
                    db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    oReply.result = 1;
                    oReply.message = "Acceso Garantizado";


                    oUserResponse.AccessToker = AccessToken;
                    oUserResponse.Name = oUser.name;
                    oUserResponse.City = oUser.city;
                    oUserResponse.Id = oUser.id;
                    // se envia el Token para acceder a otras páginas una vez logeado
                    oReply.data = oUserResponse;

                }
                else
                {
                    oReply.message = "Datos incorrectos";
                }
            }


            return oReply;
        }
    }
}
