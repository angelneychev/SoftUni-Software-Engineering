using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandPostFix =
            "Command";

        public string Read(string inputLine)
        {
            string[] cmdTokkens = inputLine
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string commandName = cmdTokkens[0] + CommandPostFix;

            string[] commandArgs = cmdTokkens.Skip(1).ToArray();
            //Изграждане на Assembly
            Assembly assembly = Assembly.GetCallingAssembly();
            //Взимат се всички типове
            Type[] types = assembly.GetTypes();
            //Взимам типа който ми трябва
            Type typeToCreate = types.FirstOrDefault(t => t.Name == commandName);
            //ако случайно е null показвам грешка
            if (typeToCreate == null)
            {
                throw new InvalidOperationException("Invalid Command Type!");
            }
            // Създаваме инстанцията
            Object instance = Activator.CreateInstance(typeToCreate);
            //кастваме резултата
            ICommand command = (ICommand) instance;

            string result = command.Execute(commandArgs);

            return result;
        }
    }
}
