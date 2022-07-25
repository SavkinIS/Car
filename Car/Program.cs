using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<CarTypes, string> carsDictionary = new Dictionary<CarTypes, string>();
            carsDictionary.Add(CarTypes.Truck, "Грузовик");
            carsDictionary.Add(CarTypes.PassengerCar, "Легковой");
            carsDictionary.Add(CarTypes.SportCar, "Спортивный");


            SportCar sportCar = new SportCar(CarTypes.SportCar, 15f, 100f, 150f);
            Truck truck = new Truck(carType: CarTypes.Truck,
                                    averageFuelConsumption: 25f,
                                    fuelCapacity: 500f,
                                    speed: 80f,
                                    loadCapacity: 1000f,
                                    maxLoadCapacity: 8000f);

            PassengerCar passengerCar = new PassengerCar(carType: CarTypes.PassengerCar,
                                    averageFuelConsumption: 8f,
                                    fuelCapacity: 80f,
                                    speed: 120f,
                                    passengerCount: 4);

            List<BaseCar> cars = new List<BaseCar> { sportCar, truck, passengerCar };

            cars.ForEach(c =>
            {
                Console.WriteLine($"Автомобиль типа {carsDictionary[c.CarType]} {c.TextToPrint()}");
            });



            Console.ReadKey();
        }
    }
}
