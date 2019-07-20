namespace MilitaryElite.Models
{
    using System;
    using MilitaryElite.Contracts;
    using MilitaryElite.Enumerations;
    using MilitaryElite.Exceptions;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
        {
            ParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private void ParseCorps(string corpsStr)
        {
            Corps corps;
            bool parsed = Enum.TryParse<Corps>(corpsStr, out corps);
            if (!parsed)
            {
                throw  new InvalidCorpsExceptions();
            }

            this.Corps = corps;
        }

        public override string ToString()
        {
            return base.ToString() 
                   + Environment.NewLine 
                   + $"Corps: {this.Corps}";
        }
    }
}
