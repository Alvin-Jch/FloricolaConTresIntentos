using Floricola.BaseDatos;
using Floricola.Modelos;
using MySql.Data.MySqlClient;

namespace Floricola.Controladores
{
    public class EstadoCivilController
    {
        private readonly ConexionMySql _db = new ConexionMySql();

        public EstadoCivilModel NuevoEstadoCivil(string detalle)
        {
            if (string.IsNullOrWhiteSpace(detalle))
                throw new Exception("La descripción no puede estar vacía.");

            try
            {
                using var cn = _db.ObtenerConexion();
                cn.Open();
                using var cmd = new MySqlCommand(
                    "INSERT INTO estados_civiles (descripcion) VALUES (@d)", cn);
                cmd.Parameters.AddWithValue("@d", detalle.Trim());
                cmd.ExecuteNonQuery();

                return new EstadoCivilModel { Id = (int)cmd.LastInsertedId, Descripcion = detalle.Trim() };
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                throw new Exception("Ya existe un estado civil con esa descripción.");
            }
        }

        public List<EstadoCivilModel> ListarEstadoCivil()
        {
            var lista = new List<EstadoCivilModel>();
            using var cn = _db.ObtenerConexion();
            cn.Open();
            using var cmd = new MySqlCommand(
                "SELECT id, descripcion FROM estados_civiles ORDER BY descripcion", cn);
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                lista.Add(new EstadoCivilModel
                {
                    Id = rd.GetInt32("id"),
                    Descripcion = rd.GetString("descripcion")
                });
            }
            return lista;
        }

        public EstadoCivilModel EditarEstadoCivil(EstadoCivilModel estadoCivil)
        {
            if (string.IsNullOrWhiteSpace(estadoCivil.Descripcion))
                throw new Exception("La descripción no puede estar vacía.");

            try
            {
                using var cn = _db.ObtenerConexion();
                cn.Open();
                using var cmd = new MySqlCommand(
                    "UPDATE estados_civiles SET descripcion = @d WHERE id = @id", cn);
                cmd.Parameters.AddWithValue("@d", estadoCivil.Descripcion.Trim());
                cmd.Parameters.AddWithValue("@id", estadoCivil.Id);
                cmd.ExecuteNonQuery();
                return estadoCivil;
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                throw new Exception("Ya existe un estado civil con esa descripción.");
            }
        }

        public bool EliminarEstadoCivil(EstadoCivilModel estado)
        {
            try
            {
                using var cn = _db.ObtenerConexion();
                cn.Open();
                using var cmd = new MySqlCommand("DELETE FROM estados_civiles WHERE id = @id", cn);
                cmd.Parameters.AddWithValue("@id", estado.Id);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex) when (ex.Number == 1451)
            {
                throw new Exception("No se puede eliminar: hay empleados que usan este estado civil.");
            }
        }
    }
}
