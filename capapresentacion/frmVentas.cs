using capaentidad;
using CapaNegocio;
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
                    txtPrecio.Text = modal._Producto.PrecioVenta.ToString("0.00");
                    txtStock.Text = modal._Producto.Stock.ToString();
                    txtCantidad.Select();
                }
                else
                {
                    txtCodigoProducto.Select();
                }
            }
        }

        private void txtCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                PRODUCTO oProducto = new CN_PRODUCTO().Listar().Where(p => p.Codigo == txtCodigoProducto.Text && p.Estado == true).FirstOrDefault();

                if (oProducto != null)
                {
                    txtCodigoProducto.BackColor = Color.Honeydew;
                    txtidproducto.Text = oProducto.idPRODUCTO.ToString();
                    txtProducto.Text = oProducto.Nombre;
                    txtPrecio.Text = oProducto.PrecioVenta.ToString("0.00");
                    txtStock.Text = oProducto.Stock.ToString();
                    txtCantidad.Select(); 
                }
                else
                {
                    txtCodigoProducto.BackColor = Color.MistyRose;
                    txtidproducto.Text = "0";
                    txtProducto.Text = "";
                    txtPrecio.Text = "";
                    txtStock.Text = "";
                    txtCantidad.Value = 1;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal precio = 0;
            bool producto_existe = false;

            if (int.Parse(txtidproducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("Precio - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecio.Select();
                return;
            }
            if (Convert.ToInt32(txtStock.Text) < Convert.ToInt32(txtCantidad.Value.ToString()))
            {
                MessageBox.Show("La cantidad no puede ser mayor al stock", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecio.Select();
                return;
            }

            foreach (DataGridViewRow fila in dgvdata.Rows)
            {
                if (fila.Cells["id"].Value.ToString() == txtidproducto.Text)
                {
                    producto_existe = true;
                    break;
                }
            }

            if (!producto_existe)
            {
                
                bool respuesta = new CN_VENTA().RestarStock(
                   Convert.ToInt32 (txtidproducto.Text),
                   Convert.ToInt32 (txtCantidad.Value.ToString())
                    );
                if (respuesta)
                {

                    dgvdata.Rows.Add(new object[] {
                    txtidproducto.Text,
                    txtProducto.Text,
                    precio.ToString("0.00"),
                    txtCantidad.Value.ToString(),
                    (txtCantidad.Value * precio).ToString("0.00")
                });
                    CalcularTotal();
                    LimpiarProdcuto();
                    txtCodigoProducto.Select();

                }

            }
        }

        private void CalcularTotal()
        {
            decimal total = 0;

            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                    total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString());
            }
            txtTotalPagar.Text = total.ToString("0.00");
        }

        private void LimpiarProdcuto()
        {
            txtidproducto.Text = "0";
            txtCodigoProducto.Text = "";
            txtProducto.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            txtCantidad.Value = 1;
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 5)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.delete25.Width;
                var h = Properties.Resources.delete25.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.delete25, new Rectangle(x, y, w, h));
                e.Handled = true;

            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnEliminar")
            {

                int indice = e.RowIndex;

                if (indice >= 0)
                {

                    bool respuesta = new CN_VENTA().SumarStock(
                       Convert.ToInt32 (dgvdata.Rows[indice].Cells["id"].Value.ToString()),
                       Convert.ToInt32(dgvdata.Rows[indice].Cells["Cantidad"].Value.ToString()));


                    if (respuesta)
                    {
                        dgvdata.Rows.RemoveAt(indice);
                        CalcularTotal();
                    }
                }
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPrecio.Text.Trim().Length == 0 && e.KeyChar.ToString() == ",")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ",")
                    {
                        e.Handled = false;

                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtPagaCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPagaCon.Text.Trim().Length == 0 && e.KeyChar.ToString() == ",")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ",")
                    {
                        e.Handled = false;

                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void CalcularCambio()
        {

            if (txtTotalPagar.Text.Trim() == "")
            {
                MessageBox.Show("No existen productos en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            decimal pagacon;
            decimal total = Convert.ToDecimal(txtTotalPagar.Text);

            if (txtPagaCon.Text.Trim() == "")
            {
                txtPagaCon.Text = "0";
            }

            if (decimal.TryParse(txtPagaCon.Text.Trim(), out pagacon))
            {

                if (pagacon < total)
                {
                    txtCambio.Text = "0.00";
                }
                else
                {
                    decimal cambio = pagacon - total;
                    txtCambio.Text = cambio.ToString("0.00");
                }
            }
        }

        private void txtPagaCon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                CalcularCambio();
            }
        }

        private void txtPagaCon_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtDocumentoCliente.Text == "")
            {
                MessageBox.Show("Debe ingresar el documento del cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtNombreCliente.Text == "")
            {
                MessageBox.Show("Debe ingresar el Nombre del cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar productoos en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



            DataTable detalle_venta = new DataTable();

            detalle_venta.Columns.Add("idPRODUCTO", typeof(int));
            detalle_venta.Columns.Add("PrecioVenta", typeof(decimal));
            detalle_venta.Columns.Add("Cantidad", typeof(int));
            detalle_venta.Columns.Add("SubTotal",typeof(decimal));

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                detalle_venta.Rows.Add(new object[]
                {
                    row.Cells["id"].Value.ToString(),
                    row.Cells["Precio"].Value.ToString(),
                    row.Cells["Cantidad"].Value.ToString(),
                    row.Cells["SubTotal"].Value.ToString(),
                });
            }


            int idcorrelativo = new CN_VENTA().ObtenerCorrelativo();
            string numerodocumento = string.Format("{0:00000}", idcorrelativo);
            CalcularCambio();

            VENTA oventa = new VENTA()
            {

                oUSUARIO = new USUARIO() { idUSUARIO = _Usuario.idUSUARIO },
                TipoDocumento = ((OpcionCombo)cboDocumento.SelectedItem).Texto,
                NumeroDocumento = numerodocumento, 
                DocumentoCliente = txtDocumentoCliente.Text,
                NombreCliente = txtNombreCliente.Text,
                MontoPago = Convert.ToDecimal(txtPagaCon.Text),
                MontoCambio = Convert.ToDecimal(txtCambio.Text),
                MontoTotal = Convert.ToDecimal(txtTotalPagar.Text)
            };


            string mensaje = string.Empty;
            bool respuesta = new CN_VENTA().Registrar(oventa, detalle_venta, out mensaje);

            if (respuesta)
            {
                var result = MessageBox.Show("Numero de venta generacion:\n" + numerodocumento + "\n\n¿Desea copiar al portapapeles?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                    Clipboard.SetText(numerodocumento);

                txtDocumentoCliente.Text = "";
                txtNombreCliente.Text = "";
                dgvdata.Rows.Clear();
                CalcularTotal();
                txtPagaCon.Text = "";
                txtCambio.Text = "";
            }
            else
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


        }
    }
}
