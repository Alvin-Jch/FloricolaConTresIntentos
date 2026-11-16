namespace Floricola
{
    partial class Dashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        private void InitializeComponent()
        {
            pnlMenu = new Panel();
            menuStrip1 = new MenuStrip();
            itemInicio = new ToolStripMenuItem();
            itemCultivos = new ToolStripMenuItem();
            itemProduccion = new ToolStripMenuItem();
            itemCosecha = new ToolStripMenuItem();
            itemInventarios = new ToolStripMenuItem();
            item_Usuarios = new ToolStripMenuItem();
            itemEstadoCivil = new ToolStripMenuItem();
            pnlSesion = new Panel();
            lblUsuarioActual = new Label();
            btnCerrarSesion = new Button();
            lblMarca = new Label();
            pnlContenido = new Panel();
            lblBienvenida = new Label();
            pnlMenu.SuspendLayout();
            menuStrip1.SuspendLayout();
            pnlSesion.SuspendLayout();
            pnlContenido.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.FromArgb(25, 50, 41);
            pnlMenu.Controls.Add(menuStrip1);
            pnlMenu.Controls.Add(pnlSesion);
            pnlMenu.Controls.Add(lblMarca);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(230, 600);
            pnlMenu.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(25, 50, 41);
            menuStrip1.CanOverflow = false;
            menuStrip1.Dock = DockStyle.Fill;
            menuStrip1.GripStyle = ToolStripGripStyle.Hidden;
            menuStrip1.Items.AddRange(new ToolStripItem[] { itemInicio, itemCultivos, itemProduccion, itemCosecha, itemInventarios, item_Usuarios, itemEstadoCivil });
            menuStrip1.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            menuStrip1.Location = new Point(0, 80);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(8, 6, 0, 3);
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Size = new Size(230, 430);
            menuStrip1.TabIndex = 1;
            // 
            // itemInicio
            // 
            itemInicio.Name = "itemInicio";
            itemInicio.Text = "Inicio";
            // 
            // itemCultivos
            // 
            itemCultivos.Name = "itemCultivos";
            itemCultivos.Text = "Cultivos y bloques";
            itemCultivos.Click += itemPendiente_Click;
            // 
            // itemProduccion
            // 
            itemProduccion.Name = "itemProduccion";
            itemProduccion.Text = "Producción";
            itemProduccion.Click += itemPendiente_Click;
            // 
            // itemCosecha
            // 
            itemCosecha.Name = "itemCosecha";
            itemCosecha.Text = "Cosecha y calidad";
            itemCosecha.Click += itemPendiente_Click;
            // 
            // itemInventarios
            // 
            itemInventarios.Name = "itemInventarios";
            itemInventarios.Text = "Inventarios";
            itemInventarios.Click += itemPendiente_Click;
            // 
            // item_Usuarios
            // 
            item_Usuarios.Name = "item_Usuarios";
            item_Usuarios.Text = "Empleados y Usuarios";
            item_Usuarios.Click += item_Usuarios_Click;
            // 
            // itemEstadoCivil
            // 
            itemEstadoCivil.Name = "itemEstadoCivil";
            itemEstadoCivil.Text = "Estado Civil";
            itemEstadoCivil.Click += itemEstadoCivil_Click;
            // 
            // pnlSesion
            // 
            pnlSesion.Controls.Add(btnCerrarSesion);
            pnlSesion.Controls.Add(lblUsuarioActual);
            pnlSesion.Dock = DockStyle.Bottom;
            pnlSesion.Location = new Point(0, 510);
            pnlSesion.Name = "pnlSesion";
            pnlSesion.Size = new Size(230, 90);
            pnlSesion.TabIndex = 2;
            // 
            // lblUsuarioActual
            // 
            lblUsuarioActual.Font = new Font("Segoe UI", 9F);
            lblUsuarioActual.ForeColor = Color.FromArgb(232, 221, 203);
            lblUsuarioActual.Location = new Point(10, 8);
            lblUsuarioActual.Name = "lblUsuarioActual";
            lblUsuarioActual.Size = new Size(210, 22);
            lblUsuarioActual.TabIndex = 0;
            lblUsuarioActual.Text = "Sesión: -";
            lblUsuarioActual.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.FromArgb(30, 120, 100);
            btnCerrarSesion.Cursor = Cursors.Hand;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(10, 36);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(210, 38);
            btnCerrarSesion.TabIndex = 1;
            btnCerrarSesion.Text = "Cerrar sesión";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // lblMarca
            // 
            lblMarca.Dock = DockStyle.Top;
            lblMarca.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblMarca.ForeColor = Color.White;
            lblMarca.Location = new Point(0, 0);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(230, 80);
            lblMarca.TabIndex = 0;
            lblMarca.Text = "FloriSoft";
            lblMarca.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlContenido
            // 
            pnlContenido.BackColor = Color.FromArgb(232, 221, 203);
            pnlContenido.Controls.Add(lblBienvenida);
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(230, 0);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Size = new Size(770, 600);
            pnlContenido.TabIndex = 1;
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.FromArgb(25, 50, 41);
            lblBienvenida.Location = new Point(40, 30);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "Bienvenido";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(232, 221, 203);
            ClientSize = new Size(1000, 600);
            Controls.Add(pnlContenido);
            Controls.Add(pnlMenu);
            Font = new Font("Segoe UI", 10F);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(850, 550);
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FloriSoft";
            WindowState = FormWindowState.Maximized;
            FormClosing += Dashboard_FormClosing;
            Load += Dashboard_Load;
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            pnlSesion.ResumeLayout(false);
            pnlContenido.ResumeLayout(false);
            pnlContenido.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMenu;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem itemInicio;
        private ToolStripMenuItem itemCultivos;
        private ToolStripMenuItem itemProduccion;
        private ToolStripMenuItem itemCosecha;
        private ToolStripMenuItem itemInventarios;
        private ToolStripMenuItem item_Usuarios;
        private ToolStripMenuItem itemEstadoCivil;
        private Panel pnlSesion;
        private Label lblUsuarioActual;
        private Button btnCerrarSesion;
        private Label lblMarca;
        private Panel pnlContenido;
        private Label lblBienvenida;
    }
}
