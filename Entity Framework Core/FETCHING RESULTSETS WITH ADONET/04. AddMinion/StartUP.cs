using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using _01.Initial_Setup;

namespace _04._AddMinion
{
    public class StartUP
    {
        private static int TownId;
        private static int MinionId;
        private static int VillainId;

        public static void Main(string[] args)
        {
            List<string> minionsItems = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToList();
            string minionName = minionsItems[0];
            int minionAge = int.Parse(minionsItems[1]);
            string minionTown = minionsItems[2];

            List<string> villainsItems = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToList();

            string villainName = villainsItems[0];

            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                ExecuteTownQuery(minionTown, connection);
                ExecuteMinionQuery(minionName, minionAge, connection);
                ExecuteVillainQuery(villainName, connection);
                ExecuteAddMinionToVillainQuery(minionName, villainName, connection);
            }

            ;
        }

        private static void ExecuteAddMinionToVillainQuery(string minionName, string villainName,
            SqlConnection connection)
        {
            using (var insertMinionToVillainCommand = new SqlCommand(Queries.InsertMV, connection))
            {
                insertMinionToVillainCommand.Parameters.AddWithValue("@villainId", VillainId);
                insertMinionToVillainCommand.Parameters.AddWithValue("@minionId", MinionId);
                insertMinionToVillainCommand.ExecuteNonQuery();

                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }

        private static void ExecuteVillainQuery(string villainName, SqlConnection connection)
        {
            using (SqlCommand checkVillainCommand = new SqlCommand(Queries.TakeVillainId, connection))
            {
                checkVillainCommand.Parameters.AddWithValue("@Name", villainName);

                object targetId = checkVillainCommand.ExecuteScalar();

                if (targetId != null)
                {
                    VillainId = (int) targetId;
                }
                else
                {
                    using (SqlCommand insertVillainCommand = new SqlCommand(Queries.InsertVillain, connection))
                    {
                        insertVillainCommand.Parameters.AddWithValue("@villainName", villainName);
                        insertVillainCommand.ExecuteNonQuery();
                        Console.WriteLine($"Villain {villainName} was added to the database.");
                    }
                }
            }
        }

        private static void ExecuteMinionQuery(string minionName, in int minionAge, SqlConnection connection)
        {
            using (var checkMinionCommand = new SqlCommand(Queries.TakeMinionId, connection))
            {
                checkMinionCommand.Parameters.AddWithValue("@Name", minionName);

                object targetId = checkMinionCommand.ExecuteScalar();

                if (targetId != null)
                {
                    MinionId = (int) targetId;
                }
                else
                {
                    using (SqlCommand InserMinionCommand = new SqlCommand(Queries.InsertMinion, connection))
                    {
                        InserMinionCommand.Parameters.AddWithValue("@Name", minionName);
                        InserMinionCommand.Parameters.AddWithValue("@Age", minionAge);
                        InserMinionCommand.Parameters.AddWithValue("@townId", TownId);

                        InserMinionCommand.ExecuteNonQuery();

                        Console.WriteLine($"Minion {minionName} was added to the database.");
                    }
                }
            }
        }

        private static void ExecuteTownQuery(string minionTown, SqlConnection connection)
        {
            using (SqlCommand checkTownCommand = new SqlCommand(Queries.TakeTownId, connection))
            {
                checkTownCommand.Parameters.AddWithValue("@townName", minionTown);
                object targetId = checkTownCommand.ExecuteScalar();

                if (targetId != null)
                {
                    TownId = (int) targetId;
                }
                else
                {
                    using (SqlCommand insertTownCommand = new SqlCommand(Queries.InsertTown, connection))
                    {
                        insertTownCommand.Parameters.AddWithValue("@townName", minionTown);
                        insertTownCommand.ExecuteNonQuery();
                        Console.WriteLine($"Town {minionTown} was added to the database.");
                    }
                }
            }
        }
    }
}

/*
 * Write a program that reads information about a minion and its villain and adds it to the database. In case the town of the minion is not in the database, insert it as well. In case the villain is not present in the database, add him too with a default evilness factor of "evil". Finally set the new minion to be a servant of the villain. Print appropriate messages after each operation.
 */
