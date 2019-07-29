namespace SoftUniRestaurant.Models.Drinks.Contracts
{
    public interface IDrink
    {
        //Name – string (If the name is null or whitespace throw an ArgumenException with message "Name cannot be null or white space!")
        string Name { get; }

        //ServingSize – int (if the serving size is less than or equal to 0, throw an ArgumentException with message "Serving size cannot be less or equal to zero")
        int ServingSize { get; }

        //Price – decimal (if the price is less than or equal to 0, throw an ArgumentException with message "Price cannot be less or equal to zero")
        decimal Price { get; }

        //Brand -  string (If the brand is null or whitespace thrown ArgumentException with message "Brand cannot be null or white space!")
        string Brand { get; }


    }
}
