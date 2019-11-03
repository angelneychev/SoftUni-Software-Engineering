using System;
using System.Data.SqlClient;

namespace _02._VillainNames
{
    class StartUp
    {
        //2.	Villain Names
        // Write a program that prints on the console all villains’ names and their number of minions of //those who have more than 3 minions ordered descending by number of minions.
        private static string connetionString =
        (
            @"Server=ANGEL_LAPTOP\SQLEXPRESS; 
                Database=MinionsDB; 
                Integrated Security = true"
        );

        private static SqlConnection connection = new SqlConnection(connetionString);

        static void Main(string[] args)
        {
            connection.Open();
            using (connection)
            {
                string queryText =
                    @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                            FROM Villains AS v 
                            JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                        GROUP BY v.Id, v.Name 
                          HAVING COUNT(mv.VillainId) > 3 
                        ORDER BY COUNT(mv.VillainId)";
                SqlCommand cmd = new SqlCommand(queryText,connection);

               SqlDataReader reader =  cmd.ExecuteReader();
               using (reader)
               {
                   while (reader.Read())
                   {
                       Console.WriteLine($"{reader["Name"]} - {reader["MinionsCount"]}");
                   }
               }
            }
        }
    }
}
