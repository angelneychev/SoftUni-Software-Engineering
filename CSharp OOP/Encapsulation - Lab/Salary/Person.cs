namespace PersonsInfo
{
    public class Person
    {
        // 1. Add Fields

        // 2. Add Constructor
        public Person(string firstName, string laseName, 
            int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = laseName;
            this.Age = age;
            this.Salary = salary;
        }
        // 3. Add Properties
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public decimal Salary { get; private set; }


        // 4. Add Methods
        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age > 30)
            {
                this.Salary += this.Salary * percentage / 100;
            }
            else
            {
                this.Salary += this.Salary * percentage / 200;
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }

    }

}
