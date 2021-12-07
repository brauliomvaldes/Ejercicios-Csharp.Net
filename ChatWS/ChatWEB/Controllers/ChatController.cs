using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtilityChat;
using UtilityChat.Models.WS;
using Newtonsoft.Json;

namespace ChatWEB.Controllers
{
    public class ChatController : BaseController
    {
        // GET: Chat
        public ActionResult Messages(int id)
        {
            GetSession();

            List<MessagesResponse> lst = new List<MessagesResponse>();

            MessagesRequest oMessagesRequest = new MessagesRequest();

            oMessagesRequest.AccessToken = oUserSession.AccessToker;
            oMessagesRequest.IdRoom = id;

            RequestUtil oRequestUtil = new RequestUtil();

            Reply oReply = oRequestUtil.Execute<MessagesRequest>(ChatWEB.Business.Constants.Url.MESSAGES, "post", oMessagesRequest);

            lst = JsonConvert.DeserializeObject<List<MessagesResponse>>(JsonConvert.SerializeObject(oReply.data));

            lst = lst.OrderBy(d => d.DateCreated).ToList();

            ViewBag.idRoom = id;

            return View(lst);
        }
    }
}