using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Catalogo_Web
{
    public partial class Favoritos : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //SI SOLO QUIERO QUE LO MANEJE ADMIN
            //if (!Seguridad.esAdmin(Session["usuario"]))
            //{
            //    Session.Add("error", "Se requieren permisos de admin para acceder");
            //    Response.Redirect("Error.aspx");
            //}
        }
    }
}