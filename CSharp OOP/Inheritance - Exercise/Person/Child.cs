namespace Person
{
    public class Child : Person
    {
        //Constructor
        public Child(string name, int age) : base(name, age)
        {
        }

        public override int Age
        {
            get => base.Age;
            protected set
            {
                // объркано условие в задачата!!!!!
                //if (value > 15)
                //{
                //    throw new ArgumentException("Child’s age must be less than 15!");
                //}

                base.Age = value;
            }
        }
    }
}