using ChatWEB.Business;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtilityChat;
using UtilityChat.Models.WS;

namespace ChatWEB.Controllers
{
    public class LobbyController : BaseController
    {
        // GET: Lobby
        public ActionResult Index()
        {
            //recupera session del usuario
            GetSession();

            List<ListRoomsResponse> lst = new List<ListRoomsResponse>();

            SecurityRequest oSecurityRequest = new SecurityRequest();
            oSecurityRequest.AccessToken = oUserSession.AccessToker;


            RequestUtil oRequestUtil = new RequestUtil();
            Reply oReply =
                oRequestUtil.Execute<SecurityRequest>(Constants.Url.ROOMS, "post", oSecurityRequest);

            // la deserializacion necesita un string y oReplay.data viene como objeto anónimo desde
            // la BD por lo que
            // hay que serializar primero para pasar a string

            lst = JsonConvert.DeserializeObject<List<ListRoomsResponse>>(JsonConvert.SerializeObject(oReply.data));



            return View(lst);
        }
    }
}