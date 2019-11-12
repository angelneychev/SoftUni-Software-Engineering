using System.Linq;
using System.Reflection;
using SoftUniRestaurant.Models.Drinks.Contracts;

namespace SoftUniRestaurant.Models.Drinks.Factories
{
    public class DrinkFactorie
    {
        public IDrink CreateDrink(string type, string name, int servingSize, string brand)
        {
            //Toва е като при FoodFactory но всичко на един ред с рефлекшън

            return (IDrink) Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type)
                .GetConstructors()
                .FirstOrDefault()
                .Invoke(new object[] {name, servingSize, brand});
        }
    }
}
