using System;
using System.Text;

namespace Heroes
{
    public class Hero
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public Item Item { get; set; }

        public Hero(string name, int level, Item item)
        {
            this.Name = name;
            this.Level = level;
            this.Item = item;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            return sb.AppendLine($"Hero: {this.Name} – {this.Level}lvl")
                   + Item.ToString();
        }
    }
}
