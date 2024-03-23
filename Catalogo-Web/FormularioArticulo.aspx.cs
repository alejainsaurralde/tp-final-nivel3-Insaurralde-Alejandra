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
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        //SUBIR LOS DROPDOWNS
        protected void Page_Load(object sender, EventArgs e)
        {
            //inhabilita el id
            txtId.Enabled = false;

            try
            {
                if (!IsPostBack)
                {
                    MarcaService marcaService = new MarcaService();
                    CategoriaService categoriaService = new CategoriaService();
                   
                    ddlMarca.DataSource = marcaService.listar();
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    ddlCategoria.DataSource = categoriaService.listar();
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
                //redirigir a una pantalla de error
            }


        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevo = new Articulo();
                ArticuloService service = new ArticuloService();

                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.ImagenUrl = txtImagenUrl.Text;
                //nuevo.Precio = int.Parse(txtPrecio.Text);

                //DESPLEGABLES
                nuevo.Marca = ddlMarca.SelectedValue;
                nuevo.Categoria = ddlCategoria.SelectedValue;

                service.agregarConSP(nuevo);
                Response.Redirect("Default.aspx", true);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
                //Redirigir a pantalla error
            }

        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {

        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;   
        }
    }
}