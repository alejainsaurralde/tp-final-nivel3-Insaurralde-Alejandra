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
                datos.setearConsulta("Select id, email, pass, admin from USERS where email = @email And pass = @pass");
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Pass);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["id"];
                    usuario.Admin = (bool)datos.Lector["admin"];    
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
