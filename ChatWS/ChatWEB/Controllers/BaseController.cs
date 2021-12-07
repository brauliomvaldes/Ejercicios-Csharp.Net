using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtilityChat.Models.WS;

namespace ChatWEB.Controllers
{
    public class BaseController : Controller
    {
        public UserResponse oUserSession;

        protected void GetSession()
        {
            oUserSession = (UserResponse)Session["User"];
        }
    }
}