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
    }
}
