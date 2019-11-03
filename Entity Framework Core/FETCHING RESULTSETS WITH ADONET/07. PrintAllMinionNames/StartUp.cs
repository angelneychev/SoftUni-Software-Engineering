using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using _01.Initial_Setup;

namespace _07._PrintAllMinionNames
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> name = new List<string>();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Queries.TakeAllMinionNames, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        name.Add((string)reader[0]);
                    }
                }
            }

            Console.WriteLine($"{string.Join(Environment.NewLine,name)}");
            Console.WriteLine();

            while (name.Count != 0)
            {
                Console.WriteLine(name[0]);
                name.RemoveAt(0);
                if (name.Count == 0)
                {
                    break;
                }

                Console.WriteLine(name.Last());
                name.RemoveAt(name.Count -1);
            }
        }
    }
}
/*
    Write a program that prints all minion names from the minions table in the following order: first record, last record, first + 1, last - 1, first + 2, last - 2 … first + n, last - n. 
 */
