using System;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private bool m_IsHoldsDangerCargo;
        private float m_CargoCapacity;
        private const int k_TruckNumberOfWheels = 16;
        private const float k_TruckMaxPressure = 28f;

        // C'TOR :
        public Truck(string i_LicenseNumber, Engine i_Engine) : base(i_LicenseNumber, i_Engine)
        {
            initializeTires(k_TruckMaxPressure, k_TruckNumberOfWheels);
        }

        // PROPERTIES :
        public bool IsHoldsDangerCargo
        {
            set { m_IsHoldsDangerCargo = value; }
            get { return m_IsHoldsDangerCargo; }
        }
        public float CargoCapacity
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cargo Capacity can't be negative, please try again...");
                }
                m_CargoCapacity = value;
            }
            get { return m_CargoCapacity; }
        }
    }
}