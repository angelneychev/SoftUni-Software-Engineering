using CommandPattern.Core;
using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter command = new CommandInterpreter();

            IEngin engin = new Engin(command);
            engin.Run();
        }
    }
}
