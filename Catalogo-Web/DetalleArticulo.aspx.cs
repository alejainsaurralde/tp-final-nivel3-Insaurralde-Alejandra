using Dominio;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Catalogo_Web
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //inhabilita el id
            txtId.Enabled = false;
            try
            {
                //Configuracion inicial
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

                //Configuracion si estamos MODIFICANDO
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ArticuloService service = new ArticuloService();
                    //List<Articulo> lista = service.Listar(id);
                    //Articulo seleccionado = lista[0];
                    Articulo seleccionado = service.Listar(id)[0];


                    //Guardo articulo seleccionado en la session
                    Session.Add("articuloSeleccionado", seleccionado);

                    //Pre cargar todos los campos...

                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtImagenUrl.Text = seleccionado.ImagenUrl;
                    //txtPrecio.Text = seleccionado.Precio;

                    //Precarga de desplegables seleccionado

                    //RESOLVER LA PRECARGA DE DATOS DEL DESPLEGABLE
                    ddlMarca.SelectedItem.Text = seleccionado.Marca.ToString();
                    ddlCategoria.SelectedItem.Text= seleccionado.Categoria.ToString();

                    //Forzar a la imagen a cargar
                    txtImagenUrl_TextChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }
       
    }
}
