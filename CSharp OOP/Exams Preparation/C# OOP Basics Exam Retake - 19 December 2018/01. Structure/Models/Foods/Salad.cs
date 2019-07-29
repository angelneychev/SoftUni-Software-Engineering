namespace SoftUniRestaurant.Models.Foods
{
    public class Salad : Food
    {
        //Salad - with constant value for InitialServingSize - 300
        private const int InitialServingSize = 300;

        public Salad(string name, decimal price) 
            : base(name, InitialServingSize, price)
        {
        }
    }
}
