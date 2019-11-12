using SoftUniRestaurant.Models.Tables.Contracts;

namespace SoftUniRestaurant.Models.Tables.Factories
{
    public class TableFactorie
    {
        //Tова е фактори без рефлекшън.
        public ITable CtreatTable(string type, int tableNumber, int capacity)
        {
            ITable table;

            switch (type)
            {
                case "Inside":
                    table = new InsideTable(tableNumber,capacity);
                    break;
                case "Outside":
                    table = new OutsideTable(tableNumber, capacity);
                    break;
                default: table = null;
                    break;
            }

            return table;
        }
    }
}
