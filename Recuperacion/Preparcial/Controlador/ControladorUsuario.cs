using System.Data;
using System.Collections.Generic;
using Preparcial.Modelo;
using System;
using System.Windows.Forms;

namespace Preparcial.Controlador
{
    public static class ControladorUsuario
    {
        public static List<Usuario> GetUsuarios()
        {
            var usuarios = new List<Usuario>();
            DataTable tableUsuarios = null;

            try
            {
                tableUsuarios = ConexionBD.EjecutarConsulta("SELECT * FROM USUARIO");
            }
            catch(Exception ex)
            {
                /* darle un uso a ex para conocer el error o excepcion sin mostrar 
                detalles importantes del programa*/
                MessageBox.Show("Ha ocurrido un error " + ex.Message);
            }
            foreach(DataRow dr in tableUsuarios.Rows)
            {
                //inicializar primero el objeto tipo Usuario y despues agregarlo a la lista
                //asignar que filas se almacena en que atributos del objeto
                //convertir la fila del IdUsuario a entero 
                Usuario u = new Usuario
                {
                    IdUsuario = Convert.ToInt32(dr[0].ToString()),
                    NombreUsuario = dr[1].ToString(),
                    Contrasena = dr[2].ToString(),
                    Admin = Convert.ToBoolean(dr[3].ToString())
                };
                usuarios.Add(u);
            }
            return usuarios;
        }

        public static DataTable GetUsuariosTable()
        {
            DataTable tableUsuarios = null;

            try
            {
                tableUsuarios = ConexionBD.EjecutarConsulta("SELECT * FROM USUARIO");
            }
            catch (Exception ex)
            {
                /* darle un uso a ex para conocer el error o excepcion sin mostrar 
                detalles importantes del programa*/
                MessageBox.Show("Ha ocurrido un error " + ex.Message);
            }

            return tableUsuarios;
        }

        //cambiar a entero el tipo de dato de idUsuario que recibe el metodo
        public static void ActualizarContrasena(int idUsuario, string nueva)
        {
            try
            {
                ConexionBD.EjecutarComando($"UPDATE USUARIO SET contrasenia = '{nueva}' " +
                    $"WHERE idUsuario = {idUsuario}");

                MessageBox.Show("Se ha actualizado la contrasena");
            }
            catch(Exception ex)
            {
                /* darle un uso a ex para conocer el error o excepcion sin mostrar 
                detalles importantes del programa*/
                MessageBox.Show("Ha ocurrido un error " + ex.Message);
            }
        }

        public static void CrearUsuario(String usuario)
        {
            try
            {
                ConexionBD.EjecutarComando("INSERT INTO USUARIO(nombreUsuario, contrasenia, tipo)" +
                    $" VALUES('{usuario}', '{usuario}', false)");

                MessageBox.Show("Se ha agregado el nuevo usuario, contrasenia igual al nombre");
            }
            catch(Exception ex)
            {
                /* darle un uso a ex para conocer el error o excepcion sin mostrar 
                detalles importantes del programa*/
                MessageBox.Show("Ha ocurrido un error " + ex.Message);
            }
        }
    }
}
