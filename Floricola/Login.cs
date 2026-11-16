using Floricola.BaseDatos;
using Floricola.Controladores;
using Floricola.Modelos;

namespace Floricola
{
    public partial class Login : Form
    {
        private const int MaxIntentos = 3;
        private int intentos = 0;

        private readonly UsuarioController _usuarios = new UsuarioController();

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Verificar que la base de datos responde
            if (!new ConexionMySql().ProbarConexion())
            {
                BloquearFormulario("No hay conexión con la base de datos.");
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text;

            // Campos vacíos: no cuenta como intento
            if (usuario == "" || password == "")
            {
                MostrarMensaje("Ingrese su usuario y contraseña.");
                return;
            }

            UsuarioModel user;
            try
            {
                user = _usuarios.InciarSesion(usuario, password);
            }
            catch (Exception ex)
            {
                // Un fallo de la BD no gasta intentos
                MessageBox.Show("No se pudo consultar la base de datos:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Acceso correcto
            if (user != null && user.Activo)
            {
                intentos = 0;
                var dashboard = new Dashboard(this, user);
                dashboard.Show();
                this.Hide();
                return;
            }

            // Acceso fallido: cuenta un intento
            intentos++;
            int restantes = MaxIntentos - intentos;

            if (restantes <= 0)
            {
                MessageBox.Show(
                    $"Superó los {MaxIntentos} intentos permitidos.\nEl programa se cerrará.",
                    "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
                return;
            }

            string motivo = (user != null)
                ? "El usuario está inactivo."
                : "Usuario o contraseña incorrectos.";
            MostrarMensaje($"{motivo} Le quedan {restantes} intento{(restantes == 1 ? "" : "s")}.");

            txtPassword.Clear();
            txtPassword.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        // Lo llama el Dashboard al cerrar sesión
        public void ReiniciarLogin()
        {
            intentos = 0;
            txtUsuario.Clear();
            txtPassword.Clear();
            lblMensaje.Text = "";
            txtUsuario.Focus();
        }

        private void MostrarMensaje(string texto)
        {
            lblMensaje.Text = texto;
        }

        private void BloquearFormulario(string texto)
        {
            MostrarMensaje(texto);
            txtUsuario.Enabled = false;
            txtPassword.Enabled = false;
            btnIngresar.Enabled = false;
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}