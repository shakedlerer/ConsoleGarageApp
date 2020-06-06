using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

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

        // TODO Delete comments below:

        //        public override string ToString()
        //        {
        //            return string.Format(@"{0}
        //Holds Danager Cargo:{1}
        //Cargo capacity:{2}", base.ToString(), m_IsHoldsDangerCargo, m_CargoCapacity);
        //        }

        //public Truck(string i_LicenseNumber, Engine i_Engine,
        //             List<Tire> i_Wheels) :
        //    base(i_LicenseNumber, i_Engine, i_Wheels)
        //{
        //}

        //public float CurrentEnergy
        //{
        //    set { m_EnergyLeft = value; }
        //}

    }
}