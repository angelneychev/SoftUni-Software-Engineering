using System;
//Intro and Basic Syntax - Lab
namespace _01._Student_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             You will be given 3 lines of input – 
             student name, age and average grade. 
             Your task is to print all the info about the 
             student in the following format: 
             "Name: {student name}, Age: {student age}, Grade: {student grade}".
             */
            string studentName = Console.ReadLine();
            int studentAge = int.Parse(Console.ReadLine());
            double averageGrade = double.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {studentName}, Age: {studentAge}, Grade: {averageGrade:f2}");
        }
    }
}
