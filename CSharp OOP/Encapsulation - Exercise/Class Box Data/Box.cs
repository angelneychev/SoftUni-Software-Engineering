namespace Class_Box_Data
{
    using System;
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Height = height;
            this.Width = width;
            this.Lenght = length;
        }
        public double Height
        {
            get { return this.height; }
            set {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }


        public double Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }

        public double Lenght
        {
            get { return this.length; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Lenght cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        public string SurfaceArea()
        {
            double surfaceArea = 2 * length * width + 2 * length * height + 2 * width * height;


            return $"Surface Area - {surfaceArea:F2}";

        }

        public string LateralSurfaceArea()
        {
            double lateralSurfaceArea = 2 * length * height + 2 * width * height;
            return $"Lateral Surface Area - {lateralSurfaceArea:f2}";
        }

        public string Volume()
        {
            double volume = height * width * length;
            return $"Volume - {volume:f2}";
        }
    }
}
