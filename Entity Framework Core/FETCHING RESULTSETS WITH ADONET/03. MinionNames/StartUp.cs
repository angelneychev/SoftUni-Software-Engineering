using _01.Initial_Setup;
using System;
using System.Data.SqlClient;

namespace _03._MinionNames
{
    public static class StartUp
    {
        public static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            using var connection = new SqlConnection(Configuration.ConnectionString);

            connection.Open();

            using (var command = new SqlCommand(Queries.VillainName, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                var VillainName = (string)command.ExecuteScalar();

                if (VillainName == null)
                {
                    Console.WriteLine("No villain with ID 10 exists in the database.");
                    return;
                }
            }

            using (var command = new SqlCommand(Queries.MinionNames, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using var reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    Console.WriteLine("(no minions)");
                    return;
                }

                while (reader.Read())
                {
                    var row = (long)reader[0];
                    var name = (string)reader[1];
                    var age = (int)reader[2];

                    Console.WriteLine($"{row}. {name} {age}");
                }
            }
        }
    }
}
//Write a program that prints on the console all minion names and age for a given villain id, ordered by name alphabetically.
//If there is no villain with the given ID, print "No villain with ID <VillainId> exists in the database.".
//If the selected villain has no minions, print "(no minions)" on the second row.
