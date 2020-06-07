using System;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        const string k_InvalidFuelAmount = "Error: Can't fill this much fuel, please try again";
        const string k_InvalidFuelType = "Error: Incorrect fuel type selected, the correct fuel type is {0} {1}{1}";
        private VehiclesEnums.eFuelType m_FuelType;

        public FuelEngine(float i_MaxFuelCapacity, VehiclesEnums.eFuelType i_FuelType) :
            base(i_MaxFuelCapacity)
        {
            m_FuelType = i_FuelType;
        }

        public void FillFuel(float i_AmountOfLiters, VehiclesEnums.eFuelType i_FuelType)
        {
            if (m_FuelType == i_FuelType)
            {
                try
                {
                    FillEnergy(i_AmountOfLiters);
                }
                catch (ValueOutOfRangeException e)
                {
                    throw new ValueOutOfRangeException(k_InvalidFuelAmount, e.MinValue, e.MaxValue);
                }
            }
            else
            {
                throw new ArgumentException(string.Format(k_InvalidFuelType, m_FuelType, Environment.NewLine));
            }
        }

        public override string ToString()
        {
            return GetType().Name;
        }

        public VehiclesEnums.eFuelType FuelType
        {
            get { return m_FuelType; }
            set { m_FuelType = value; }
        }
    }
}