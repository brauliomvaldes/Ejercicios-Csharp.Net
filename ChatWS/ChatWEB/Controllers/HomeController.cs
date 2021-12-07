using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtilityChat;
using UtilityChat.Models.WS;
using ChatWEB.Business;
using ChatWEB.Models.ViewModels;
using Newtonsoft.Json;

namespace ChatWEB.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            UserAccessViewModel model = new UserAccessViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(UserAccessViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            AccessRequest oAR = new AccessRequest();
            oAR.Email = model.Email;
            oAR.Password = UtilityChat.Tools.Encrypt.GetSHA256(model.Password);

            RequestUtil oRequestUtil = new RequestUtil();
            Reply oReply = 
                oRequestUtil.Execute<AccessRequest>(Constants.Url.ACCESS, "post", oAR);

            // la deserializacion necesita un string y oReplay.data viene como objeto anónimo desde
            // la BD por lo que
            // hay que serializar primero para pasar a string
            UserResponse userResponse = JsonConvert.DeserializeObject<UserResponse>(
                JsonConvert.SerializeObject(oReply.data)
                );
            

            if(oReply.result == 1)
            {
                // almacena el Token en la session
                Session["User"] = userResponse;
                return RedirectToAction("Index", "Lobby");
            }


            ViewBag.error = "Datos incorrectos, reintente nuevamente";
            // retorna el modelo para mostrar los datos ingresados y volver a intentar acceso
            return View(model);
        }


        [HttpGet]
        public ActionResult Register()
        {
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }


        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) {
                return View(model);
            }
            Models.Request.User oUser = new Models.Request.User();
            oUser.Name = model.Name;
            oUser.City = model.City;
            oUser.Password = model.Password;
            oUser.Email = model.Email;

            RequestUtil oRequestUtil = new RequestUtil();
            Reply oReply = oRequestUtil.Execute<Models.Request.User>(Constants.Url.REGISTER, "post", oUser);

            return View();
        }
    }
}