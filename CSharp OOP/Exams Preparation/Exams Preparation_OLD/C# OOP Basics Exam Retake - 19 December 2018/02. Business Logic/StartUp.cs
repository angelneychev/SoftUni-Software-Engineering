
using SoftUniRestaurant.Engines;
using SoftUniRestaurant.Engines.Contracts;

namespace SoftUniRestaurant
{
    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
