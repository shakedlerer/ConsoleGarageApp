using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        private eColor m_Color;
        private eNumberOfDoors m_NumberOfDoors;

        public Car(string i_LicenseNumber, Engine i_Engine, List<Tire> i_Wheels) : base(i_LicenseNumber, i_Engine, i_Wheels)
        {
        }


        public eNumberOfDoors NumberOfDoors
        {
            set { m_NumberOfDoors = value; }
            get { return m_NumberOfDoors; }
        }

        public eColor Color
        {
            set { m_Color = value; }
            get { return m_Color; }
        }

        public string FuelType
        {
            get
            {
                if (r_Engine is FuelEngine)
                {
                    return ((FuelEngine)r_Engine).FuelType.ToString();
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
            get { return r_Engine; }
        }
    }
}