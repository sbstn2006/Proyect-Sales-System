using capaentidad;
using CapaNegocio;
using capapresentacion.Utilidades;
using ClosedXML.Excel;
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
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }
        
        private void frmProducto_Load(object sender, EventArgs e)
        {
            dgvdata.RightToLeft = RightToLeft.No;

            //opciones del combobox estado
            cboEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Inactivo" });
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;

            List<CATEGORIA> listaCategoria = new CN_CATEGORIA().Listar();

            foreach (CATEGORIA item in listaCategoria)
            {
                cboCategoria.Items.Add(new OpcionCombo() { Valor = item.idCATEGORIA, Texto = item.Descripcion });
            }
            cboCategoria.DisplayMember = "Texto";
            cboCategoria.ValueMember = "Valor";
            cboCategoria.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            //mostrar todos los productos
            List<PRODUCTO> lista = new CN_PRODUCTO().Listar();

            foreach (PRODUCTO item in lista)
            {
                dgvdata.Rows.Add(new object[] {"",
                    item.idPRODUCTO,
                    item.Codigo,
                    item.Nombre,
                    item.Descripcion,
                    item.oCATEGORIA.idCATEGORIA,
                    item.oCATEGORIA.Descripcion,
                    item.Stock,
                    item.PrecioCompra,
                    item.PrecioVenta,
                item.Estado == true ?1 : 0,
                item.Estado == true ? "Activo" : "Inactivo"

                });
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            PRODUCTO obj = new PRODUCTO()
            {

                idPRODUCTO = Convert.ToInt32(txtid.Text),
                Codigo = txtCodigo.Text,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                oCATEGORIA = new CATEGORIA() { idCATEGORIA = Convert.ToInt32(((OpcionCombo)cboCategoria.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((OpcionCombo)cboEstado.SelectedItem).Valor) == 1 ? true : false

            };
            if (obj.idPRODUCTO == 0)
            {

                int idgenerado = new CN_PRODUCTO().Registrar(obj, out mensaje);

                if (idgenerado != 0)
                {

                    dgvdata.Rows.Add(new object[] {
                        "",
                        idgenerado,
                        txtCodigo.Text,
                        txtNombre.Text,
                        txtDescripcion.Text,
                      ((OpcionCombo) cboCategoria.SelectedItem).Valor.ToString(),
                      ((OpcionCombo) cboCategoria.SelectedItem).Texto.ToString(),
                      "0",
                      "0.00",
                      "0.00",
                      ((OpcionCombo) cboEstado.SelectedItem).Valor.ToString(),
                      ((OpcionCombo) cboEstado.SelectedItem).Texto.ToString()


                    });
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool resultado = new CN_PRODUCTO().Editar(obj, out mensaje);
                if (resultado)
                {

                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["id"].Value = txtid.Text;
                    row.Cells["Codigo"].Value = txtCodigo.Text;
                    row.Cells["Nombre"].Value = txtNombre.Text;
                    row.Cells["Descripcion"].Value = txtDescripcion.Text;
                    row.Cells["idCategoria"].Value = ((OpcionCombo)cboCategoria.SelectedItem).Valor.ToString();
                    row.Cells["Categoria"].Value = ((OpcionCombo)cboCategoria.SelectedItem).Texto.ToString();
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cboEstado.SelectedItem).Texto.ToString();

                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }


        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtCodigo.Text = "0";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            cboCategoria.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;

            txtCodigo.Select();
        } //metodo para limpiar los datos de usuario cuando se guarde un nuevo usuario

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

                e.Graphics.DrawImage(Properties.Resources.check20, new Rectangle(x, y, w, h));
                e.Handled = true;

            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {

                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvdata.Rows[indice].Cells["id"].Value.ToString();

                    txtCodigo.Text = dgvdata.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtNombre.Text = dgvdata.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtDescripcion.Text = dgvdata.Rows[indice].Cells["Descripcion"].Value.ToString();
                    

                    foreach (OpcionCombo oc in cboCategoria.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["idCategoria"].Value))
                        {
                            int indice_combo = cboCategoria.Items.IndexOf(oc);

                            cboCategoria.SelectedIndex = indice_combo;

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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Deseas eliminar el producto?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;
                    PRODUCTO obj = new PRODUCTO()
                    {
                        idPRODUCTO = Convert.ToInt32(txtid.Text),
                    };


                    bool respuesta = new CN_PRODUCTO().Eliminar(obj, out mensaje);

                    if (respuesta)
                    {
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    Limpiar();
                }
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

        private void btnLimpiarDatos_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvdata.Rows.Count < 1)
            {

                MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();


                foreach (DataGridViewColumn columna in dgvdata.Columns) {
                    if (columna.HeaderText != "" && columna.Visible)
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                }

                foreach (DataGridViewRow row in dgvdata.Rows) {
                    if (row.Visible)
                        dt.Rows.Add(new object[] {

                            row.Cells[2].Value.ToString(),
                            row.Cells[3].Value.ToString(),
                            row.Cells[4].Value.ToString(),
                            row.Cells[6].Value.ToString(),
                            row.Cells[7].Value.ToString(),
                            row.Cells[8].Value.ToString(),
                            row.Cells[9].Value.ToString(),
                            row.Cells[11].Value.ToString()


                        });


                }
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReporteProducto_{0}.xslx",DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "Excel Files | *.xlsx";

                    if (savefile.ShowDialog() == DialogResult.OK) {

                       try
                       {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte Generado", "Mensaje",MessageBoxButtons.OK, MessageBoxIcon.Information);

                       }
                       catch
                       {
                        MessageBox.Show("Error al generar reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                       }

                    }


            }
        }
    }
}
