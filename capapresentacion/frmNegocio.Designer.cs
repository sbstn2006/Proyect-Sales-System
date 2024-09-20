namespace capapresentacion
{
    partial class frmNegocio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Datos = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtRUC = new System.Windows.Forms.TextBox();
            this.txtNombreNegocio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSubir = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.Datos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(53, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(208, 29);
            this.label9.TabIndex = 20;
            this.label9.Text = "Datos del negocio";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(609, 512);
            this.label1.TabIndex = 19;
            // 
            // Datos
            // 
            this.Datos.BackColor = System.Drawing.Color.White;
            this.Datos.Controls.Add(this.btnGuardar);
            this.Datos.Controls.Add(this.txtDireccion);
            this.Datos.Controls.Add(this.txtRUC);
            this.Datos.Controls.Add(this.txtNombreNegocio);
            this.Datos.Controls.Add(this.label4);
            this.Datos.Controls.Add(this.label3);
            this.Datos.Controls.Add(this.label5);
            this.Datos.Controls.Add(this.btnSubir);
            this.Datos.Controls.Add(this.label2);
            this.Datos.Controls.Add(this.picLogo);
            this.Datos.Location = new System.Drawing.Point(58, 96);
            this.Datos.Name = "Datos";
            this.Datos.Size = new System.Drawing.Size(515, 220);
            this.Datos.TabIndex = 21;
            this.Datos.TabStop = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnGuardar.IconColor = System.Drawing.Color.White;
            this.btnGuardar.IconSize = 16;
            this.btnGuardar.Location = new System.Drawing.Point(239, 158);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnGuardar.Rotation = 0D;
            this.btnGuardar.Size = new System.Drawing.Size(251, 32);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "Guardar cambios";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(239, 132);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDireccion.Size = new System.Drawing.Size(251, 20);
            this.txtDireccion.TabIndex = 12;
            // 
            // txtRUC
            // 
            this.txtRUC.Location = new System.Drawing.Point(239, 83);
            this.txtRUC.Name = "txtRUC";
            this.txtRUC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRUC.Size = new System.Drawing.Size(251, 20);
            this.txtRUC.TabIndex = 11;
            // 
            // txtNombreNegocio
            // 
            this.txtNombreNegocio.Location = new System.Drawing.Point(239, 34);
            this.txtNombreNegocio.Name = "txtNombreNegocio";
            this.txtNombreNegocio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNombreNegocio.Size = new System.Drawing.Size(251, 20);
            this.txtNombreNegocio.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(236, 116);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Dirección:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(236, 67);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "RUC:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(236, 18);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nombre del negocio:";
            // 
            // btnSubir
            // 
            this.btnSubir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubir.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnSubir.IconChar = FontAwesome.Sharp.IconChar.ArrowUp;
            this.btnSubir.IconColor = System.Drawing.Color.Black;
            this.btnSubir.IconSize = 16;
            this.btnSubir.Location = new System.Drawing.Point(70, 168);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSubir.Rotation = 0D;
            this.btnSubir.Size = new System.Drawing.Size(84, 22);
            this.btnSubir.TabIndex = 2;
            this.btnSubir.Text = "Subir logo";
            this.btnSubir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSubir.UseVisualStyleBackColor = true;
            this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 18);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Logo:";
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.White;
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogo.InitialImage = null;
            this.picLogo.Location = new System.Drawing.Point(18, 34);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(186, 128);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            this.picLogo.Tag = "";
            // 
            // frmNegocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 512);
            this.Controls.Add(this.Datos);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Name = "frmNegocio";
            this.Text = "frmNegocio";
            this.Load += new System.EventHandler(this.frmNegocio_Load);
            this.Datos.ResumeLayout(false);
            this.Datos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Datos;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnSubir;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtRUC;
        private System.Windows.Forms.TextBox txtNombreNegocio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private FontAwesome.Sharp.IconButton btnGuardar;
    }
}