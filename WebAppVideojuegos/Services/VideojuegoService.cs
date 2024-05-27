using WebAppVideojuegos.Models;
using System.Data;
using System.Data.SqlClient;
namespace WebAppVideojuegos.Services

{
    public class VideojuegoService
    {

        private readonly string connection;

        public VideojuegoService(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("CadenaSql");
        }

        public async Task<List<Videojuego>> Videojuegos()
        {
            List<Videojuego> lista = new List<Videojuego>();
            using (var con = new SqlConnection (connection))
            {
                await con.OpenAsync ();
                SqlCommand cmd = new SqlCommand("sp_ObtenerVideojuegos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while(await reader.ReadAsync()) {
                        lista.Add(new Videojuego
                        {
                            IdVideojuego = Convert.ToInt32(reader["IdVideojuego"]),
                            Titulo = reader["Titulo"].ToString(),
                            Descripcion = reader["Descripcion"].ToString(),
                            Año = Convert.ToInt16(reader["Año"]),
                            Calificacion = Convert.ToInt16(reader["Calificacion"]),
                            Estatus = Convert.ToBoolean(reader["Estatus"]),
                            IdConsola = Convert.ToInt16(reader["IdConsola"]),
                            IdGenero = Convert.ToInt16(reader["IdGenero"])
                        });
                    }
                }

            }

            return lista;
            
        }

        public async Task<Videojuego> VideoJuego (int id)
        {
            Videojuego objeto = new Videojuego();

            using (var con = new SqlConnection(connection))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("sp_ObtenerVideojuego", con);
                cmd.Parameters.AddWithValue("@IdVideojuego", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var read = await cmd.ExecuteReaderAsync())
                {
                    while (await read.ReadAsync())
                    {
                        objeto = new Videojuego
                        {
                            IdVideojuego = read.GetInt32("IdVideojuego"),
                            Titulo = read["Titulo"].ToString(),
                            Descripcion = read["Descripcion"].ToString(),
                            Año = read.GetInt16("Año"),
                            Calificacion = read.GetInt16("Calificacion"),
                            Estatus = read.GetBoolean("Estatus"),
                            IdConsola = read.GetInt16("IdConsola"),
                            IdGenero = read.GetInt16("IdGenero")

                        };
                    }
                }

            }

            return objeto;

        }

        public async Task<bool> CrearVideojuego (Videojuego obj)
        {
            bool response = true;

            using(var con = new SqlConnection (connection))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("sp_CrearVideojuego", con);
                cmd.Parameters.AddWithValue("@Titulo", obj.Titulo);
                cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("@Año", obj.Año);
                cmd.Parameters.AddWithValue("@Calificacion", obj.Calificacion);
                cmd.Parameters.AddWithValue("@Estatus", obj.Estatus);
                cmd.Parameters.AddWithValue("@IdConsola", obj.IdConsola);
                cmd.Parameters.AddWithValue("@IdGenero", obj.IdGenero);

                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    response = await cmd.ExecuteNonQueryAsync() > 0 ?
                     true : false;   

                }
                
                catch
                {
                    response = false;
                }

            }

            return response;
        }

        public async Task<bool> EditarVideojuego (Videojuego obj)
        {
            bool response = true;

            using (var con = new SqlConnection(connection))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("sp_ActualizarVideojuego", con);
                cmd.Parameters.AddWithValue("@IdVideojuego", obj.IdVideojuego);
                cmd.Parameters.AddWithValue("@Titulo", obj.Titulo);
                cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("@Año", obj.Año);
                cmd.Parameters.AddWithValue("@Calificacion", obj.Calificacion);
                cmd.Parameters.AddWithValue("@Estatus", obj.Estatus);
                cmd.Parameters.AddWithValue("@IdConsola", obj.IdConsola);
                cmd.Parameters.AddWithValue("@IdGenero", obj.IdGenero);

                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    response = await cmd.ExecuteNonQueryAsync() > 0 ?
                     true : false;

                }

                catch
                {
                    response = false;
                }

            }

            return response;

        }

        public async Task<bool> EliminarVideojuego(int id)
        {
            bool response = true;

            using (var con = new SqlConnection(connection))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("sp_EliminarVideojuego", con);
                cmd.Parameters.AddWithValue("@IdVideojuego", id);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    response = await cmd.ExecuteNonQueryAsync() > 0 ?
                        true : false;

                }
                catch
                {
                    response = false;
                }
            }
            
            return response;

        }
    }
}
