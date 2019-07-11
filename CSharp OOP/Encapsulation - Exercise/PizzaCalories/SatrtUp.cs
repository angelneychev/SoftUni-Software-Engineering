namespace PizzaCalories
{
    using System;
    public class StatUp
    {
        static void Main()
        {


            try
            {
                string[] pizzaArgs = Console.ReadLine().Split();
                string pizzaName = pizzaArgs[1];
                string[] doughArgs = Console.ReadLine().Split();

                string doughFlourType = doughArgs[1];
                string doughBakingTechnique = doughArgs[2];
                double white = double.Parse(doughArgs[3]);

                Dough dough = new Dough(doughFlourType, doughBakingTechnique, white);
                Pizza pizza = new Pizza(pizzaName,dough);

                string inpputLine = Console.ReadLine();

                while (inpputLine !="END")
                {
                    string[] toppingArgs = inpputLine.Split();

                    string toppingType = toppingArgs[1];
                    double whiteTopping = double.Parse(toppingArgs[2]);

                    Topping topping = new Topping(toppingType, whiteTopping);
                    pizza.AddTopping(topping);
                    

                    inpputLine = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetTotalCalories().ToString("f2")} Calories.");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
