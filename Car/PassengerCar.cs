namespace Car
{
    public class PassengerCar : BaseCar
    {
        private int _passengerCount;
        private const float _reductionRatio = 6;

        public PassengerCar(CarTypes carType, float averageFuelConsumption, float fuelCapacity, float speed, int passengerCount)
            : base(carType, averageFuelConsumption, fuelCapacity, speed)
        {
            _passengerCount = passengerCount;
        }

        public override float MaxDisance(float? fuelValue = null)
        {
            base.MaxDisance(fuelValue);
            float onePercent = _maxDistationBase / 100;
            _maxDistation = _passengerCount * (onePercent * _reductionRatio);
            return _maxDistation;
        }

        public int MaxPassengers(float destination)
        {
            int maxPassenger = 0;
            float onePErcent = destination / 100;
            maxPassenger = (int)(destination / (onePErcent * _reductionRatio));
            return maxPassenger;
        }

        public override string TextToPrint()
        {
            return $"максимальное растояние {MaxDisance().ToString("##,#")}км, за {ArrivalTimeByMinutes().ToString("##,#")} минут c {_passengerCount} {(_passengerCount == 1 ? "пасажиром" : "пасажирами")}.";
        }
    }
}
