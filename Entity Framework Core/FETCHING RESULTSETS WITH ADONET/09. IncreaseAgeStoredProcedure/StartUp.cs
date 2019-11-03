using System;
using System.Data;
using System.Data.SqlClient;
using _01.Initial_Setup;

namespace _09._IncreaseAgeStoredProcedure
{
    public class StartUp
    {
        private static void Main(string[] args)
        {
            int inputId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Queries.SelectMinions, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (SqlCommand command = new SqlCommand(Queries.CreateProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", inputId);
                    command.ExecuteNonQuery();
                }

                using (SqlCommand command = new SqlCommand(Queries.SelectMinions, connection))
                {
                    command.Parameters.AddWithValue("@id", inputId);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string name = (string)reader[0];
                        int age = (int) reader[1];
                        Console.WriteLine($"{name} - {age} years old");
                    }
                }
            }
        }
    }
}
