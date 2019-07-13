namespace Ferrari
{
    using System;
    public class StartUp
    {
        static void Main()
        {
            string input = Console.ReadLine();

            var ferrari = new Models.Ferrari(input);

            Console.WriteLine(ferrari);
        }
    }
}
