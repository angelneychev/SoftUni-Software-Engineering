using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
   public class Animal
   {
       public Animal(string name, int age)
       {
           this.Name = name;
           this.Age = age;
       }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
