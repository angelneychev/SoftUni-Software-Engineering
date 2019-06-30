namespace P01_RawData
{
   public class Cargo
   {
        //int cargoWeight, string cargoType
        private string type;
        private int weight;

        // правим конструктор задължително за да ги сетнем
        public Cargo(int weight, string type)
        {
            this.weight = weight;
            this.Type = type;
        }

        public string Type { get; private set; }
   }
}
