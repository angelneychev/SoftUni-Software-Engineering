using System.Collections.Generic;
using System.Linq;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Repositories.Contracts;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private readonly List<IMotorcycle> motorcycles;

        public MotorcycleRepository()
        {
            this.motorcycles = new List<IMotorcycle>();
        }

        public IMotorcycle GetByName(string name)
        {
            return this.motorcycles.FirstOrDefault(x => x.Model == name);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            return this.motorcycles.ToList();
        }

        public void Add(IMotorcycle model)
        {
            this.motorcycles.Add(model);
        }

        public bool Remove(IMotorcycle model)
        {
            return this.motorcycles.Remove(model);
        }
    }
}
