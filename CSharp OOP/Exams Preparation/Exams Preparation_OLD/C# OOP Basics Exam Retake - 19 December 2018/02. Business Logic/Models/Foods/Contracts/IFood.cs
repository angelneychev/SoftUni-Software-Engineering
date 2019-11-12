﻿namespace SoftUniRestaurant.Models.Foods.Contracts
{
    public interface IFood
    {
        //Name – string (If the name is null or whitespace throw an ArgumentException with message "Name cannot be null or white space!")
        string Name { get; }
        //ServingSize – int (can’t be less or equal to 0. In these cases, throw an ArgumentException with message "Serving size cannot be less or equal to zero")
        int ServingSize { get; }
        //Price – decimal (can’t be less or equal to 0. In these cases, throw an ArgumentException with message "Price cannot be less or equal to zero!")
        decimal Price { get; }
    }
}
