using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Service;

namespace Catalogo_Web
{
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Seguridad.esAdmin(Session["usuario"]))
            {
                Session.Add("error", "Se requieren permisos de admin para acceder");
                Response.Redirect("Error.aspx");
            }

            if (!IsPostBack)
            {
                ArticuloService service = new ArticuloService();
                Session.Add("ListaArticulos", service.listarConSP());
                dgvArticulos.DataSource = Session["ListaArticulos"];
                dgvArticulos.DataBind();
            }

        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("DetalleArticulo.aspx?id=" + id);
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
        }
        
    }
}