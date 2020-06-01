using Preparcial.Controlador;
using Preparcial.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preparcial.Vista
{
    public partial class FrmPassword : Form
    {
        public FrmPassword()
        {
            InitializeComponent();
        }

        private void FrmPassword_Load(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Image.FromFile("../../Recursos/UCA.png");
            //alinear correctamente el codigo de la linea 26 a la 50
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            ActualizarControlers();
        }

        private void ActualizarControlers()
        {
            // inicializar el DataSource en null
            // asignar primero el ValueMember, luego DisplayMember, y por ultimo el DataSource
            comboBox1.DataSource = null;
            comboBox1.ValueMember = "Contrasena";
            comboBox1.DisplayMember = "Nombre";
            comboBox1.DataSource = ControladorUsuario.GetUsuarios();
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (txtOldPassword.Text.Equals(comboBox1.SelectedValue.ToString()))
        {       
            var obtenerUsuario = (Usuario)comboBox1.SelectedItem;
                //primero ActualizarContrasena y despues ActualizarControlers() 
                ControladorUsuario.ActualizarContrasena(obtenerUsuario.IdUsuario,
                txtNewPassword.Text);
                ActualizarControlers();
        }
        else
            MessageBox.Show("Contrasena actual incorrecta");
        }
    }
}
