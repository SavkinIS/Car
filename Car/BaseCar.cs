using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    public enum CarTypes
    {
        PassengerCar, Truck, SportCar
    }

    public abstract class BaseCar
    {
        private CarTypes _carType;
        private float _averageFuelConsumption;
        private float _fuelCapacity;
        private float _speed;
        internal float _maxDistationBase;
        internal float _maxDistation;

        public float AverageFuelConsumption { get => _averageFuelConsumption; set => _averageFuelConsumption = value; }
        public float FuelCapacity { get => _fuelCapacity; set => _fuelCapacity = value; }
        public float Speed { get => _speed; set => _speed = value; }
        public CarTypes CarType { get => _carType;}

        public BaseCar(CarTypes carType, float averageFuelConsumption, float fuelCapacity, float speed)
        {
            _carType = carType;
            _averageFuelConsumption = averageFuelConsumption;
            _fuelCapacity = fuelCapacity;
            _speed = speed;
        }


        public virtual float MaxDisance(float? fuelValue = null)
        {            
            _maxDistationBase = fuelValue.HasValue ? fuelValue.Value : _fuelCapacity / _averageFuelConsumption;
            return _maxDistationBase;
        }

        public float ArrivalTimeByMinutes()
        {
            var time = _maxDistationBase / _speed;
            return time * 60;
        }

        public abstract string TextToPrint();
    }

    public class SportCar : BaseCar
    {
        public SportCar(CarTypes carType, float averageFuelConsumption, float fuelCapacity, float speed) 
            : base(carType, averageFuelConsumption, fuelCapacity, speed)
        {
        }

        public override string TextToPrint()
        {
            return $"максимальное растояние {MaxDisance().ToString("##,#")}км,  за {ArrivalTimeByMinutes().ToString("##,#")} минут";
        }
    }
}
