using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Service
{
    public class UsuarioService
    {
        public void actualizar(Usuario user)
        {
            accesoDatos datos = new accesoDatos();
            try
            {
                datos.setearConsulta("Update USERS set urlImagenPerfil = @urlImagenPerfil, nombre = @nombre, apellido = @apellido where Id = @id");
                //datos.setearParametro("@imagen", user.ImagenPerfil != null ? user.ImagenPerfil : (object)DBNull.Value);
                datos.setearParametro("@urlImagenPerfil",(object)user.ImagenPerfil ?? DBNull.Value);
                //datos.setearParametro("@urlImagenPerfil", user.ImagenPerfil != null ? user.ImagenPerfil : "");
                datos.setearParametro("@nombre", user.Nombre);
                datos.setearParametro("@apellido", user.Apellido);
                datos.setearParametro("@id", user.Id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //DATOS QUE TENGO:
        //ID
        //EMAIL
        //PASS
        //ADMIN FALSE

        //DATOS QUE NO:
        //NOMBRE, APELLIDO, FECHA, IMG

        public int insertarNuevo(Usuario nuevo)
        {
            accesoDatos datos = new accesoDatos();
            try
            {
                datos.setearProcedimiento("insertarNuevo");
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@pass", nuevo.Pass);
                return datos.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public bool Login(Usuario usuario)
        {
            accesoDatos datos = new accesoDatos();
            try
            {
                datos.setearConsulta("Select id, email, pass, admin, urlImagenPerfil, nombre, apellido from USERS where email = @email And pass = @pass");
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Pass);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["id"];
                    usuario.Admin = (bool)datos.Lector["admin"];

                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        usuario.ImagenPerfil = (string)datos.Lector["urlImagenPerfil"];

                    if (!(datos.Lector["nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        usuario.Apellido = (string)datos.Lector["apellido"];

                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
