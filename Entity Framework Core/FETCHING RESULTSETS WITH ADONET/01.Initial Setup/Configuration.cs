using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Initial_Setup
{
    public class Configuration
    {
        public const string ConnectionString =
        (
            @"Server=ANGEL_LAPTOP\SQLEXPRESS; 
                Database=MinionsDB; 
                Integrated Security = true"
        );
    }
}
