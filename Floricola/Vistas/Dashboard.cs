using Floricola.Recursos;
using Floricola.Modelos;
using Floricola.Vistas.Empleado;
using Floricola.Vistas.EstadoCivil;

namespace Floricola
{
    public partial class Dashboard : Form
    {
        private readonly menuRendered menuRenderer = new menuRendered();
        private readonly Login _login;
        private readonly UsuarioModel _usuario;
        private bool _cerrandoSesion = false;

        public Dashboard() : this(null, null) { }

        public Dashboard(Login login, UsuarioModel usuario)
        {
            InitializeComponent();
            _login = login;
            _usuario = usuario;

            // Menú lateral
            menuStrip1.Renderer = menuRenderer;
            foreach (ToolStripItem item in menuStrip1.Items)
            {
                item.AutoSize = false;
                item.Size = new Size(212, 46);
                item.ForeColor = Color.White;
                item.Font = new Font("Segoe UI", 11F);
                item.TextAlign = ContentAlignment.MiddleLeft;
                item.Click += SeleccionaItem;
            }
            menuRenderer.ItemActivo = itemInicio;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            lblBienvenida.Text = _usuario != null ? $"Bienvenido, {_usuario.Nombres}" : "Bienvenido";
            lblUsuarioActual.Text = _usuario != null ? $"Sesión: {_usuario.Nombre_Usuario}" : "Sesión: -";
        }

        // ---------- Menú ----------
        private void SeleccionaItem(object sender, EventArgs e)
        {
            menuRenderer.ItemActivo = sender as ToolStripItem;
            menuStrip1.Invalidate();
        }

        private void itemPendiente_Click(object sender, EventArgs e)
        {
            var item = (ToolStripItem)sender;
            MessageBox.Show($"El módulo \"{item.Text}\" está en construcción.", "FloriSoft",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void item_Usuarios_Click(object sender, EventArgs e)
        {
            var empleados = new frmNuevoEmpleado();
            empleados.ShowDialog();
        }

        private void itemEstadoCivil_Click(object sender, EventArgs e)
        {
            var estadoCivil = new FrmListaEstadoCivil();
            estadoCivil.ShowDialog();
        }

        // ---------- Sesión ----------
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("¿Desea cerrar sesión?", "Cerrar sesión",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            _cerrandoSesion = true;
            if (_login != null)
            {
                _login.ReiniciarLogin();
                _login.Show();
            }
            Close();
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Si cerró con la X (no con "Cerrar sesión") se termina el programa
            if (!_cerrandoSesion)
                Application.Exit();
        }
    }
}