namespace MilitaryElite.Contracts
{
    using System;

    public interface IPrivate : ISoldier
    {
        
        decimal Salary { get; }
    }
}
