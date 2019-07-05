namespace Restaurant.Beverages.HotBeverage
{
    public class Coffee:HotBeverages.HotBeverage
    {
        private const decimal CoffeePrice = 3.50m;

        private const double CoffeeMilliliters = 50;

        //подаваме константите
        public Coffee(string name,double caffeine) 
            : base(name, CoffeePrice,CoffeeMilliliters)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
