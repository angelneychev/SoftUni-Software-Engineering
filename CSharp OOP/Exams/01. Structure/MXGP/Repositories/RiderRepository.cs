using System.Collections.Generic;
using System.Linq;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;

namespace MXGP.Repositories
{
    class RiderRepository : IRepository<IRider>
    {
        private readonly List<IRider> riders;

        public RiderRepository()
        {
            this.riders = new List<IRider>();
        }

        public IRider GetByName(string name)
        {
            return this.riders.FirstOrDefault(x => x.Name == name);
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            return this.riders.ToList();
        }

        public void Add(IRider model)
        {
            this.riders.Add(model);
        }

        public bool Remove(IRider model)
        {
            return this.riders.Remove(model);
        }
    }
}
