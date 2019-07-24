using System;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class Engin : IEngin
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engin(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string commandLine = Console.ReadLine();

                string result = this.commandInterpreter.Read(commandLine);

                Console.WriteLine(result);
            }
        }
    }
}
