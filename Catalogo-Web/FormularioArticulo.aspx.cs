﻿using Dominio;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Catalogo_Web
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }

        //SUBIR LOS DROPDOWNS

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["usuario"]))
            {
                Session.Add("error", "Se requieren permisos de admin para acceder");
                Response.Redirect("Error.aspx");
            }

            //inhabilita el id
            txtId.Enabled = false;
            ConfirmaEliminacion = false;

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
                    txtPrecio.Text = seleccionado.Precio.ToString();

                    //Precarga de desplegables seleccionado

                    //NO PUDE HACERLO FUNCIONAR

                    //RESOLVER LA PRECARGA DE DATOS DEL DESPLEGABLE
                    ddlMarca.SelectedItem.Text = seleccionado.Marca.ToString();
                    ddlCategoria.SelectedValue = seleccionado.ToString();

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
                nuevo.Precio = decimal.Parse(txtPrecio.Text);


                nuevo.Marca = ddlMarca.SelectedValue.ToString();
                nuevo.Categoria = ddlCategoria.SelectedValue.ToString();

                //SI VOY A MODIFICAR.....
                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    service.modificarConSP(nuevo);
                }


                else
                    service.agregarConSP(nuevo);

                Response.Redirect("ListaArticulos.aspx", false);

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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminacion.Checked)
                {
                    ArticuloService service = new ArticuloService();
                    service.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("ListaArticulos.aspx", false);

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}