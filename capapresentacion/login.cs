using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;
using capaentidad;
    

namespace capapresentacion
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            {

                List<USUARIO> TEST = new CN_USUARIO().Listar();


                USUARIO oUSUARIO = new CN_USUARIO().Listar().Where(u => u.Documento == txtdocumento.Text
                && u.Clave == txtclave.Text).FirstOrDefault();

                if (oUSUARIO != null)
                {

                    Inicio form = new Inicio(oUSUARIO);

                    form.Show();
                    this.Hide();

                    form.FormClosing += frm_closing;

                }
                else {

                    MessageBox.Show("Usuario o contraseña invalida, intenta nuevamente","mensaje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }

                
            }

        }


        private void frm_closing(object sender, FormClosingEventArgs e) {


            txtdocumento.Text = "";
            txtclave.Text = "";
            this.Show();

        }
    }
}
