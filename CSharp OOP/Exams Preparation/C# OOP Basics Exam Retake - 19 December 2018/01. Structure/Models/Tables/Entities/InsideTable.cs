namespace SoftUniRestaurant.Models.Tables.Entities
{
    public class InsideTable : Table
    {
        private const decimal InitialPricePerPerson = 2.50m;

        public InsideTable(int tableNumber, int capacity) 
            : base(tableNumber, capacity, InitialPricePerPerson)
        {

        }
    }
}
