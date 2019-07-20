using System.Linq;

namespace MilitaryElite.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using MilitaryElite.Contracts;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly List<IMissions> missionses;

        public Commando(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.missionses = new List<IMissions>();
        }

        public IReadOnlyCollection<IMissions> Missions => this.missionses;

        public void AddMissions(IMissions missions)
        {
            this.missionses.Add(missions);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine("Missions:");

            foreach (var mis in this.missionses)
            {
                sb.AppendLine($"  {mis.ToString().TrimEnd()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
