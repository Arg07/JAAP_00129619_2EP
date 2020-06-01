using Preparcial.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Preparcial.Controlador
{
    public static class ControladorInventario
    {
        // Metodo encargado de devolver un DataTable con todos los elementos del inventario
        public static DataTable GetProductosTable()
        {
            DataTable productos = null;

            // Solamente la consulta y conexion a la BD van en el try, ya que lo demas no puede ocasionar excepcion
            try
            {
                productos = ConexionBD.EjecutarConsulta("SELECT * FROM INVENTARIO");
            }
            catch(Exception ex)
            {
                /* darle un uso a ex para conocer el error o excepcion sin mostrar 
                                detalles importantes del programa*/
                MessageBox.Show("Ha ocurrido un error " + ex.Message);
            }

            return productos;
        }

        // Metodo que devuelve los productos en formato de List
        public static List<Inventario> GetProductos()
        {
            // Declaracion de lista y DataTable
            var productos = new List<Inventario>();
            DataTable dt = null;

            try
            {
                // Consulta para llenar el DataTable
                dt = ConexionBD.EjecutarConsulta("SELECT * FROM INVENTARIO");

                // Por cada fila del DataTable, crear un nuevo producto anadiendolo a la lista
                // convertir a entero los datos de idArticulo y stock 
                foreach(DataRow dr in dt.Rows)
                {
                    productos.Add(new Inventario
                        (
                            idArticulo: Convert.ToInt32(dr[0].ToString()),
                            producto: dr[1].ToString(),
                            descripcion: dr[2].ToString(),
                            precio: dr[3].ToString(),
                            stock: Convert.ToInt32(dr[4].ToString())
                        )
                    );
                }
            }
            catch (Exception ex)
            {
                /* darle un uso a ex para conocer el error o excepcion sin mostrar 
                                detalles importantes del programa*/
                MessageBox.Show("Ha ocurrido un error " + ex.Message);
            }

            return productos;
        }

        // Metodo para anadir productos
        // cambiar a entero stock
        public static void AnadirProducto(string nombre, string descripcion, string precio, int stock)
        {
            try
            {
                ConexionBD.EjecutarComando("INSERT INTO INVENTARIO(nombreArt, descripcion, precio, stock)" +
                    $" VALUES('{nombre}', '{descripcion}', {precio}, {stock})");

                MessageBox.Show("Se ha agregado el producto");
            }
            catch (Exception ex)
            {
                /* darle un uso a ex para conocer el error o excepcion sin mostrar 
                                                detalles importantes del programa*/
                MessageBox.Show("Ha ocurrido un error " + ex.Message);
            }
        }

        // Metodo para eliminar productos
        // cambiar el tipo del parametro id que recibe a entero
        public static void EliminarProducto(int id)
        {
            /* editar el metodo porque es necesario validar que si existe un pedido realizado con el articulo
             que se desea eliminar entonces no se pueda eliminar el articulo porque lanza una excepcion
             para eso cree una nueva consulta a Pedidos para verificar y luego valida si la consulta encuentra
             registros con el id del articulo*/

            DataTable pExisting = null;
            try
            {
                pExisting = ConexionBD.EjecutarConsulta($"SELECT FROM PEDIDO WHERE idArticulo = {id}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error " + ex.Message);
            }
            if (pExisting!=null)
            {
                try
                {
                    ConexionBD.EjecutarComando($"DELETE FROM INVENTARIO WHERE idArticulo = {id}");

                    MessageBox.Show("Se ha eliminado el producto");
                }
                catch (Exception ex)
                {
                    /* darle un uso a ex para conocer el error o excepcion sin mostrar 
                                                    detalles importantes del programa*/
                    MessageBox.Show("Ha ocurrido un error " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error \n" +
                    "No puede eliminar el articulo porque existen pedidos registrados de este articulo ");
            }

        }

        // Metodo para actualizar stock de un producto
        // cambiar el tipo del parametro id y stock que recibe a entero
        public static void ActualizarProducto(int id, int stock)
        {
            try
            {
                ConexionBD.EjecutarComando($"UPDATE INVENTARIO SET stock = {stock} WHERE idArticulo = {id}");

                MessageBox.Show("Se ha actualizado el producto");
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
