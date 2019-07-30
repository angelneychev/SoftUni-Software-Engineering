using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Entities.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected ICollection<IAnimal> ProcedureHistory { get; }
        protected Procedure()
        {
            this.ProcedureHistory = new Collection<IAnimal>();
        }

        public string History()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}");

            foreach (var animal in this.ProcedureHistory)
            {
                sb.AppendLine(animal.ToString());
            }

            string result = sb.ToString().TrimEnd();

            return result;

        }

        public virtual void DoService(IAnimal animal, int procedureTime)
        {
            if (procedureTime > animal.ProcedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            animal.ProcedureTime -= procedureTime;
            ProcedureHistory.Add(animal);

        }
    }
}
