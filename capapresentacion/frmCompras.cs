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
    public partial class frmCompras : Form
    {


        private USUARIO _Usuario;

        public frmCompras(USUARIO oUSUARIO = null)
        {
            _Usuario = oUSUARIO;
            InitializeComponent();
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            //opciones del combobox tipo de documento
            cboDocumento.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cboDocumento.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });
            cboDocumento.DisplayMember = "Texto";
            cboDocumento.ValueMember = "Valor";
            cboDocumento.SelectedIndex = 0;

            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            txtidproducto.Text = "0";
            txtidproveedor.Text = "0";
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProveedor()) {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtidproveedor.Text = modal._Proveedor.idPROVEEDOR.ToString();
                    txtDocumentoProveedor.Text = modal._Proveedor.Documento;
                    txtNombreProveedor.Text = modal._Proveedor.RazonSocial;
                }
                else {

                    txtDocumentoProveedor.Select();

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
                    txtPrecioCompra.Select();
                }
                else
                {
                    txtDocumentoProveedor.Select();
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
                    txtPrecioCompra.Select();
                }
                else
                {
                    txtCodigoProducto.BackColor = Color.MistyRose;
                    txtidproducto.Text = "0";
                    txtProducto.Text = "";
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            decimal PrecioCompra = 0;
            decimal PrecioVenta = 0;
            bool producto_existe = false;

            if (int.Parse(txtidproducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!decimal.TryParse(txtPrecioCompra.Text, out PrecioCompra))
            {
                MessageBox.Show("Precio compra - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecioCompra.Select();
                return;
            }
            if (!decimal.TryParse(txtPrecioVenta.Text, out PrecioVenta))
            {
                MessageBox.Show("Precio venta - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecioCompra.Select();
                return;
            }

            foreach (DataGridViewRow fila in dgvdata.Rows)
            {
                if(fila.Cells["id"].Value.ToString() == txtidproducto.Text)
                { 
                    producto_existe = true;
                    break;
                }
            }

            if (!producto_existe)
            {
                dgvdata.Rows.Add(new object[] {
                    txtidproducto.Text,
                    txtProducto.Text,
                    PrecioCompra.ToString("0.00"),
                    PrecioVenta.ToString("0.00"),
                    txtCantidad.Value.ToString(),
                    (txtCantidad.Value * PrecioCompra).ToString("0.00")
                });

                calcularTotal();
                limpiarProducto();
                txtCodigoProducto.Select();
            }
        }

        private void limpiarProducto()
        {
            txtidproducto.Text = "0";
            txtCodigoProducto.Text = "";
            txtCodigoProducto.BackColor = Color.White;
            txtProducto.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtCantidad.Value = 1;
        }

        private void calcularTotal()
        {
            decimal total = 0;
            if (dgvdata.Rows.Count > 0)
            {

                foreach (DataGridViewRow row in dgvdata.Rows)
                    total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString());
            }
            txtTotalPagar.Text = total.ToString("0.00");
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnEliminar")
            {

                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    dgvdata.Rows.RemoveAt(indice);
                    calcularTotal();
                }
            }
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 6)
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

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;

            }
            else
            {
                if (txtPrecioCompra.Text.Trim().Length == 0 && e.KeyChar.ToString() == ",")
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

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;

            }
            else
            {
                if (txtPrecioVenta.Text.Trim().Length == 0 && e.KeyChar.ToString() == ",")
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtidproveedor.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
            }
            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingrersar productos en la compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
            }

            DataTable detalle_compra = new DataTable();

            detalle_compra.Columns.Add("idPRODUCTO", typeof(int));
            detalle_compra.Columns.Add("PrecioCompra", typeof(decimal));
            detalle_compra.Columns.Add("PrecioVenta", typeof(decimal));
            detalle_compra.Columns.Add("Cantidad", typeof(int));
            detalle_compra.Columns.Add("MontoTotal", typeof(decimal));

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                detalle_compra.Rows.Add(
                    new object[] {
                      Convert.ToInt32  (row.Cells["id"].Value.ToString()),
                      row.Cells["PrecioCompra"].Value.ToString(),
                      row.Cells["PrecioVenta"].Value.ToString(),
                      row.Cells["Cantidad"].Value.ToString(),
                      row.Cells["SubTotal"].Value.ToString()
                    });
                
            }
            int idcorrelativo = new CN_COMPRA().ObtenerCorrelativo();
            string numerodocumento = string.Format("{0:00000}", idcorrelativo);

            COMPRA oCompra = new COMPRA()
            {

                oUSUARIO = new USUARIO() { idUSUARIO = _Usuario.idUSUARIO },
                oPROVEEDOR = new PROVEEDOR { idPROVEEDOR = Convert.ToInt32(txtidproveedor.Text)},
                TipoDocumento = ((OpcionCombo) cboDocumento.SelectedItem).Texto,
                NumeroDocumento = numerodocumento,
                MontoTotal = Convert.ToDecimal(txtTotalPagar.Text)
            };
            string mensaje = string.Empty;
            bool respuesta = new CN_COMPRA().Registrar(oCompra, detalle_compra, out mensaje);

            if (respuesta)
            {
                var result = MessageBox.Show("Número de compra generado:\n" + numerodocumento + "\n\n¿Desea copiar al portpapeles?"
                    , "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    Clipboard.SetText(numerodocumento);

                    txtidproveedor.Text = "0";
                    txtDocumentoProveedor.Text = "";
                    txtNombreProveedor.Text = "";
                    dgvdata.Rows.Clear();
                    calcularTotal();

                }
                
            }
            else
            {

                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }
        }
    }
}
