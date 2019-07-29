using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }
        //•	Getter Count – returns the number of stored heroes.
        public int Count => this.data.Count;

        //•	Method Add(Hero hero) – adds an entity to the data.
        public void Add(Hero hero)
        {
          this.data.Add(hero);
        }
        //•	Method Remove(string name) – removes an entity by given hero name.
        public void Remove(string name)
        {
            Hero nameHero = this.data.FirstOrDefault(x => x.Name == name);

            this.data.Remove(nameHero);
        }
        //•	Method GetHeroWithHighestStrength() – returns the Hero which poses the item with the highest stength.
        public Hero GetHeroWithHighestStrength()
        {
            int maxStrength = this.data.Max(x => x.Item.Strength);
            return this.data.FirstOrDefault(x => x.Item.Strength == maxStrength);
        }
        //•	Method GetHeroWithHighestAbility() – returns the Hero which poses the item with the highest ability.
        public Hero GetHeroWithHighestAbility()
        {
            int maxAbility = this.data.Max(x => x.Item.Ability);
            return this.data.FirstOrDefault(x => x.Item.Ability == maxAbility);
        }
        //•	Method GetHeroWithHighestIntelligence() – returns the Hero which poses the item with the highest intellgence.
        public Hero GetHeroWithHighestIntelligence()
        {
            int maxIntelligence = this.data.Max(x => x.Item.Intelligence);
            return this.data.FirstOrDefault(x => x.Item.Intelligence == maxIntelligence);
        }

        //•	Оverride ToString() – Print all the heroes.
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var hero in this.data)
            {
                sb.AppendLine(hero.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
