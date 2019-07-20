namespace MilitaryElite.Contracts
{
    using MilitaryElite.Enumerations;

    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
