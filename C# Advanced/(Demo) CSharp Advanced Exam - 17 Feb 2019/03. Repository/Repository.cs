using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class Repository
    {
        private Dictionary<int, Person> people;
        private int id;

        public Repository()
        {
            this.people = new Dictionary<int, Person>();
            this.id = 0;
        }

        public int Count => this.people.Count;

        //•	Method Add(Person person) – adds an entity to the Data; 
        public void Add(Person person)
        {
            this.people.Add(this.id++,person);
        }
        //•	Method Get(int id) – returns the entity with given ID
        public Person Get(int idPerson)
        {
            return this.people[idPerson];
        }
        //•	Method Update(int id, Person newPerson) – replaces the entity with the given id with the new entity.
        //Returns false if the id doesn't exist, otherwise returns true.
        public bool Update(int id, Person newPerson)
        {
            if (!this.people.ContainsKey(id))
            {
                return false;
            }

            this.people[id] = newPerson;
            return true;
        }
        //•	Method Delete(id) – deletes an entity by given id. Return false if the id doesn't exist, otherwise return true.
        public bool Delete(int id)
        {
            if (!this.people.ContainsKey(id))
            {
                return false;
            }

            this.people.Remove(id);
            return true;
        }


    }
}
