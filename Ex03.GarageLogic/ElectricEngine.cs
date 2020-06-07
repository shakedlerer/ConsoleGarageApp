namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        const string k_InvalidChargingTime = "Error: Can't charge this much time, please try again";

        public ElectricEngine(float i_MaxHours) :
            base(i_MaxHours)
        {
        }

        public override string ToString()
        {
            return GetType().Name;
        }

        public void ChargeBattery(float i_MinutesToFill)
        {
            try
            {
                FillEnergy(i_MinutesToFill);
            }
            catch(ValueOutOfRangeException e)
            {
                throw new ValueOutOfRangeException(k_InvalidChargingTime, e.MinValue, e.MaxValue);
            }
        }
    }
}