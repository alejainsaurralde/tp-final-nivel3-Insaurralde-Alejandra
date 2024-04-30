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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario user = new Usuario();
                UsuarioService usuarioService = new UsuarioService();
                EmailService emailService = new EmailService();

                user.Email = txtEmail.Text;
                user.Pass = txtPassword.Text;
                user.Id = usuarioService.insertarNuevo(user);
                Session.Add("usuario", user);

                Response.Redirect("MiPerfil.aspx", true);

                emailService.armarCorreo(user.Email, "Bienvenida usuario", "Hola! Te damos la bienvenida a la aplicacion...");
                emailService.enviarEmail();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}