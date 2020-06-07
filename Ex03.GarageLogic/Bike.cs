using System;

namespace Ex03.GarageLogic
{
    public class Bike : Vehicle
    {
        private const int k_BikeNumberOfWheels = 2;
        private const float k_BikeMaxPressure = 30f;
        private const string k_InvalidEngineSize = "Error: Invalid engine size, please try again";
        private VehiclesEnums.eBikeLicenseType m_LicenseType;
        private int m_EngineSize;

        public Bike(string i_LicenseNumber, Engine i_Engine) : base(i_LicenseNumber, i_Engine)
        {
            initializeTires(k_BikeMaxPressure, k_BikeNumberOfWheels);
        }

        public VehiclesEnums.eBikeLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public int EngineSize
        {
            get { return m_EngineSize; }

            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException(k_InvalidEngineSize);
                }

                m_EngineSize = value;
            }
        }
    }
}