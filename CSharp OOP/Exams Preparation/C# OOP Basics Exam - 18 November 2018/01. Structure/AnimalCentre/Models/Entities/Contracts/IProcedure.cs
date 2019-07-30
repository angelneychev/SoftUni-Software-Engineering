using System.Collections.Generic;

namespace AnimalCentre.Models.Contracts
{
    public interface IProcedure
    {
        //Implement me
        //•	ProcedureHistory – collection of Animals accessible only by the child classes (will hold information about each procedure and its animals)

        string History();

        void DoService(IAnimal animal, int procedureTime);
    }
}
