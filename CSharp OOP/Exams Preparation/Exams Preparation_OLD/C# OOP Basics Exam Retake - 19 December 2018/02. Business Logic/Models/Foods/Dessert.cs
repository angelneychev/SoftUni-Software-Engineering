namespace SoftUniRestaurant.Models.Foods
{
    public class Dessert : Food
    {
        //Dessert – with constant value for InitialServingSize - 200
        private const int InitialServingSize = 200;
        public Dessert(string name, decimal price) 
            : base(name, InitialServingSize, price)
        {
        }
    }
}
