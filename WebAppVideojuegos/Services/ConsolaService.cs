using WebAppVideojuegos.Models;
using System.Data;
using System.Data.SqlClient;
namespace WebAppVideojuegos.Services
{
    public class ConsolaService
    {

        private readonly string connection;

        public ConsolaService(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("CadenaSql");
        }

        public async Task<List<Consola>> Consolas()
        {
            List<Consola> lista = new List<Consola>();
            using(var con = new SqlConnection(connection))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("sp_ObtenerConsolas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while(await reader.ReadAsync())
                    {
                        lista.Add(new Consola
                        {
                            IdConsola = Convert.ToInt16(reader["IdConsola"]),
                            Nombre = reader["Nombre"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }
    }
}
