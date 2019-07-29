namespace HealthyHeaven
{
    public class Vegetable
    {
        private string name;
        private int calories;

        public Vegetable(string name, int calories)
        {
            this.Name = name;
            this.Calories = calories;
        }
        public string Name { get; set; }
        public int Calories { get; set; }

        public override string ToString()
        {
            return $" - {this.Name} have {this.Calories} calories";
        }
    }
}
