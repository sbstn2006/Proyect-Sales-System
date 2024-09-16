using System;                                                                                                       
using System.Collections.Generic;
using System.ComponentModel;                                                                                        
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using capapresentacion.Utilidades;
using capaentidad;
using CapaNegocio;



namespace capapresentacion
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }


        private void frmUsuarios_Load(object sender, EventArgs e)
            {

                dgvdata.RightToLeft = RightToLeft.No;

            //opciones del combobox estado
            cboEstado.Items.Add(new OpcionCombo() {Valor = 1 , Texto = "Activo" });
            cboEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Inactivo" });
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;

            List<ROL> listaROL = new CN_ROL().Listar();

            foreach (ROL item in listaROL)
            {
                cboRol.Items.Add(new OpcionCombo() { Valor = item.idROL, Texto = item.Descripcion });
            }
            cboRol.DisplayMember = "Texto";
            cboRol.ValueMember = "Valor";
            cboRol.SelectedIndex = 0;


            foreach (DataGridViewColumn columna in  dgvdata.Columns) {

                if (columna.Visible == true && columna.Name != "btnSeleccionar") {

                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });

                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            //mostrar todos los usuarios
            List<USUARIO> listaUSUARIO = new CN_USUARIO().Listar();

            foreach (USUARIO item in listaUSUARIO)
            {


                dgvdata.Rows.Add(new object[] {"",item.idUSUARIO, item.Documento, item.NombreCompleto, item.Correo, item.Clave,
                item.oROL.idROL,
                item.oROL.Descripcion,
                item.Estado == true ?1 : 0,
                item.Estado == true ? "Activo" : "Inactivo"

                });




            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //dgvdata.Rows.Add(new object[] {"",txtid.Text, txtDocumento.Text, txtNombreCompleto.Text, txtCorreo.Text, txtClave.Text,
            //  ((OpcionCombo) cboRol.SelectedItem).Valor.ToString(),
            //  ((OpcionCombo) cboRol.SelectedItem).Texto.ToString(),
            //  ((OpcionCombo) cboEstado.SelectedItem).Valor.ToString(),
            //  ((OpcionCombo) cboEstado.SelectedItem).Texto.ToString()
            //});
            //Limpiar(); 
        }

        //metodo para limpiar los datos de usuario cuando se guarde un nuevo usuario
        private void Limpiar() {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtDocumento.Text = "";
            txtNombreCompleto.Text = "";
            txtCorreo.Text = "";
            txtClave.Text = "";
            txtConfirmarClave.Text = "";
            cboRol.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.check20.Width;
                var h = Properties.Resources.check20.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.check20, new Rectangle(x,y,w,h));
                e.Handled = true;

            }




        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnSeleccionar") {

                int indice = e.RowIndex;


                if (indice >= 0) {

                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvdata.Rows[indice].Cells["id"].Value.ToString();
                    txtDocumento.Text = dgvdata.Rows[indice].Cells["Documento"].Value.ToString();
                    txtNombreCompleto.Text = dgvdata.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtCorreo.Text = dgvdata.Rows[indice].Cells["Correo"].Value.ToString();
                    txtClave.Text = dgvdata.Rows[indice].Cells["Clave"].Value.ToString();
                    txtConfirmarClave.Text = dgvdata.Rows[indice].Cells["Clave"].Value.ToString();

                    foreach (OpcionCombo oc in cboRol.Items) {

                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32 (dgvdata.Rows[indice].Cells["idROL"].Value)) {
                            int indice_combo = cboRol.Items.IndexOf(oc);

                            cboRol.SelectedIndex = indice_combo;

                            break;
                        }
                    }

                    foreach (OpcionCombo oc in cboEstado.Items)
                    {

                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = cboEstado.Items.IndexOf(oc);

                            cboEstado.SelectedIndex = indice_combo;

                            break;
                        }
                    }

                }


            }
        }

      
    }
}