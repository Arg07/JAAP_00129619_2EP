using System;
using System.Data;
using System.Windows.Forms;

namespace Preparcial.Controlador
{
    public static class ControladorPedido
    {
        //el metodo debe recibir un entero no un string
        public static DataTable GetPedidosUsuarioTable(int id)
        {
            DataTable pedidos = null;

            try
            {
                //salto de linea - buenas practicas
                pedidos = ConexionBD.EjecutarConsulta("SELECT p.idPedido, i.nombreArticulo," +
                                            " p.cantidad, i.precio, (i.precio * p.cantidad) AS total" +
                                            " FROM PEDIDO p, INVENTARIO i, USUARIO u" +
                                            " WHERE p.idArticulo = i.idArticulo" +
                                            " AND p.idUsuario = u.idUsuario" +
                                            $" AND u.idUsuario = {id}");
            }
            catch (Exception ex)
            {
                /* darle un uso a ex para conocer el error o excepcion sin mostrar 
                                detalles importantes del programa*/
                MessageBox.Show("Ha ocurrido un error " + ex.Message);
            }

            return pedidos;
        }

        public static DataTable GetPedidosTable()
        {
            DataTable pedidos = null;

            try
            {
                //salto de linea - buenas practicas
                pedidos = ConexionBD.EjecutarConsulta("SELECT p.idPedido, i.nombreArticulo, " +
                                            "p.cantidad, i.precio, (i.precio * p.cantidad) AS total" +
                                            " FROM PEDIDO p, INVENTARIO i, USUARIO u" +
                                            " WHERE p.idArticulo = i.idArticulo" +
                                            " AND p.idUsuario = u.idUsuario");
            }
            catch (Exception ex)
            {
                /* darle un uso a ex para conocer el error o excepcion sin mostrar 
                                detalles importantes del programa*/
                MessageBox.Show("Ha ocurrido un error " + ex.Message);
            }

            return pedidos;
        }

        //el metodo debe recibir enteros no un string
        public static void HacerPedido(int idUsuario, int idArticulo, int cantidad)
        {
            try
            {
                ConexionBD.EjecutarComando("INSERT INTO PEDIDO(idUsuario, idArticulo, cantidad) " +
                    $"VALUES({idUsuario}, {idArticulo}, {cantidad})");
            }
            catch (Exception ex)
            {
                /* darle un uso a ex para conocer el error o excepcion sin mostrar 
                                detalles importantes del programa*/
                MessageBox.Show("Ha ocurrido un error " + ex.Message);
            }
        }
    }
}
