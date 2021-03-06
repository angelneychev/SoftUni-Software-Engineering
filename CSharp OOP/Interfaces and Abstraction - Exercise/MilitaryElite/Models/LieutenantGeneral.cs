﻿namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using MilitaryElite.Contracts;
    using System.Text;
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {

        private readonly List<ISoldier> privates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> Privates => this.privates;

        public void AddPrivate(ISoldier @private)
        {
           this.privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine("Privates:");
            foreach (var pr in this.Privates)
            {
                sb.AppendLine($"  {pr.ToString().TrimEnd()}");

            }
            return sb.ToString().TrimEnd();
        }
    }
}
