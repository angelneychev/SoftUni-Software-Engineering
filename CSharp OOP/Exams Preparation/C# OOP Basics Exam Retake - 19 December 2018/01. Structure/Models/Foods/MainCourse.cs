using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods
{
    class MainCourse : Food
    {
        // MainCourse - with constant value for InitialServingSize - 500
        private const int InitialServingSize = 500;
            
        public MainCourse(string name, decimal price) 
            : base(name, InitialServingSize, price)
        {
        }
    }
}
