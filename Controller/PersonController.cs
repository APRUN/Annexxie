using System.Data.SqlClient;
using Annexxie.Model;

namespace Annexxie.Controller
{
    public class PersonController
    {
        private static IConfiguration Configuration { get; set; }

        public static void Initialize(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public async static Task<List<Person>> GetPersons()
        {
            List<Person> persons = new List<Person>();
            using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("Default")))
            {
                connection.Open();
                string query = "SELECT * FROM Person";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                persons.Add(new Person(
                                    reader.GetInt32(0), //For Id
                                    reader.GetString(1),//FName
                                    reader.GetString(2),//LName
                                    reader.IsDBNull(3) ? null : reader.GetString(3),//Image
                                    reader.GetString(4),//City
                                    reader.GetString(5),//Address
                                    reader.GetString(6),
                                    reader.GetBoolean(7), // Use GetBoolean for a boolean value
                                    reader.GetString(8),
									//Handle for Null Password too
									reader.IsDBNull(9) ? null : reader.GetString(9)
                                    ));
                            }
                            return await Task.FromResult(persons);
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
        public async static Task AddPerson(Person person)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("Default")))
			{
				connection.Open();
				string query = "INSERT INTO Person (FirstName, LastName, City, Address, PhoneNumber, Email) VALUES (@FirstName, @LastName, @City, @Address, @PhoneNumber, @Email)";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					try
					{
						command.Parameters.AddWithValue("@FirstName", person.FirstName);
						command.Parameters.AddWithValue("@LastName", person.LastName);
						//command.Parameters.AddWithValue("@Image", person.Image);
						command.Parameters.AddWithValue("@City", person.City);
						command.Parameters.AddWithValue("@Address", person.Address);
						command.Parameters.AddWithValue("@PhoneNumber", person.PhoneNumber);
						//command.Parameters.AddWithValue("@IsDeleted", person.IsDeleted);
						command.Parameters.AddWithValue("@Email", person.Email);
						//command.Parameters.AddWithValue("@Password", person.Password);
						await command.ExecuteNonQueryAsync();
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
