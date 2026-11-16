namespace Floricola
{
    partial class Login
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
            pnlEncabezado = new Panel();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblMensaje = new Label();
            btnIngresar = new Button();
            btnSalir = new Button();
            pnlEncabezado.SuspendLayout();
            SuspendLayout();
            // 
            // pnlEncabezado
            // 
            pnlEncabezado.BackColor = Color.FromArgb(25, 50, 41);
            pnlEncabezado.Controls.Add(lblSubtitulo);
            pnlEncabezado.Controls.Add(lblTitulo);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(380, 120);
            pnlEncabezado.TabIndex = 0;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.Font = new Font("Segoe UI", 10F);
            lblSubtitulo.ForeColor = Color.FromArgb(232, 221, 203);
            lblSubtitulo.Location = new Point(0, 72);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(380, 26);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Inicio de sesión";
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(380, 50);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "FloriSoft";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUsuario.ForeColor = Color.FromArgb(25, 50, 41);
            lblUsuario.Location = new Point(40, 145);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(70, 23);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Font = new Font("Segoe UI", 11F);
            txtUsuario.ForeColor = Color.FromArgb(25, 50, 41);
            txtUsuario.Location = new Point(40, 170);
            txtUsuario.MaxLength = 80;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = "Ingrese su usuario";
            txtUsuario.Size = new Size(300, 32);
            txtUsuario.TabIndex = 2;
            txtUsuario.TextChanged += txtUsuario_TextChanged;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(25, 50, 41);
            lblPassword.Location = new Point(40, 212);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(99, 23);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Contraseña";
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.ForeColor = Color.FromArgb(25, 50, 41);
            txtPassword.Location = new Point(40, 237);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Ingrese su contraseña";
            txtPassword.Size = new Size(300, 32);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // lblMensaje
            // 
            lblMensaje.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblMensaje.ForeColor = Color.Firebrick;
            lblMensaje.Location = new Point(40, 303);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(300, 44);
            lblMensaje.TabIndex = 6;
            lblMensaje.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(30, 120, 100);
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(40, 360);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(300, 42);
            btnIngresar.TabIndex = 7;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(232, 221, 203);
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.FlatAppearance.BorderColor = Color.FromArgb(25, 50, 41);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalir.ForeColor = Color.FromArgb(25, 50, 41);
            btnSalir.Location = new Point(40, 412);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(300, 38);
            btnSalir.TabIndex = 8;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // Login
            // 
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(232, 221, 203);
            CancelButton = btnSalir;
            ClientSize = new Size(380, 470);
            Controls.Add(btnSalir);
            Controls.Add(btnIngresar);
            Controls.Add(lblMensaje);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(pnlEncabezado);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FloriSoft - Iniciar sesión";
            Load += Login_Load;
            pnlEncabezado.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlEncabezado;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblMensaje;
        private Button btnIngresar;
        private Button btnSalir;
    }
}
