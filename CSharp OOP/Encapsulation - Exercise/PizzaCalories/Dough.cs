using System.Collections.Generic;

namespace PizzaCalories
{
    using System;
    public class Dough
    {
        private const double BaseDoughCalories = 2;

        private string flourType; // видове брашно
        private string bakingTechnique; // техника на печене
        private double white;

        private Dictionary<string, double> validFlourTypes;
        private Dictionary<string, double> validBakingTechnique;

        public Dough(string flourType, string bakingTechnique, double white)
        {
            this.validFlourTypes = new Dictionary<string, double>();
            this.validBakingTechnique = new Dictionary<string, double>();
            this.SeedFlourType();
            this.SeedBakingTechnique();

            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.White = white;



        }

        public string FlourType
        {
            get => this.flourType;
            set
            {
                if (!validFlourTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get =>this.bakingTechnique;
            set
            {
                if (!validBakingTechnique.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }

        }

        public double White
        {
            get => this.white;
            set
            {
                if (value <1 || value >200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.white = value;
            }
        }
        public double CalculateCalories()
        {
            return BaseDoughCalories * this.White * this.validFlourTypes[this.FlourType.ToLower()] *
                   this.validBakingTechnique[this.BakingTechnique.ToLower()];
        }
        public void SeedFlourType()
        {
            this.validFlourTypes.Add("white",1.5);
            this.validFlourTypes.Add("wholegrain", 1.0);
        }
        public void SeedBakingTechnique()
        {
            this.validBakingTechnique.Add("crispy", 0.9);
            this.validBakingTechnique.Add("chewy", 1.1);
            this.validBakingTechnique.Add("homemade", 1.0);
        }
    }
}
