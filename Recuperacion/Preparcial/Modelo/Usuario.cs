using System;

namespace Preparcial.Modelo
{
    public class Usuario
    {
        //cambiar String en vez de string y saltos de lineas inecesarios
        // el IdUsuario deberia ser entero
        public int IdUsuario { get; set; }
        public String NombreUsuario { get; set; }
        public String Contrasena { get; set; }
        public bool Admin { get; set; }

        // correcion del constructor para permitir declarar objetos vacios de esta entidad
        public Usuario(int idUsuario = 0, String nombreUsuario = "",
            String contrasenia = "", bool admin = false)
        {
            IdUsuario = idUsuario;
            NombreUsuario = nombreUsuario;
            Contrasena = contrasenia;
            Admin = admin;
        }
    }
}
