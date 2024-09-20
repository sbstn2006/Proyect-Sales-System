using capaentidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capapresentacion
{
    public partial class frmNegocio : Form
    {
        public frmNegocio()
        {
            InitializeComponent();
        }



        public Image ByteToImage(byte[] imageBytes) {
            MemoryStream ms = new MemoryStream();
            ms.Write(imageBytes,0,imageBytes.Length);
            Image image = new Bitmap(ms);

            return image;

        }

        private void frmNegocio_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] byteimage = new CN_NEGOCIO().ObtenerLogo(out obtenido);

            if (obtenido) 
                picLogo.Image = ByteToImage(byteimage);

            NEGOCIO datos = new CN_NEGOCIO().ObtenerDatos();

            txtNombreNegocio.Text = datos.Nombre;
            txtRUC.Text = datos.RUC;
            txtDireccion.Text = datos.Direccion;

        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.FileName = "Files|*.jpg;*.jpeg;*.png";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK) {
                byte[] byteimage = File.ReadAllBytes(oOpenFileDialog.FileName);
                bool respuesta = new CN_NEGOCIO().ActualizarLogo(byteimage, out mensaje);

                if (respuesta)
                    picLogo.Image = ByteToImage(byteimage);
                else
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            NEGOCIO obj = new NEGOCIO()
            {

                Nombre = txtNombreNegocio.Text,
                RUC = txtRUC.Text,
                Direccion = txtDireccion.Text

            };

            bool respuesta = new CN_NEGOCIO().GuardarDatos(obj, out mensaje);

            if (respuesta) 

                MessageBox.Show("Los cambios fueron guardados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudieron guardar los cambios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
