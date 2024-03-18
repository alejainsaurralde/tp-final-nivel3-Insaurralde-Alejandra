using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Service;

namespace Catalogo_Web
{
    public partial class Catalogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloService service = new ArticuloService();
            dgvArticulos.DataSource = service.listarConSP();
            dgvArticulos.DataBind();

        }
    }
}