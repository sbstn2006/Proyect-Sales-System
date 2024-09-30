using capaentidad;
using capapresentacion.Modales;
using capapresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace capapresentacion
{
    public partial class frmVentas : Form
    {
        private USUARIO _Usuario;


        public frmVentas(USUARIO oUSUARIO = null)
        {
            _Usuario = oUSUARIO;
            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            cboDocumento.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cboDocumento.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });
            cboDocumento.DisplayMember = "Texto";
            cboDocumento.ValueMember = "Valor";
            cboDocumento.SelectedIndex = 0;

            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtidproducto.Text = "0";

            txtPagaCon.Text = "0";
            txtCambio.Text = "0";
            txtTotalPagar.Text = "0";
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
             using (var modal = new mdCliente()) {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtDocumentoCliente.Text = modal._cliente.Documento;
                    txtNombreCliente.Text = modal._cliente.NombreCompleto;
                    txtCodigoProducto.Select();
                }
                else {

                    txtDocumentoCliente.Select();

                }

            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProducto())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtidproducto.Text = modal._Producto.idPRODUCTO.ToString();
                    txtCodigoProducto.Text = modal._Producto.Codigo;
                    txtProducto.Text = modal._Producto.Nombre;
                    txtPrecio.Text = modal._Producto.PrecioVenta.ToString("0,00");
                    txtStock.Text = modal._Producto.Stock.ToString();
                    txtCantidad.Select();
                }
                else
                {
                    txtCodigoProducto.Select();
                }
            }
        }
    }
}
