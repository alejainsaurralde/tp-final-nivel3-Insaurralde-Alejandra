using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;




namespace Dominio
{
     public class Articulo
     {
        public int Id { get; set; }
        [DisplayName("Código")]
        public string Codigo { get; set; } 
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public string ImagenUrl { get; set; }
        public string Marca { get; set; }

        [DisplayName("Categoría")]
        public string Categoria { get; set; }
        public decimal Precio { get; set; }
        public int IdArticulo { get; set; }

    }
}
