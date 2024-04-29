using System.Data.SqlClient;
using System.Linq.Expressions;
using Annexxie.Model;

namespace Annexxie.Controller
{
    public class StaffController
    {
        private static IConfiguration Configuration { get; set; }

        public static void Initialize(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public async static Task<List<Staff>> GetStaffs()
        {
            List<Staff> staffs = new List<Staff>();
            using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("Default")))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Staff";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                staffs.Add(new Staff(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2)));
                            }
                            return await Task.FromResult(staffs);
                        }
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
        /*public async static Task<> AddStaff(Staff staff)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("Default")))
			{
				try
				{
					connection.Open();
					string query = "INSERT INTO Staff (PersonId, LookupId) VALUES (@PersonId, @LookupId)";
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@PersonId", staff.PersonId);
						command.Parameters.AddWithValue("@LookupId", staff.LookupId);
						await command.ExecuteNonQueryAsync();
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
		}*/
        //delete staff
        public async static Task DeleteStaff(int id)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("Default")))
			{
				try
				{
					connection.Open();
					string query = "DELETE FROM Staff WHERE StaffId = @Id";
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@Id", id);
						await command.ExecuteNonQueryAsync();
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
