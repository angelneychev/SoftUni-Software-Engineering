﻿using System;
using System.Linq;
using System.Reflection;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;

namespace SoftUniRestaurant.Models.Tables.Factories
{
    public class TableFactroy
    {
        public ITable CreateTable(string tableType, int tableName, int capacity)
        {
            Type type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.StartsWith(tableType));
            ITable table = (ITable)Activator.CreateInstance(type,tableName,capacity);
            return table;
        }
    }
}
