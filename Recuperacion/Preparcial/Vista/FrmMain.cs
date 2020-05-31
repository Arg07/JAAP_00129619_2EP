using Preparcial.Modelo;
using Preparcial.Controlador;
using System.Windows.Forms;
using System.Linq;
using System;

namespace Preparcial.Vista
{
    //Le di la propiedad fill al Tabcontrol desde la vista disenio para que se ajuste al form
    public partial class FrmMain : Form
    {
        //inicializar el objeto y renombrarlo
        private Usuario U = new Usuario();

        public FrmMain(Usuario u)
        {
            InitializeComponent();
            this.U = u;
        }
        // crear el metodo del evento FrmMain_Load para cargar las DGV y otros elementos
        private void FrmMain_Load(object sender, EventArgs e)
        {
            ActualizarCrearUsuario();
            ActualizarInventario();
            ActualizarOrdenes();
            ActualizarOrdenesUsuario();
        }

        private void bttnCreateUser_Click(object sender, EventArgs e)
        {
            //agregar bloque de sentencias else
            if (!txtNewUser.Text.Equals(""))
            {
                ControladorUsuario.CrearUsuario(txtNewUser.Text);
                ActualizarCrearUsuario();
            }
            else
                MessageBox.Show("No puede dejar el campo vacio", "error");
        }

        private void ActualizarCrearUsuario()
        {
            dgvCreateUser.DataSource = ControladorUsuario.GetUsuariosTable();
        }

        private void ActualizarInventario()
        {
            dgvInventary.DataSource = ControladorInventario.GetProductosTable();
        }

        private void ActualizarOrdenes()
        {
            dgvAllOrders.DataSource = ControladorPedido.GetPedidosTable();
        }

        private void ActualizarOrdenesUsuario()
        {
            //nombrar el ValueMember correctamente
            //inicializar el DataSource de cmbProductMakeOrder en null

            dgvMyOrders.DataSource = ControladorPedido.GetPedidosUsuarioTable(U.IdUsuario);

            cmbProductMakeOrder.DataSource = null;
            cmbProductMakeOrder.ValueMember = "idArticulo";
            cmbProductMakeOrder.DisplayMember = "producto";
            cmbProductMakeOrder.DataSource = ControladorInventario.GetProductos();
        }

        private void bttnAddInventary_Click(object sender, EventArgs e)
        {
            // cambiar operadores && por || para que valide que ningun campo este vacio
            if (txtProductNameInventary.Text.Equals("") ||
                txtDescriptionInventary.Text.Equals("") ||
                txtPriceInventary.Text.Equals("") ||
                txtStockInventary.Text.Equals(""))
                MessageBox.Show("No puede dejar campos vacios");
            else
            {
                //comvertir a entero txtStockInventary.Text
                int stock = Convert.ToInt32(txtStockInventary.Text);
                ControladorInventario.AnadirProducto(txtProductNameInventary.Text, txtDescriptionInventary.Text,
                    txtPriceInventary.Text, stock);
                ActualizarInventario();
            }
        }

        private void bttnDeleteInventary_Click(object sender, EventArgs e)
        {
            if(txtDeleteInventary.Text.Equals(""))
                MessageBox.Show("No puede dejar campos vacios");
            else
            {
                //convertir txtDeleteInventary.Text a entero
                int id = Convert.ToInt32(txtDeleteInventary.Text);
                ControladorInventario.EliminarProducto(id);
                ActualizarInventario();
            }
        }

        private void bttnUpdateStockInventary_Click(object sender, EventArgs e)
        {
            if (txtUpdateStockIdInventary.Text.Equals("") && txtUpdateStockInventary.Text.Equals(""))
                MessageBox.Show("No puede dejar campos vacios");
            else
            {
                //convertir txtUpdateStockIdInventary.Text y txtUpdateStockInventary.Text a entero
                int id = Convert.ToInt32(txtUpdateStockIdInventary.Text);
                int stock = Convert.ToInt32(txtUpdateStockInventary.Text);
                ControladorInventario.ActualizarProducto(id, stock);
                ActualizarInventario();
            }
        }

        private void bttnMakeOrder_Click(object sender, EventArgs e)
        {
            if (txtMakeOrderQuantity.Text.Equals(""))
                MessageBox.Show("No puede dejar campos vacios");
            else
            {
                //convertir a entero los parametros dados al metodo
                int Idproduct = Convert.ToInt32(cmbProductMakeOrder.SelectedValue.ToString());
                int Quantity = Convert.ToInt32(txtMakeOrderQuantity.Text);
                ControladorPedido.HacerPedido(U.IdUsuario, Idproduct, Quantity);
                ActualizarOrdenesUsuario();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name.Equals("createNewUserTab") && U.Admin)
                ActualizarCrearUsuario();

            else if (tabControl1.SelectedTab.Name.Equals("inventaryTab") && U.Admin)
                ActualizarInventario();

            else if (tabControl1.SelectedTab.Name.Equals("createOrderTab") && !U.Admin)
                ActualizarOrdenesUsuario();

            else if (tabControl1.SelectedTab.Name.Equals("viewOrdersTab") && U.Admin)
                ActualizarOrdenes();
            
            else
            {
                MessageBox.Show("No tiene permisos para ver esta pestana");
                tabControl1.SelectedTab = tabControl1.TabPages[0];
            }

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
