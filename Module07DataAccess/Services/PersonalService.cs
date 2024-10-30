using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module07DataAccess.Model; //Add line
using MySql.Data.MySqlClient; //Add line

namespace Module07DataAccess.Services
{
    public class PersonalService
    {
        private readonly string _databaseConnectionString;
        public PersonalService()
        {
            var dbService = new DatabaseConnectionService();
            _databaseConnectionString = dbService.GetConnectionString();
        }
        
        public async Task<List<Personal>>GetAllPersonalsAsync()
        {
            var personalService = new List<Personal>();
            using (var conn = new MySqlConnection(_databaseConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand("SELECT * FROM tblpersonal", conn);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync()) 
                    {
                        personalService.Add(new Personal
                        {
                            ID = reader.GetInt32("ID"),
                            Name = reader.GetString("Name"),
                            Gender = reader.GetString("Gender"),
                            ContactNo = reader.GetString("ContactNo"),
                        });
                    }
                }
            }
            return personalService;
        }

        public async  Task<bool> AddPersonalAsync(Personal newPerson)
        {
            try 
            {
                using (var conn = new MySqlConnection(_databaseConnectionString)) 
                {
                    await conn.OpenAsync();
                    var cmd = new MySqlCommand("Insert INTO tblPersonal (Name, Gender, ContactNo) VALUES (@Name, @Gender, @ContactNo)", conn);
                    cmd.Parameters.AddWithValue("@Name", newPerson.Name);
                    cmd.Parameters.AddWithValue("@Gender", newPerson.Gender);
                    cmd.Parameters.AddWithValue("@ContactNo", newPerson.ContactNo);
                    var result = await cmd.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding personal recod: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeletePersonalAsync(int id)
        {
            try
            {
                using (var conn = new MySqlConnection(_databaseConnectionString))
                {
                    await conn.OpenAsync();
                    var cmd = new MySqlCommand("DELETE FROM tblPersonal WHERE ID=@ID", conn);
                    cmd.Parameters.AddWithValue("@ID", id);

                    var result = await cmd.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting personal record: {ex.Message}");
                return false;
            }
        }
    }
}
