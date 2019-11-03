using System;
using System.Data.SqlClient;

namespace _06._Remove_Villain
{
    class StartUp
    {
    private static string connetionString =
        (
            @"Server=ANGEL_LAPTOP\SQLEXPRESS; 
                Database=MinionsDB; 
                Integrated Security = true"
        );
    private static SqlConnection connection = new SqlConnection(connetionString);
    private static SqlTransaction transaction;
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            connection.Open();
            using (connection)
            {
                transaction = connection.BeginTransaction();

                try
                {

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.Transaction = transaction;
                    command.CommandText = @"SELECT Name FROM Villains WHERE Id = @villainId";
                    command.Parameters.AddWithValue(@"villainId", id);

                    object value = command.ExecuteScalar();

                    if (value == null)
                    {
                        throw new ArgumentException("No such villain was found.");
                    }

                    string villainName = (string) value;

                    command.CommandText = @"DELETE FROM MinionsVillains WHERE VillainId = @villainId";

                    int minionsDeleted = command.ExecuteNonQuery();

                    command.CommandText = @"DELETE FROM Villains WHERE Id = @villainId";

                    command.ExecuteNonQuery();

                    transaction.Commit();

                    Console.WriteLine($"{villainName} was deleted.");
                    Console.WriteLine($"{minionsDeleted} minions were released.");
                }
                catch (ArgumentNullException ane)
                {
                    try
                    {
                        Console.WriteLine(ane.Message);
                        transaction.Rollback();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        throw;
                    }
                }
                catch (Exception e)
                {
                    try
                    {
                        Console.WriteLine(e.Message);
                        transaction.Rollback();
                    }
                    catch (Exception re)
                    {
                        Console.WriteLine(re.Message);
                        throw;
                    }
                }
            }
        }
    }
}
//Write a program that receives the ID of a villain, deletes him from the database and releases his minions from serving to him. Print on two lines the name of the deleted villain in format "<Name> was deleted." and the number of minions released in format "<MinionCount> minions were released.". Make sure all operations go as planned, otherwise do not make any changes in the database.
//  If there is no villain in the database with the given ID, print "No such villain was found.".
