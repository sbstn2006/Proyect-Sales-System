namespace capapresentacion
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.MenuUsuarios = new FontAwesome.Sharp.IconMenuItem();
            this.MenuMantenedor = new FontAwesome.Sharp.IconMenuItem();
            this.submenucategoria = new FontAwesome.Sharp.IconMenuItem();
            this.submenuproducto = new FontAwesome.Sharp.IconMenuItem();
            this.MenuVentas = new FontAwesome.Sharp.IconMenuItem();
            this.submenuregistrarventa = new FontAwesome.Sharp.IconMenuItem();
            this.submenuverdetalleventa = new FontAwesome.Sharp.IconMenuItem();
            this.MenuCompras = new FontAwesome.Sharp.IconMenuItem();
            this.submenuregistrarcompra = new FontAwesome.Sharp.IconMenuItem();
            this.submenuverdetallecompra = new FontAwesome.Sharp.IconMenuItem();
            this.MenuClientes = new FontAwesome.Sharp.IconMenuItem();
            this.MenuProveedores = new FontAwesome.Sharp.IconMenuItem();
            this.MenuReportes = new FontAwesome.Sharp.IconMenuItem();
            this.MenuAcercade = new FontAwesome.Sharp.IconMenuItem();
            this.barra = new System.Windows.Forms.MenuStrip();
            this.label2 = new System.Windows.Forms.Label();
            this.lblusuario = new System.Windows.Forms.Label();
            this.barra.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.AutoSize = false;
            this.menuStrip2.BackColor = System.Drawing.SystemColors.Highlight;
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1014, 48);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.Font = new System.Drawing.Font("Ravie", 15F);
            this.label1.Location = new System.Drawing.Point(313, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sistema de ventas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // contenedor
            // 
            this.contenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(0, 48);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1014, 482);
            this.contenedor.TabIndex = 4;
            this.contenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // MenuUsuarios
            // 
            this.MenuUsuarios.AutoSize = false;
            this.MenuUsuarios.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.MenuUsuarios.IconChar = FontAwesome.Sharp.IconChar.UserFriends;
            this.MenuUsuarios.IconColor = System.Drawing.SystemColors.Highlight;
            this.MenuUsuarios.IconSize = 35;
            this.MenuUsuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuUsuarios.Name = "MenuUsuarios";
            this.MenuUsuarios.Rotation = 0D;
            this.MenuUsuarios.Size = new System.Drawing.Size(100, 50);
            this.MenuUsuarios.Text = "usuarios";
            this.MenuUsuarios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuUsuarios.Click += new System.EventHandler(this.MenuUsuarios_Click_1);
            // 
            // MenuMantenedor
            // 
            this.MenuMantenedor.AutoSize = false;
            this.MenuMantenedor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenucategoria,
            this.submenuproducto});
            this.MenuMantenedor.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.MenuMantenedor.IconChar = FontAwesome.Sharp.IconChar.Database;
            this.MenuMantenedor.IconColor = System.Drawing.SystemColors.GrayText;
            this.MenuMantenedor.IconSize = 35;
            this.MenuMantenedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuMantenedor.Name = "MenuMantenedor";
            this.MenuMantenedor.Rotation = 0D;
            this.MenuMantenedor.Size = new System.Drawing.Size(100, 50);
            this.MenuMantenedor.Text = "Mantenedor";
            this.MenuMantenedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuMantenedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuMantenedor.Click += new System.EventHandler(this.MenuMantenedor_Click);
            // 
            // submenucategoria
            // 
            this.submenucategoria.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.submenucategoria.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenucategoria.IconColor = System.Drawing.Color.Black;
            this.submenucategoria.IconSize = 16;
            this.submenucategoria.Name = "submenucategoria";
            this.submenucategoria.Rotation = 0D;
            this.submenucategoria.Size = new System.Drawing.Size(133, 22);
            this.submenucategoria.Text = "Categoría";
            this.submenucategoria.Click += new System.EventHandler(this.submenucategoria_Click);
            // 
            // submenuproducto
            // 
            this.submenuproducto.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.submenuproducto.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuproducto.IconColor = System.Drawing.Color.Black;
            this.submenuproducto.IconSize = 16;
            this.submenuproducto.Name = "submenuproducto";
            this.submenuproducto.Rotation = 0D;
            this.submenuproducto.Size = new System.Drawing.Size(133, 22);
            this.submenuproducto.Text = "Producto";
            this.submenuproducto.Click += new System.EventHandler(this.iconMenuItem3_Click_1);
            // 
            // MenuVentas
            // 
            this.MenuVentas.AutoSize = false;
            this.MenuVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuregistrarventa,
            this.submenuverdetalleventa});
            this.MenuVentas.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.MenuVentas.IconChar = FontAwesome.Sharp.IconChar.HandHoldingUsd;
            this.MenuVentas.IconColor = System.Drawing.Color.LawnGreen;
            this.MenuVentas.IconSize = 35;
            this.MenuVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuVentas.Name = "MenuVentas";
            this.MenuVentas.Rotation = 0D;
            this.MenuVentas.Size = new System.Drawing.Size(100, 50);
            this.MenuVentas.Text = "Ventas";
            this.MenuVentas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuregistrarventa
            // 
            this.submenuregistrarventa.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.submenuregistrarventa.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuregistrarventa.IconColor = System.Drawing.Color.Black;
            this.submenuregistrarventa.IconSize = 16;
            this.submenuregistrarventa.Name = "submenuregistrarventa";
            this.submenuregistrarventa.Rotation = 0D;
            this.submenuregistrarventa.Size = new System.Drawing.Size(142, 22);
            this.submenuregistrarventa.Text = "Registrar";
            this.submenuregistrarventa.Click += new System.EventHandler(this.submenuregistrarventa_Click);
            // 
            // submenuverdetalleventa
            // 
            this.submenuverdetalleventa.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.submenuverdetalleventa.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuverdetalleventa.IconColor = System.Drawing.Color.Black;
            this.submenuverdetalleventa.IconSize = 16;
            this.submenuverdetalleventa.Name = "submenuverdetalleventa";
            this.submenuverdetalleventa.Rotation = 0D;
            this.submenuverdetalleventa.Size = new System.Drawing.Size(142, 22);
            this.submenuverdetalleventa.Text = "Ver detalle ";
            this.submenuverdetalleventa.Click += new System.EventHandler(this.submenuverdetalleventa_Click);
            // 
            // MenuCompras
            // 
            this.MenuCompras.AutoSize = false;
            this.MenuCompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuregistrarcompra,
            this.submenuverdetallecompra});
            this.MenuCompras.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.MenuCompras.IconChar = FontAwesome.Sharp.IconChar.Donate;
            this.MenuCompras.IconColor = System.Drawing.Color.Gold;
            this.MenuCompras.IconSize = 35;
            this.MenuCompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuCompras.Name = "MenuCompras";
            this.MenuCompras.Rotation = 0D;
            this.MenuCompras.Size = new System.Drawing.Size(100, 50);
            this.MenuCompras.Text = "Compras";
            this.MenuCompras.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuCompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuCompras.Click += new System.EventHandler(this.MenuCompras_Click);
            // 
            // submenuregistrarcompra
            // 
            this.submenuregistrarcompra.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.submenuregistrarcompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuregistrarcompra.IconColor = System.Drawing.Color.Black;
            this.submenuregistrarcompra.IconSize = 16;
            this.submenuregistrarcompra.Name = "submenuregistrarcompra";
            this.submenuregistrarcompra.Rotation = 0D;
            this.submenuregistrarcompra.Size = new System.Drawing.Size(138, 22);
            this.submenuregistrarcompra.Text = "registrar";
            this.submenuregistrarcompra.Click += new System.EventHandler(this.submenuregistrarcompra_Click);
            // 
            // submenuverdetallecompra
            // 
            this.submenuverdetallecompra.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.submenuverdetallecompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuverdetallecompra.IconColor = System.Drawing.Color.Black;
            this.submenuverdetallecompra.IconSize = 16;
            this.submenuverdetallecompra.Name = "submenuverdetallecompra";
            this.submenuverdetallecompra.Rotation = 0D;
            this.submenuverdetallecompra.Size = new System.Drawing.Size(138, 22);
            this.submenuverdetallecompra.Text = "Ver detalle";
            this.submenuverdetallecompra.Click += new System.EventHandler(this.submenuverdetallecompra_Click);
            // 
            // MenuClientes
            // 
            this.MenuClientes.AutoSize = false;
            this.MenuClientes.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.MenuClientes.IconChar = FontAwesome.Sharp.IconChar.Male;
            this.MenuClientes.IconColor = System.Drawing.SystemColors.InfoText;
            this.MenuClientes.IconSize = 35;
            this.MenuClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuClientes.Name = "MenuClientes";
            this.MenuClientes.Rotation = 0D;
            this.MenuClientes.Size = new System.Drawing.Size(100, 50);
            this.MenuClientes.Text = "Clientes";
            this.MenuClientes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuClientes.Click += new System.EventHandler(this.Menuclientes_Click);
            // 
            // MenuProveedores
            // 
            this.MenuProveedores.AutoSize = false;
            this.MenuProveedores.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.MenuProveedores.IconChar = FontAwesome.Sharp.IconChar.TruckMoving;
            this.MenuProveedores.IconColor = System.Drawing.Color.SaddleBrown;
            this.MenuProveedores.IconSize = 35;
            this.MenuProveedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuProveedores.Name = "MenuProveedores";
            this.MenuProveedores.Rotation = 0D;
            this.MenuProveedores.Size = new System.Drawing.Size(100, 50);
            this.MenuProveedores.Text = "Proveedores";
            this.MenuProveedores.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuProveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuProveedores.Click += new System.EventHandler(this.MenuProveedores_Click);
            // 
            // MenuReportes
            // 
            this.MenuReportes.AutoSize = false;
            this.MenuReportes.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.MenuReportes.IconChar = FontAwesome.Sharp.IconChar.Archive;
            this.MenuReportes.IconColor = System.Drawing.Color.Red;
            this.MenuReportes.IconSize = 35;
            this.MenuReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuReportes.Name = "MenuReportes";
            this.MenuReportes.Rotation = 0D;
            this.MenuReportes.Size = new System.Drawing.Size(100, 50);
            this.MenuReportes.Text = "Reportes";
            this.MenuReportes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuReportes.Click += new System.EventHandler(this.iconMenuItem1_Click);
            // 
            // MenuAcercade
            // 
            this.MenuAcercade.AutoSize = false;
            this.MenuAcercade.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.MenuAcercade.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleDown;
            this.MenuAcercade.IconColor = System.Drawing.SystemColors.Highlight;
            this.MenuAcercade.IconSize = 35;
            this.MenuAcercade.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuAcercade.Name = "MenuAcercade";
            this.MenuAcercade.Rotation = 0D;
            this.MenuAcercade.Size = new System.Drawing.Size(100, 50);
            this.MenuAcercade.Text = "Acerca de";
            this.MenuAcercade.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuAcercade.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuAcercade.Click += new System.EventHandler(this.menuusuarios_Click);
            // 
            // barra
            // 
            this.barra.BackColor = System.Drawing.Color.White;
            this.barra.GripMargin = new System.Windows.Forms.Padding(-1);
            this.barra.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuUsuarios,
            this.MenuMantenedor,
            this.MenuVentas,
            this.MenuCompras,
            this.MenuClientes,
            this.MenuProveedores,
            this.MenuReportes,
            this.MenuAcercade});
            this.barra.Location = new System.Drawing.Point(0, 48);
            this.barra.Margin = new System.Windows.Forms.Padding(1);
            this.barra.Name = "barra";
            this.barra.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.barra.Size = new System.Drawing.Size(1014, 54);
            this.barra.TabIndex = 1;
            this.barra.Text = "menuStrip1";
            this.barra.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuReportes_ItemClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Highlight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(699, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = ":Usuario";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblusuario
            // 
            this.lblusuario.AutoSize = true;
            this.lblusuario.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusuario.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblusuario.Location = new System.Drawing.Point(757, 9);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(69, 17);
            this.lblusuario.TabIndex = 6;
            this.lblusuario.Text = "lblusuario";
            this.lblusuario.Click += new System.EventHandler(this.label3_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 530);
            this.Controls.Add(this.lblusuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.barra);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip2);
            this.Name = "Inicio";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.barra.ResumeLayout(false);
            this.barra.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel contenedor;
        private FontAwesome.Sharp.IconMenuItem MenuUsuarios;
        private FontAwesome.Sharp.IconMenuItem MenuMantenedor;
        private FontAwesome.Sharp.IconMenuItem MenuVentas;
        private FontAwesome.Sharp.IconMenuItem MenuCompras;
        private FontAwesome.Sharp.IconMenuItem MenuClientes;
        private FontAwesome.Sharp.IconMenuItem MenuProveedores;
        private FontAwesome.Sharp.IconMenuItem MenuReportes;
        private FontAwesome.Sharp.IconMenuItem MenuAcercade;
        private System.Windows.Forms.MenuStrip barra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblusuario;
        private FontAwesome.Sharp.IconMenuItem submenucategoria;
        private FontAwesome.Sharp.IconMenuItem submenuproducto;
        private FontAwesome.Sharp.IconMenuItem submenuregistrarventa;
        private FontAwesome.Sharp.IconMenuItem submenuverdetalleventa;
        private FontAwesome.Sharp.IconMenuItem submenuregistrarcompra;
        private FontAwesome.Sharp.IconMenuItem submenuverdetallecompra;
    }
}

