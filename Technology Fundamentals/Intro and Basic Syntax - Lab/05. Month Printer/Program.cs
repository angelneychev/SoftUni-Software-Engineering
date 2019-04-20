using System;
//Intro and Basic Syntax - Lab
namespace _05._Month_Printer
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumberMonts = int.Parse(Console.ReadLine());
            string montsName = String.Empty;

            switch (inputNumberMonts)
            {
                case 1:
                    montsName = "January";
                    break;
                case 2:
                    montsName = "February";
                    break;
                case 3:
                    montsName = "March";
                    break;
                case 4:
                    montsName = "April";
                    break;
                case 5:
                    montsName = "May";
                    break;
                case 6:
                    montsName = "June";
                    break;
                case 7:
                    montsName = "July";
                    break;
                case 8:
                    montsName = "August";
                    break;
                case 9:
                    montsName = "September";
                    break;
                case 10:
                    montsName = "October";
                    break;
                case 11:
                    montsName = "November";
                    break;
                case 12:
                    montsName = "December";
                    break;
                default:
                    Console.WriteLine("Error!");
                    break;
            }

            Console.WriteLine($"{montsName}");
        }
    }
}
