using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        //private eColor m_Color;
        private VehiclesEnums.eColor m_Color;
        //private eNumberOfDoors m_NumberOfDoors;
        private VehiclesEnums.eNumberOfDoors m_NumberOfDoors;

        private const int k_CarNumberOfWheels = 4;
        private const float k_CarMaxPressure = 32f;


        //public Car(string i_LicenseNumber, Engine i_Engine, List<Tire> i_Wheels) : base(i_LicenseNumber, i_Engine, i_Wheels)
        //{

        //}

        public Car(string i_LicenseNumber, Engine i_Engine) : base(i_LicenseNumber, i_Engine)
        {
            initializeWheels(k_CarMaxPressure, k_CarNumberOfWheels);
        }

        //public eNumberOfDoors NumberOfDoors
        //{
        //    set { m_NumberOfDoors = value; }
        //    get { return m_NumberOfDoors; }
        //}
        public VehiclesEnums.eNumberOfDoors NumberOfDoors
        {
            set { m_NumberOfDoors = value; }
            get { return m_NumberOfDoors; }
        }

        //public eColor Color
        //{
        //    set { m_Color = value; }
        //    get { return m_Color; }
        //}

        public VehiclesEnums.eColor Color
        {
            set { m_Color = value; }
            get { return m_Color; }
        }

        public string FuelType
        {
            get
            {
                if (m_Engine is FuelEngine)
                {
                    return ((FuelEngine)m_Engine).FuelType.ToString();
                }
                else
                {
                    return null;
                }
            }
        }

        public float MaxEnergy
        {
            get { return base.Engine.MaxEnergyUnit; }
        }

        public Engine engine
        {
            get { return m_Engine; }
        }
    }
}