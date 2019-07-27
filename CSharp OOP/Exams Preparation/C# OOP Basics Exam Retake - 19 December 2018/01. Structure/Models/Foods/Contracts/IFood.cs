namespace SoftUniRestaurant.Models.Foods.Contracts
{
    public interface IFood
    {
        //ADD Name, ServingSize, Price
        string Name { get; }

        int ServingSize { get; }

        decimal Price { get; }
    }
}
