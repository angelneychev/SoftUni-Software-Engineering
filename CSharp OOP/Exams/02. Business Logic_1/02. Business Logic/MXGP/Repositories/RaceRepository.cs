﻿using System.Collections.Generic;
using System.Linq;
using MXGP.Models.Races.Contracts;
using MXGP.Repositories.Contracts;

namespace MXGP.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> races;

        public RaceRepository()
        {
            this.races = new List<IRace>();
        }

        public IRace GetByName(string name) => this.races.FirstOrDefault(x => x.Name == name);

        public IReadOnlyCollection<IRace> GetAll() => this.races.ToList();


        public void Add(IRace model) => this.races.Add(model);


        public bool Remove(IRace model) => this.races.Remove(model);
    }
}
