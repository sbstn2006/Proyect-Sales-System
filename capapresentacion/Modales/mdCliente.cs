using capaentidad;
using CapaNegocio;
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

namespace capapresentacion.Modales
{
    public partial class mdCliente : Form
    {
        public CLIENTE _cliente {get; set;}

        public mdCliente()
        {
            InitializeComponent();
        }

        private void mdCliente_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dgvdata.Columns)
            {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = column.Name, Texto = column.HeaderText });
            }

            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedItem = 0;


            List<CLIENTE> lista = new CN_CLIENTE().Listar();

            foreach (CLIENTE item in lista)
            {
                if (item.Estado)
                    dgvdata.Rows.Add(new object[] { item.Documento, item.NombreCompleto });

            }
        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        { 
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;

            if (iRow >= 0 && iColum >= 0)
            {
                _cliente = new CLIENTE()
                {
                    Documento = dgvdata.Rows[iRow].Cells["Documento"].Value.ToString(),
                    NombreCompleto = dgvdata.Rows[iRow].Cells["NombreCompleto"].Value.ToString()

                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string columnafiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();


            if (dgvdata.Rows.Count > 0)
            {

                foreach (DataGridViewRow row in dgvdata.Rows)
                {


                    if (row.Cells[columnafiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                    {

                        row.Visible = true;
                    }
                    else
                        row.Visible = false;
                }
            }
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";

            foreach (DataGridViewRow row in dgvdata.Rows)
            {

                row.Visible = true;
            }
        }
    }
}
