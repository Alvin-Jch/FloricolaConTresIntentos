using Floricola.BaseDatos;
using Floricola.Modelos;
using MySql.Data.MySqlClient;

namespace Floricola.Controladores
{
    public class EmpleadoController
    {
        private readonly ConexionMySql _db = new ConexionMySql();

        public List<UsuarioModel> Listar()
        {
            const string sql = @"SELECT e.id, e.cedula, e.nombres, e.apellidos, e.direccion, e.telefono,
                                        e.celular, e.correo, e.estado_civil_id,
                                        u.nombre_usuario, u.activo
                                 FROM empleados e
                                 LEFT JOIN usuarios u ON u.empleado_id = e.id
                                 ORDER BY e.apellidos, e.nombres";
            var lista = new List<UsuarioModel>();

            using var cn = _db.ObtenerConexion();
            cn.Open();
            using var cmd = new MySqlCommand(sql, cn);
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                lista.Add(new UsuarioModel
                {
                    Id = rd.GetInt32("id"),
                    Cedula = rd.GetString("cedula"),
                    Nombres = rd.GetString("nombres"),
                    Apellidos = rd.GetString("apellidos"),
                    Direccion = Texto(rd, "direccion"),
                    Telefono = Texto(rd, "telefono"),
                    Celular = Texto(rd, "celular"),
                    Correo = Texto(rd, "correo"),
                    EstadoCivilModelId = rd.IsDBNull(rd.GetOrdinal("estado_civil_id")) ? 0 : rd.GetInt32("estado_civil_id"),
                    Nombre_Usuario = Texto(rd, "nombre_usuario"),
                    Activo = !rd.IsDBNull(rd.GetOrdinal("activo")) && rd.GetBoolean("activo")
                });
            }
            return lista;
        }

        public void Crear(UsuarioModel m)
        {
            using var cn = _db.ObtenerConexion();
            cn.Open();
            using var tx = cn.BeginTransaction();
            try
            {
                const string sql = @"INSERT INTO empleados
                    (cedula, nombres, apellidos, direccion, telefono, celular, correo, estado_civil_id)
                    VALUES (@cedula, @nombres, @apellidos, @direccion, @telefono, @celular, @correo, @ec)";
                using (var cmd = new MySqlCommand(sql, cn, tx))
                {
                    CargarParametros(cmd, m);
                    cmd.ExecuteNonQuery();
                    m.Id = (int)cmd.LastInsertedId;
                }

                if (!string.IsNullOrWhiteSpace(m.Nombre_Usuario))
                    InsertarUsuario(cn, tx, m);

                tx.Commit();
            }
            catch (MySqlException ex)
            {
                tx.Rollback();
                throw TraducirError(ex);
            }
        }

        public void Actualizar(UsuarioModel m)
        {
            using var cn = _db.ObtenerConexion();
            cn.Open();
            using var tx = cn.BeginTransaction();
            try
            {
                const string sql = @"UPDATE empleados SET cedula=@cedula, nombres=@nombres,
                    apellidos=@apellidos, direccion=@direccion, telefono=@telefono,
                    celular=@celular, correo=@correo, estado_civil_id=@ec
                    WHERE id=@id";
                using (var cmd = new MySqlCommand(sql, cn, tx))
                {
                    CargarParametros(cmd, m);
                    cmd.Parameters.AddWithValue("@id", m.Id);
                    cmd.ExecuteNonQuery();
                }

                if (!string.IsNullOrWhiteSpace(m.Nombre_Usuario))
                {
                    bool existe;
                    using (var chk = new MySqlCommand("SELECT COUNT(*) FROM usuarios WHERE empleado_id=@id", cn, tx))
                    {
                        chk.Parameters.AddWithValue("@id", m.Id);
                        existe = Convert.ToInt32(chk.ExecuteScalar()) > 0;
                    }

                    if (!existe)
                    {
                        InsertarUsuario(cn, tx, m);
                    }
                    else
                    {
                        
                        bool cambiaPass = !string.IsNullOrEmpty(m.Password);
                        string upd = "UPDATE usuarios SET nombre_usuario=@u, activo=@a"
                                   + (cambiaPass ? ", password_hash=@h" : "")
                                   + " WHERE empleado_id=@id";
                        using var cmd = new MySqlCommand(upd, cn, tx);
                        cmd.Parameters.AddWithValue("@u", m.Nombre_Usuario.Trim());
                        cmd.Parameters.AddWithValue("@a", m.Activo);
                        cmd.Parameters.AddWithValue("@id", m.Id);
                        if (cambiaPass)
                            cmd.Parameters.AddWithValue("@h", m.Password);
                        cmd.ExecuteNonQuery();
                    }
                }

                tx.Commit();
            }
            catch (MySqlException ex)
            {
                tx.Rollback();
                throw TraducirError(ex);
            }
        }

        public bool Eliminar(int empleadoId)
        {
            
            using var cn = _db.ObtenerConexion();
            cn.Open();
            using var cmd = new MySqlCommand("DELETE FROM empleados WHERE id=@id", cn);
            cmd.Parameters.AddWithValue("@id", empleadoId);
            return cmd.ExecuteNonQuery() > 0;
        }

      
        private static void InsertarUsuario(MySqlConnection cn, MySqlTransaction tx, UsuarioModel m)
        {
            if (string.IsNullOrEmpty(m.Password))
                throw new Exception("Debe ingresar una contraseña para el nuevo usuario.");

            using var cmd = new MySqlCommand(
                @"INSERT INTO usuarios (empleado_id, nombre_usuario, password_hash, activo)
                  VALUES (@e, @u, @h, @a)", cn, tx);
            cmd.Parameters.AddWithValue("@e", m.Id);
            cmd.Parameters.AddWithValue("@u", m.Nombre_Usuario.Trim());
            cmd.Parameters.AddWithValue("@h", m.Password);
            cmd.Parameters.AddWithValue("@a", m.Activo);
            cmd.ExecuteNonQuery();
        }

        private static void CargarParametros(MySqlCommand cmd, UsuarioModel m)
        {
            cmd.Parameters.AddWithValue("@cedula", m.Cedula.Trim());
            cmd.Parameters.AddWithValue("@nombres", m.Nombres.Trim());
            cmd.Parameters.AddWithValue("@apellidos", m.Apellidos.Trim());
            cmd.Parameters.AddWithValue("@direccion", NuloSiVacio(m.Direccion));
            cmd.Parameters.AddWithValue("@telefono", NuloSiVacio(m.Telefono));
            cmd.Parameters.AddWithValue("@celular", NuloSiVacio(m.Celular));
            cmd.Parameters.AddWithValue("@correo", NuloSiVacio(m.Correo));
            cmd.Parameters.AddWithValue("@ec", m.EstadoCivilModelId > 0 ? m.EstadoCivilModelId : DBNull.Value);
        }

        private static object NuloSiVacio(string s) =>
            string.IsNullOrWhiteSpace(s) ? DBNull.Value : s.Trim();

        private static string Texto(MySqlDataReader rd, string col)
        {
            int i = rd.GetOrdinal(col);
            return rd.IsDBNull(i) ? "" : rd.GetString(i);
        }

        private static Exception TraducirError(MySqlException ex)
        {
            if (ex.Number == 1062)
            {
                if (ex.Message.Contains("cedula")) return new Exception("Ya existe un empleado con esa cédula.");
                if (ex.Message.Contains("nombre_usuario")) return new Exception("Ese nombre de usuario ya está en uso.");
                return new Exception("Ya existe un registro con esos datos.");
            }
            return ex;
        }
    }
}