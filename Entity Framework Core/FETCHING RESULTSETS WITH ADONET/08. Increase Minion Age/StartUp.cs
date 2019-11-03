using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using _01.Initial_Setup;

namespace _08._Increase_Minion_Age
{
    public class StartUp
    {
        private static void Main(string[] args)
        {
            List<int> inputId = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                using (SqlCommand updateAgeMinions = new SqlCommand(Queries.UpdateMinionAge, connection))
                {
                    for (int i = 0; i < inputId.Count; i++)
                    {
                        int id = inputId[i];
                        updateAgeMinions.Parameters.AddWithValue("@id", id);
                        updateAgeMinions.ExecuteNonQuery();
                        updateAgeMinions.Parameters.Clear();
                    }
                }

                using (SqlCommand command = new SqlCommand(Queries.SelectNameAndAgMinions,connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string name = (string)reader[0];
                        int age = (int)reader[1];
                        Console.WriteLine($"{name} {age}");
                    }
                }
            }
        }
    }
}
