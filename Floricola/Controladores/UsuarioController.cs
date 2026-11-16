using Floricola.BaseDatos;
using Floricola.Modelos;
using MySql.Data.MySqlClient;

namespace Floricola.Controladores
{
    public class UsuarioController
    {
        private readonly ConexionMySql _db = new ConexionMySql();

        public UsuarioModel InciarSesion(string Nombre_Usuario, string Password)
        {
            if (string.IsNullOrEmpty(Nombre_Usuario) || string.IsNullOrEmpty(Password))
            {
                return null;
            }

            using var conexion = _db.ObtenerConexion();
            conexion.Open();

            string cadena = @"SELECT u.nombre_usuario, u.password_hash, u.activo,
                                     e.id AS empleado_id, e.cedula, e.nombres, e.apellidos
                              FROM usuarios u
                              INNER JOIN empleados e ON e.id = u.empleado_id
                              WHERE u.nombre_usuario = @usuario";

            using var comando = new MySqlCommand(cadena, conexion);
            comando.Parameters.AddWithValue("@usuario", Nombre_Usuario);

            using var lector = comando.ExecuteReader();

            if (lector.Read())
            {
                if (lector.GetString("password_hash") != Password)
                {
                    return null;
                }

                return new UsuarioModel
                {
                    Id = lector.GetInt32("empleado_id"),
                    Cedula = lector.GetString("cedula"),
                    Nombres = lector.GetString("nombres"),
                    Apellidos = lector.GetString("apellidos"),
                    Nombre_Usuario = lector.GetString("nombre_usuario"),
                    Activo = lector.GetBoolean("activo")
                };
            }
            return null;
        }

        public (int empleados, int usuariosActivos, int estadosCiviles) ContarResumen()
        {
            using var cn = _db.ObtenerConexion();
            cn.Open();
            return (Contar(cn, "SELECT COUNT(*) FROM empleados"),
                    Contar(cn, "SELECT COUNT(*) FROM usuarios WHERE activo = 1"),
                    Contar(cn, "SELECT COUNT(*) FROM estados_civiles"));
        }

        private static int Contar(MySqlConnection cn, string sql)
        {
            using var cmd = new MySqlCommand(sql, cn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
}
