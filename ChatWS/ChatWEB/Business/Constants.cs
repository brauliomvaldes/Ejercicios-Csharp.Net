using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ChatWEB.Business
{
    public class Constants
    {
        public static string URI_API
        {
            get
            {
                return ConfigurationManager.AppSettings["url_ws"];
            }
        }

        public class Url
        {
            public static string REGISTER
            {
                get
                {
                    return URI_API + "api/user/";
                }
            }
            public static string SIGNALR
            {
                get
                {
                    return URI_API + "signalr/";
                }
            }
            public static string SIGNALRHUB
            {
                get
                {
                    return URI_API + "signalr/hubs";
                }
            }
            public static string ROOMS
            {
                get
                {
                    return URI_API + "api/room/";
                }
            }
            public static string ACCESS
            {
                get
                {
                    return URI_API + "api/access/";
                }
            }
            public static string MESSAGES
            {
                get
                {
                    return URI_API + "api/messages/";
                }
            }
        }
    }
}