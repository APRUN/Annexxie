using Annexxie.Model;
using System.Data.SqlClient;

namespace Annexxie.Controller
{
    public class LookupController
    {

        private static IConfiguration Configuration { get; set; }

        public static void Initialize(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async static Task<List<Lookup>> GetLookup()
        {
            List<Lookup> lookups = new List<Lookup>();
            using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("Default")))
            {
                connection.Open();
                string query = "SELECT * FROM Lookup";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lookups.Add(new Lookup(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                            }
                            return await Task.FromResult(lookups);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
