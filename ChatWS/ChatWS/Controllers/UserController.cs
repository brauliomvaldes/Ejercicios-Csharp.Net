using ChatWS.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UtilityChat.Models.WS;

namespace ChatWS.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public Reply Get()
        {
            Reply oReply = new Reply();
            using (Models.ChatDBEntities db = new Models.ChatDBEntities()) 
            {

                List<UserViewModel> lst = (from d in db.User
                                           select new UserViewModel
                                           {
                                               Name = d.name,
                                               City = d.city
                                           }).ToList();
                oReply.message = "Registros de usuarios";
                oReply.result = 1;
                oReply.data = lst;
            }
            return oReply;
        }

        [HttpPost]
        public Reply Register([FromBody] Models.Request.User model) 
        {
            Reply oReply = new Reply();
            try
            {
                using (Models.ChatDBEntities db = new Models.ChatDBEntities())
                {

                    //crear objeto user para recibir los datos dentro del modelo recibido
                    Models.User oUser = new Models.User();

                    //traspasar los datos recibidos a la clase para su registro
                    oUser.name = model.Name;
                    oUser.email = model.Email;
                    oUser.password = model.Password;
                    oUser.city = model.City;
                    oUser.date_created = DateTime.Now;
                    oUser.idState = 1;
                    //agregamos el objeto a la entidad user
                    db.User.Add(oUser);
                    //guardamos el registro en la db
                    db.SaveChanges();
                    oReply.message = "Registro exitoso";
                    oReply.result = 1;
                    oReply.data = oUser;
                }
            }
            catch 
            {
                oReply.message = "Registro fallido, intenta nuevamente";
                oReply.result = 0;

                // log
            }   
                return oReply;
        }
    }
}
