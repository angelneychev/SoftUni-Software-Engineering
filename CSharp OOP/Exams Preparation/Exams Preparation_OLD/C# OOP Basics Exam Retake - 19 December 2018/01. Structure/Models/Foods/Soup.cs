using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods
{
    
    class Soup : Food
    {
        //Soup - with constant value for InitialServingSize - 245
        private const int InitialServingSize = 245;
        public Soup(string name, decimal price) 
            : base(name, InitialServingSize, price)
        {
        }
    }
}
