namespace FoodShortage.Models
{
    using System;

    public class Robot
    {
        //“Robot <model> <id>”

        private string model;

        public Robot(string model, string id)
        {
            this.model = model;
            this.Id = id;
        }

        public string Id { get; private set; }
    }
}
