namespace MilitaryElite.Contracts
{
    using  MilitaryElite.Enumerations;

    public interface IMissions
    {
        string CodeName { get; }
        State State { get; }
        void CompleteMission();
    }
}
