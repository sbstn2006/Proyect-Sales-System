using capaentidad;
using CapaNegocio;
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
    public partial class frmDetalleVenta : Form
    {
        public frmDetalleVenta()
        {
            InitializeComponent();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            VENTA oVenta = new CN_VENTA().ObtenerVenta(txtbusqueda.Text);

            if (oVenta.idVENTA != 0)
            {
                txtbusqueda.Text = oVenta.NumeroDocumento;

                txtFecha.Text = oVenta.FechaRegistro;
                txtTipoDocumento.Text = oVenta.TipoDocumento;
                txtUsuario.Text = oVenta.oUSUARIO.NombreCompleto;


                txtDocumentoCliente.Text = oVenta.DocumentoCliente;
                txtNombreCliente.Text = oVenta.NombreCliente;

                dgvdata.Rows.Clear();
                foreach (DETALLE_VENTA dv in oVenta.oDETALLE_VENTA)
                {
                    dgvdata.Rows.Add(new object[] { dv.oPRODUCTO, dv.PrecioVenta, dv.Cantidad, dv.SubTotal });
                }

                txtMontoTotal.Text = oVenta.MontoTotal.ToString("0,00");
                txtMontoPago.Text = oVenta.MontoPago.ToString("0,00");
                txtMontoCambio.Text = oVenta.MontoCambio.ToString("0,00");
            }
        }
    }
}
