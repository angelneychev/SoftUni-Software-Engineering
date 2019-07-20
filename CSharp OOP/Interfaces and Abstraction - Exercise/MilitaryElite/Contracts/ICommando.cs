namespace MilitaryElite.Contracts
{
    using System.Collections.Generic;
    public interface ICommando: ISpecialisedSoldier
    {
        IReadOnlyCollection<IMissions> Missions { get; }

        void AddMissions(IMissions missions);
    }
}
