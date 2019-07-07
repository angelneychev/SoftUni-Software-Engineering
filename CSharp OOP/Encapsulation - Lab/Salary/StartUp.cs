namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;
    public class StartUp
    {
        public static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
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

                persons.Add(person);
            }
            var parcentage = decimal.Parse(Console.ReadLine());
            persons.ForEach(p => p.IncreaseSalary(parcentage));
            persons.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
