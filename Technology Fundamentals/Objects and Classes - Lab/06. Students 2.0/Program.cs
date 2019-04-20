using System;
using System.Collections.Generic;
//Objects and Classes - Lab
namespace _06._Students_2._0
{
    class Studant
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int age { get; set; }
        public string city { get; set; }
    }
    class Program
    {
        static void Main()
        {
            List<Studant> studants = new List<Studant>();

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] tokens = line.Split();

                string firstName = tokens[0];
                string lastName = tokens[1];
                int age = int.Parse(tokens[2]);
                string city = tokens[3];

                if (isStudentExisting(studants, firstName, lastName))
                {
                    Studant studant = GetStudant(studants, firstName, lastName);
                    studant.FirstName = firstName;
                    studant.LastName = lastName;
                    studant.age = age;
                    studant.city = city;
                }
                else
                {
                    Studant studant = new Studant()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        age = age,
                        city = city
                    };
                    studants.Add(studant);
                }

                line = Console.ReadLine();
            }

            string filterCity = Console.ReadLine();

            foreach (var studant in studants)
            {
                if (studant.city == filterCity)
                {
                    Console.WriteLine($"{studant.FirstName} " +
                                      $"{studant.LastName} " +
                                      $"is {studant.age} years old.");
                }
            }


        }

        static bool isStudentExisting(List<Studant> studants, string firstName, string lastName)
        {
            foreach (var studant in studants)
            {
                if (studant.FirstName == firstName && studant.LastName == lastName)
                {
                    return true;
                }
            }
            return false;
        }

        static Studant GetStudant(List<Studant> studants, string firstname, string lastName)
        {
            Studant existingStudant = null;
            foreach (var studant in studants)
            {
                if (studant.FirstName == firstname && studant.LastName == lastName)
                {
                    existingStudant = studant;

                }
            }

            return existingStudant;
        }
    }
}
