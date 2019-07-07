namespace PersonsInfo
{
    using System;
    using System.IO;
    public class Person
    {
        // 1. Add Fields
        private int age;
        private decimal salary;
        private string firstName;
        private string lastName;

        
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
        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if (value.Length <3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");

                }

            }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (value.Length <3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
            }
        }

        public int Age
        {
            get { return this.age; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }

                this.age = value;
            }
        }

        public decimal Salary
        {
            get { return this.salary; }
            private set
            {
                if (value <460)
                {
                    throw new ArgumentException("Salary cannot be less than 460 leva!");
                }

                this.salary = value;
            }
        }

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
