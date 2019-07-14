namespace BorderControl.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using BorderControl.Contracts;

    public class Robot : IRegisterable
    {
        private string model;

        public Robot(string model, string id)
        {
            this.model = model;
            this.Id = id;
        }


        public string Id { get; private set; }
    }
}
