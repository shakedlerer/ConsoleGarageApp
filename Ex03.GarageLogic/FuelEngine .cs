using System;

namespace Ex03.GarageLogic
{
    class FuelEngine : Engine
    {
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
                    string msg = "Error: Can't fill this much fuel, please try again";
                    throw new ValueOutOfRangeException(msg, e.MinValue, e.MaxValue);
                }
            }
            else
            {
                throw new ArgumentException(string.Format("Error: Incorrect fuel type selected, the correct fuel type is {0} {1}{1}{1}", m_FuelType, Environment.NewLine));
            }
        }

        public override string ToString()
        {
            return GetType().Name;
        }

        public VehiclesEnums.eFuelType FuelType
        {
            set
            {
                if (Enum.IsDefined(typeof(VehiclesEnums.eFuelType), value))
                {
                    m_FuelType = value;
                }
                else
                {
                    string errorMessage = string.Format("Error: Invalid Fuel type");
                    throw new ArgumentException(errorMessage);
                }
            }
            get { return m_FuelType; }
        }
    }
}