using System;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const int k_TruckNumberOfWheels = 16;
        private const float k_TruckMaxPressure = 28f;
        private const string k_InvalidCargoCapacity = "Invalid cargo capacity, please try again.";
        private bool m_IsHoldsDangerCargo;
        private float m_CargoCapacity;

        public Truck(string i_LicenseNumber, Engine i_Engine) : base(i_LicenseNumber, i_Engine)
        {
            initializeTires(k_TruckMaxPressure, k_TruckNumberOfWheels);
        }

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
                    throw new ArgumentException(k_InvalidCargoCapacity);
                }

                m_CargoCapacity = value;
            }
        }
    }
}