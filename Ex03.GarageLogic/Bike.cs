using System;

namespace Ex03.GarageLogic
{
    class Bike : Vehicle
    {
        private const int k_BikeNumberOfWheels = 2;
        private const float k_BikeMaxPressure = 30f;
        private VehiclesEnums.eBikeLicenseType m_LicenseType;
        private int m_EngineSize;

        // C'TOR :
        public Bike(string i_LicenseNumber, Engine i_Engine) : base(i_LicenseNumber, i_Engine)
        {
            initializeTires(k_BikeMaxPressure, k_BikeNumberOfWheels);
        }

        // PROPERTIES :
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
                    throw new ArgumentException("Error: Negative engine size, please try again.");
                }

                m_EngineSize = value;
            }
        }
    }
}