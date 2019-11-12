namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;

    public class Country
    {
        //•	Country – CountryId, Name   
        //•	A Town can be placed in one Country and a Country can have many Towns
        public int CountryId { get; set; }
        public string Name { get; set; }

        public ICollection<Town> Towns { get; set; } = new HashSet<Town>();
    }
}
