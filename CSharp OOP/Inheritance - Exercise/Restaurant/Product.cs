namespace Restaurant
{
    public class Product
    {
        // 1. Add Fields

        //2. Add Constructor
        //Продукта има Име и Цена
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
        // 3. Add Properties
        public string Name { get; set; }
        public decimal Price { get; set; }

        // 4. Add Methods
    }
}
