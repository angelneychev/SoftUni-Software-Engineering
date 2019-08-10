using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.IO.Contracts;

namespace PlayersAndMonsters.IO
{
    public class Writer :IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
