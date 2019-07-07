namespace Lab
{
   public class Dog : Animal
    {
        public Dog(string name, int age)
            : base(name, age)
        {

        }

        public string Bark()
        {
            return "Bark";
        }

    }
}
