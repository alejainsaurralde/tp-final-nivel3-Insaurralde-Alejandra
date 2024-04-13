using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace Catalogo_Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            string JQueryVer = "1.11.3";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/js/jquery-" + JQueryVer + ".min.js",
                DebugPath = "~/js/jquery-" + JQueryVer + ".js",
                CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".min.js",
                CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".js",
                CdnSupportsSecureConnection = true,
                LoadSuccessExpression = "window.jQuery"
            });


            //MANEJO GENERICO DE ERRORES(GLOBAL)
            //void Application_Error(object sender, EventArgs e)
            //{
            //    Exception exc = Server.GetLastError();

            //    Session.Add("error", exc.ToString());
            //    //Response.Redirect("Error.aspx");
            //    Server.Transfer("Error.aspx");

            //}



            //CÓDIGO PARA MANEJAR EN CADA PÁGINA EL ERROR

            //private void Page_Error(object sender, EventArgs e)
            //{
            //    Exception exc = Server.GetLastError();


            //    Session.Add("error", exc.ToString());
            //    //Response.Redirect("Error.aspx");
            //    Server.Transfer("Error.aspx");
            //}
        }

        //void Application_Error(object sender, EventArgs e)
        //{
        //    Exception exc = Server.GetLastError();

        //    Session.Add("error", exc.ToString());
        //    //Response.Redirect("Error.aspx");
        //    Server.Transfer("Error.aspx");

        //}
    }
}