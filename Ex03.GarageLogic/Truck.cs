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

        public override string ToString()
        {
            return string.Format(@"{0}
Holds Danager Cargo:{1}
Cargo capacity:{2}", base.ToString(), m_IsHoldsDangerCargo, m_CargoCapacity);
        }

        public Truck(string i_LicenseNumber, Engine i_Engine,
                     List<Tire> i_Wheels) :
            base(i_LicenseNumber, i_Engine, i_Wheels)
        {
        }

        public bool IsHoldsDangerCargo
        {
            set { m_IsHoldsDangerCargo = value; }
        }
        public float CargoCapacity
        {
            set { m_CargoCapacity = value; }
            get { return m_CargoCapacity; }
        }
        //public float CurrentEnergy
        //{
        //    set { m_EnergyLeft = value; }
        //}

    }
}