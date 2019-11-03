using System;
using System.Collections.Generic;
using System.Text;

namespace _09._IncreaseAgeStoredProcedure
{
    public class Queries
    {
        public const string CreateProcedure = @"CREATE PROC usp_GetOlder @id INT
                                                    AS 
                                                        UPDATE Minions SET Age += 1
                                                            WHERE Id = @id";

        public const string SelectMinions = @"SELECT Name, Age FROM Minions WHERE Id = @Id";
    }
}
