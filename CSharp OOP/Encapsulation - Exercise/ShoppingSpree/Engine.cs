using System.Collections.Generic;

namespace ShoppingSpree
{
    using System;
    using System.Linq;

    class Engine
    {
        private List<Person> persons;
        private List<Product> products;

        public Engine()
        {
            this.persons = new List<Person>();
            this.products = new List<Product>();
        }

        public void Run()
        {
            try
            {
                ReadPersonsInput();
                ReadProductInput();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    string[] commandTokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string personName = commandTokens[0];
                    string productName = commandTokens[1];

                    Person person = this.persons.FirstOrDefault(x => x.Name == personName);
                    Product product = this.products.FirstOrDefault(x => x.Name == productName);

                    if (person != null && product != null)
                    {
                        person.BuyProduct(product);
                        Console.WriteLine($"{person.Name} bought {product.Name}");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(Environment.NewLine, this.persons));
        }

        private void ReadPersonsInput()
        {
            string[] personTokens = Console.ReadLine().Split(";").ToArray();

            foreach (var item in personTokens)
            {
                string[] personInfo = item.Split("=").ToArray();
                string name = personInfo[0];
                decimal money = decimal.Parse(personInfo[1]);
                Person person = new Person(name, money);

                this.persons.Add(person);
            }
        }

        private void ReadProductInput()
        {
            string[] producTokens = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var item in producTokens)
            {
                string[] productInfo = item.Split("=").ToArray();
                string name = productInfo[0];
                decimal cost = decimal.Parse(productInfo[1]);
                Product product = new Product(name, cost);

                this.products.Add(product);
            }
        }
    }
}