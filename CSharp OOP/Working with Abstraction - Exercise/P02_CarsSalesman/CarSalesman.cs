namespace P02_CarsSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CarSalesman
    {
        private CarFactory carFactory;
        private EngineFactory engineFactory;

        private List<Car> cars;
        private List<Engine> engines;

        public CarSalesman(CarFactory carFactory, EngineFactory engineFactory)
        {
            this.carFactory = carFactory;
            this.engineFactory = engineFactory;
            this.cars =new List<Car>();
            this.engines=new List<Engine>();
        }

        public void AddEngine(string[] parameters)
        {
            Engine engine = engineFactory.Create(parameters);
            engines.Add(engine);
        }

        public void AddCar(string[] parameters)
        {
            Car car = carFactory.Create(parameters, this.engines);
            cars.Add(car);
        }

        public List<Car> GeCars()
        {
            return this.cars;
        }
    }
}
