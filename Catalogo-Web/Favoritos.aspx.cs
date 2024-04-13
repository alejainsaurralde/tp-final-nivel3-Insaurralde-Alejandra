﻿using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

            if (!IsPostBack)
            {
                ArticuloService service = new ArticuloService();
                Session.Add("listaArticulos", service.listarConSP());
                dgvArticulos.DataSource = Session["listaArticulos"];
                dgvArticulos.DataBind();
            }
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo.aspx?id=" + id);
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

    }
}