using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using _01.Initial_Setup;

namespace _05._ChangeTownNamesCasing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Queries.EditTownsName, connection))
                {
                    command.Parameters.AddWithValue("@countryName", country);

                    int changedTownsCount = command.ExecuteNonQuery();

                    Console.WriteLine($"{changedTownsCount} town names were affected.");

                }

                using (SqlCommand command = new SqlCommand(Queries.FindTownsEdtit, connection))
                {
                    command.Parameters.AddWithValue("@countryName", country);
                    List<string> cities = new List<string>();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cities.Add((string)reader[0]);
                        }
                    }

                    if (cities.Count == 0)
                    {
                        Console.WriteLine("No town names were affected.");
                    }
                    else
                    {
                        Console.WriteLine($"[{string.Join(", ", cities)}]");
                    }
                }
            }
        }
    }
}
