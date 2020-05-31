using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparcial.Modelo
{
    public class Pedido
    {
        // Declarar los atributos como enteros
        // competar Getter y Setter
        public int IdPedido { get; set; }
        public int IdUsuario { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }

        // correcion del constructor para permitir declarar objetos vacios de esta entidad
        public Pedido(int idPedido =0, int idUsuario = 0, int idArticulo = 0, int cantidad = 0)
        {
            this.IdPedido = idPedido;
            this.IdUsuario = idUsuario;
            this.IdArticulo = idArticulo;
            this.Cantidad = cantidad;
        }
    }
}
