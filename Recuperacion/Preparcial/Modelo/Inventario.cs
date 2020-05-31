using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparcial.Modelo
{
    public class Inventario
    {
        // Declarar atributos publicos & cambiar String en vez de string
        // Cambiar inicial de las variables a Mayúscula
        // Declarar IdArticulo y Stock como enteros
        // Completar Getter y Setter
        public int IdArticulo { get; set; }
        public String Producto { get; set; }
        public String Descripcion { get; set; }
        public String Precio { get; set; }
        public int Stock { get; set; }

        // correcion del constructor para permitir declarar objetos vacios de esta entidad
        public Inventario(int idArticulo =0, String producto = "",
            String descripcion = "", String precio = "", int stock=0)
        {
            this.IdArticulo = idArticulo;
            this.Producto = producto;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Stock = stock;
        }
    }
}
