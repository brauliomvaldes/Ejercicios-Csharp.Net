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
    // controlador base que se utiliza para que todos los controler consulten si el usaurio tiene acceso
    // podria contener métodos y atributos adicioanes que podrian ser útiles si se requiere
    public class BaseController : ApiController
    {
        // para almacenar atributos que podrian ser de utilidad a futuro
         public UserResponse oUserSession;
        // poner acceso public a protected para evitar conflictos al momento de ser llamados por controladores hijos
        protected bool VerifyToken(SecurityRequest model)
        {
           
            using (ChatDBEntities db = new ChatDBEntities())
            {
                // consulta si el modelo recibido contiene el token almacena en DB para ser autorizado
                var oUser = db.User.Where(d => d.access_token == model.AccessToken).FirstOrDefault();
                if (oUser != null)
                {

                    // atributos que podrian ser de utilidad a futuro
                    oUserSession = new UserResponse();
                        
                    oUserSession.AccessToker = oUser.access_token;
                    oUserSession.Name = oUser.name;
                    oUserSession.City = oUser.city;
                    oUserSession.Id = oUser.id;

                    return true;
                }
            }
            return false;
        }
    }
}
