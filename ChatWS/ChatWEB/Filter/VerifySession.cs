using ChatWEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatWEB.Filter
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                //si se intenta visitar una página sin estar logeado
                //se debe dar de alta en FilterConfig.cs en carpeta App_Start
                if (HttpContext.Current.Session["User"] == null)
                {
                    //si lapagina no es Home (porque puede optar por registrarse o legearse)
                    //lo redirige a Login
                    if(filterContext.Controller is HomeController == false)
                    {

                        // los sitios que no aparecen aquí est´n prohibidos
                        filterContext.HttpContext.Response.Redirect("Home/Login");
                    }
                }
            }
            catch 
            {

            }
        }
    }
}