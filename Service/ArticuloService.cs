using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dominio;
using Service;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Service
{
      public class ArticuloService
    {
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server =.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = A.IdMarca and C.Id = A.IdCategoria";

                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader(); 
                
                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)lector["Id"];
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];

                    if (!(lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)lector["ImagenUrl"];
  
                    aux.Marca = (string)lector["Marca"];
                    aux.Categoria= (string)lector["Categoria"];
                    aux.Precio = (decimal)lector["Precio"];
                    

                    lista.Add(aux); 
                }
                
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
               
            }
         
        }

        public List<Articulo> listarConSP()
        {
            List<Articulo> lista = new List<Articulo>();
            accesoDatos datos = new accesoDatos();
            try
            {
                string consulta = "select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio, A.IdMarca, A.IdCategoria from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = A.IdMarca and C.Id = A.IdCategoria";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    //aux.Marca = (string)lector["IdMarca"];   
                    aux.Marca = (string)datos.Lector["Marca"];
                    //aux.Categoria = (string)lector["IdCategoria"];
                    aux.Categoria = (string)datos.Lector["Categoria"];
                    aux.Precio = (decimal)datos.Lector["Precio"];


                    lista.Add(aux);
                }


                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void agregar(Articulo nuevo)
        {
            accesoDatos datos = new accesoDatos();

            try
            {
                datos.setearConsulta("insert into ARTICULOS(Codigo, Nombre, Descripcion, ImagenUrl, IdMarca, IdCategoria, Precio)values('"+ nuevo.Codigo +"', '"+ nuevo.Nombre +"', '"+ nuevo.Descripcion +"', @ImagenUrl,  @IdMarca, @IdCategoria, '"+ nuevo.Precio +"')");
                datos.setearParametro("@ImagenUrl", nuevo.ImagenUrl);
                datos.setearParametro("@IdMarca",nuevo.Marca);    
                datos.setearParametro("@IdCategoria", nuevo.Categoria);           


                datos.ejecutarAccion();

            }
            catch (Exception  ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void eliminar(int Id)
        {
            try
            {
                accesoDatos datos = new accesoDatos();
                datos.setearConsulta("delete from ARTICULOS where id = @id");
                datos.setearParametro("@id", Id);
                datos.ejecutarAccion();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void modificar(Articulo articulo)
        {
            accesoDatos datos = new accesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, ImagenUrl = @imagen, IdMarca = @idMarca, IdCategoria = @idCategoria where Id = @id");
                datos.setearParametro("@codigo", articulo.Codigo);
                datos.setearParametro("@nombre", articulo.Nombre);
                datos.setearParametro("@descripcion", articulo.Descripcion);
                datos.setearParametro("@imagen", articulo.ImagenUrl);
                datos.setearParametro("@idMarca", articulo.Marca);
                datos.setearParametro("@idCategoria", articulo.Categoria);
                datos.setearParametro("@Precio", articulo.Precio);
                datos.setearParametro("@id", articulo.Id);

                datos.ejecutarAccion();




            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }

        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            accesoDatos datos = new accesoDatos();  
            try
            {
                string consulta = "select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio, A.IdMarca, A.IdCategoria from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = A.IdMarca and C.Id = A.IdCategoria And ";

                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio >" + filtro;
                            break;
                        case "Menor a":
                            consulta += "Precio <" + filtro;
                            break;
                        default:
                            consulta += "Precio =" + filtro;
                            break;
                    }

                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "A.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "A.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "A.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    //aux.Marca = (string)lector["IdMarca"];   
                    aux.Marca = (string)datos.Lector["Marca"];
                    //aux.Categoria = (string)lector["IdCategoria"];
                    aux.Categoria = (string)datos.Lector["Categoria"];
                    aux.Precio = (decimal)datos.Lector["Precio"];


                    lista.Add(aux);
                }


                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        // ELIMINAR LOGICO!!!!

        public void eliminarLogico(int Id)
        {
            try
            {
                accesoDatos datos = new accesoDatos();
                datos.setearConsulta("update ARTICULOS set x = 0 where Id = @Id");
                datos.setearParametro("@Id", Id);
                datos.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
