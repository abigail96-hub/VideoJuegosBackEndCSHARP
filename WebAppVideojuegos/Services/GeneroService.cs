using WebAppVideojuegos.Models;
using System.Data;
using System.Data.SqlClient;
namespace WebAppVideojuegos.Services
{
    public class GeneroService
    {

        private readonly string connection;

        public GeneroService(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("CadenaSql");
        }

        public async Task<List<Genero>> Generos()
        {
            List<Genero> lista = new List<Genero>();
            using (var con = new SqlConnection(connection))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("sp_ObtenerGeneros", con);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while(await reader.ReadAsync())
                    {
                        lista.Add(new Genero
                        {
                            IdGenero = Convert.ToInt16(reader["IdGenero"]),
                            Nombre = reader["Nombre"].ToString(),

                        }
                           );
                    }
                }
            }

            return lista;

        }
    }
}
