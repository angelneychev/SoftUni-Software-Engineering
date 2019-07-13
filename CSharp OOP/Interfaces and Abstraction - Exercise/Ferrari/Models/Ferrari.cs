using Ferrari.Contracts;

namespace Ferrari.Models
{
    public class Ferrari : IDriveable
    {
        public string Driver { get; private set; }
        public string Model { get; private set; }

        public Ferrari(string driver)
        {
            this.Driver = driver;
            this.Model = "488-Spider";
        }
        
        public string GoBrakes()
        {
            return "Brakes!";
        }

        public string GoGas()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            return $"{Model}/{GoBrakes()}/{GoGas()}/{Driver}";
        }
    }
}
