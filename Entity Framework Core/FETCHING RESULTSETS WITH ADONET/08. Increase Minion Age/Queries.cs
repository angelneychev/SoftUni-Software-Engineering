using System;
using System.Collections.Generic;
using System.Text;

namespace _08._Increase_Minion_Age
{
    public class Queries
    {
        public const string UpdateMinionAge = @"UPDATE Minions
                      SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                    WHERE Id = @Id";

        public const string SelectNameAndAgMinions = @"SELECT Name, Age FROM Minions";
    }
}
