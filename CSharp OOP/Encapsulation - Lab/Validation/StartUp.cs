using System.IO;

namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;
    public class StartUp
    {
        static void Main()
        {
            try
            {
               var lines = int.Parse(Console.ReadLine());
              //  var persons = new List<Person>();
                for (int i = 0; i < lines; i++)
                {
                    var input = Console.ReadLine().Split();
                    var firstname = input[0];
                    var lastName = input[1];
                    var age = input[2];
                    var salary = input[3];
                    var person = new Person(
                        firstname,
                        lastName,
                        int.Parse(age),
                        decimal.Parse(salary));
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }

            //Person p = null;
            //try
            //{
            //    p = new Person("Ivan","Ivanov", 10, 2500);
            //    Console.WriteLine(p.Age);
            //}
            //catch (ArgumentException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //if (p !=null)
            //{
            //    Console.WriteLine(p.ToString());
            //}
        }
    }
}
