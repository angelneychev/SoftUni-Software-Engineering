using System;
using AnimalCentre.Contracts;
using AnimalCentre.Core;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
           IEngine engine = new Engine();
           engine.Run();

       }
    }
}
