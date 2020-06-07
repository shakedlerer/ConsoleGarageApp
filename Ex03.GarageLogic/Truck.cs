using System;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private const int k_TruckNumberOfWheels = 16;
        private const float k_TruckMaxPressure = 28f;
        private bool m_IsHoldsDangerCargo;
        private float m_CargoCapacity;

        // C'TOR :
        public Truck(string i_LicenseNumber, Engine i_Engine) : base(i_LicenseNumber, i_Engine)
        {
            initializeTires(k_TruckMaxPressure, k_TruckNumberOfWheels);
        }

        // PROPERTIES :
        public bool IsHoldsDangerCargo
        {
            get { return m_IsHoldsDangerCargo; }
            set { m_IsHoldsDangerCargo = value; }
        }

        public float CargoCapacity
        {
            get { return m_CargoCapacity; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cargo Capacity can't be negative, please try again...");
                }

                m_CargoCapacity = value;
            }
        }
    }
}