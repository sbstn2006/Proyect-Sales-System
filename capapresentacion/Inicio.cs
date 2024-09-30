using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

using capaentidad;

using CapaNegocio;

namespace capapresentacion
{
    public partial class Inicio : Form
    {

        private static USUARIO USUARIOActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;


        public Inicio(USUARIO objUSUARIO = null)
        {
            if (objUSUARIO == null)
                USUARIOActual = new USUARIO() { NombreCompleto = "ADMIN sin inicio", idUSUARIO = 1 };
            else
                USUARIOActual = objUSUARIO;

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            List<PERMISO> ListaPermisos = new CN_PERMISO().Listar(USUARIOActual.idUSUARIO);
            
            foreach (IconMenuItem iconmenu in barra.Items)
            {
                bool encontrado = ListaPermisos.Any(m => m.NombreMenu == iconmenu.Name);
                if (encontrado == false)
                {
                    iconmenu.Visible = false; 
                }
            }


            lblusuario.Text = USUARIOActual.NombreCompleto;



        }

        private void iconMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void menuusuarios_Click(object sender, EventArgs e)
        {

        }


        private void iconMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmReportes());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MenuCompras_Click(object sender, EventArgs e)
        {

        }

        private void MenuReportes_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void AbrirFormulario(IconMenuItem menu, Form formulario ) {
            if (MenuActivo != null) {

                MenuActivo.BackColor = Color.White;

            }
            menu.BackColor = Color.Silver;
            MenuActivo = menu;

            if (FormularioActivo != null) {
                FormularioActivo.Close();
            }


            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.LightSteelBlue;

            contenedor.Controls.Add(formulario);
            formulario.Show();



        }



        private void MenuUsuarios_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmUsuarios());
        }

        private void iconMenuItem3_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(MenuMantenedor, new frmProducto());
        }

        private void MenuMantenedor_Click(object sender, EventArgs e)
        {

        }

        private void submenucategoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(MenuMantenedor, new frmCategoria());
        }

        private void submenuregistrarventa_Click(object sender, EventArgs e)
        {
            AbrirFormulario(MenuVentas, new frmVentas(USUARIOActual));
        }

        private void submenuverdetalleventa_Click(object sender, EventArgs e)
        {
            AbrirFormulario(MenuVentas, new frmDetalleVenta());
        }

        private void submenuregistrarcompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(MenuCompras, new frmCompras(USUARIOActual));
        }

        private void submenuverdetallecompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(MenuCompras, new frmDetalleCompra());
        }

        private void Menuclientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmClientes());
        }

        private void MenuProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmProveedores());
        }

        private void submenuNegocio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(MenuMantenedor, new frmNegocio());
        }
    }
}
