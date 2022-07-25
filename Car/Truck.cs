using System;

namespace Car
{
    public class Truck : BaseCar
    {

        private float _loadCapacity;
        private float _maxLoadCapacity;
        private const float _reductionRatio = 4f;

        public Truck(CarTypes carType, float averageFuelConsumption, float fuelCapacity, float speed, float loadCapacity, float maxLoadCapacity) : base(carType, averageFuelConsumption, fuelCapacity, speed)
        {
            _loadCapacity = loadCapacity;
            _maxLoadCapacity = maxLoadCapacity;
        }

        public override float MaxDisance(float? fuelValue = null)
        {
            base.MaxDisance(fuelValue);
            float onePercent = _maxDistationBase / 100;
            _maxDistation = (float)(onePercent * Math.Truncate(_loadCapacity / 200) * _reductionRatio);
            return _maxDistation;
        }

        public bool CanLoad(float destination)
        {
            if (destination < _maxDistationBase)
            {
                float onePercent = _maxDistationBase / 100;
                float destinationWithMaxLoad = (float)(onePercent * Math.Truncate(_maxLoadCapacity / 200) * _reductionRatio);
                return destinationWithMaxLoad >= destination;
            }
            return false;
        }

        public override string TextToPrint()
        {
            return $"максимальное растояние {MaxDisance().ToString("##,#")}км,  за {ArrivalTimeByMinutes().ToString("##,#")} минут c грузом {_loadCapacity}кг.";
        }

    }
}
