using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class Bike : Vehicle
    {
        private eBikeLicenseType m_LicenseType;
        private int m_EngineSize;
        private string m_ModelName;

//        public override string ToString()
//        {
//            return string.Format(@"{0}
//Bike License Type:{1}
//Energy Size:{2}", base.ToString(), m_LicenseType, m_EngineSize);
//        }

        public Bike(string i_LicenseNumber, Engine i_Engine, List<Tire> i_Wheels) :
            base(i_LicenseNumber, i_Engine, i_Wheels)
        {
        }

        //public float CurrentEnergy
        //{
        //    set { m_EnergyLeft = value; }
        //    get
        //    {
        //        return m_EnergyLeft;
        //    }
        //}
        public eBikeLicenseType LicenseType
        {
            set { m_LicenseType = value; }
            get
            {
                return m_LicenseType;
            }
        }
        public int EngineSize
        {
            set { m_EngineSize = value; }
            get
            {
                return m_EngineSize;
            }
        }
        public string ModelName
        {
            set { m_ModelName = value; }
            get
            {
                return m_ModelName;
            }
        }

    }
}