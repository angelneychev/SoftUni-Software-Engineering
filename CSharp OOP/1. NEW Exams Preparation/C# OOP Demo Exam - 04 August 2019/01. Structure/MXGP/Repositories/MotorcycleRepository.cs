﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Repositories.Contracts;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private readonly IList<IMotorcycle> motorcycles;

        public MotorcycleRepository()
        {
            this.motorcycles = new List<IMotorcycle>();
        }

        public IMotorcycle GetByName(string name)
            => this.motorcycles.FirstOrDefault(x => x.Model == name);

        public IReadOnlyCollection<IMotorcycle> GetAll()
            => this.motorcycles.ToList();

        public void Add(IMotorcycle model)
            => this.motorcycles.Add(model);

        public bool Remove(IMotorcycle model)
            => this.motorcycles.Remove(model);
    }
}
