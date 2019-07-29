using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Salad
    {
        private List<Vegetable> salads;

        public Salad(string name)
        {
            this.Name = name;
            this.salads = new List<Vegetable>();
        }

        public string Name { get; set; }
        public int GetTotalCalories()
        {
            return this.salads.Sum(x => x.Calories);
        }
        public int GetProductCount()
        {
            return this.salads.Count;
        }
        public void Add(Vegetable product)
        {
            this.salads.Add(product);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(
                $"* Salad {this.Name} is {this.GetTotalCalories()} calories and have {this.GetProductCount()} products:");

            foreach (var product in this.salads)
            {
                sb.AppendLine(product.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
