namespace PersonsInfo
{
    public class Person
    {
        // 1. Add Fields
        // 2. Add Constructor

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        // 3. Add Properties
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }


        // 4. Add Methods
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
        }

    }

}
