using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected readonly string r_LicenseNumber;
        //protected float m_EnergyLeft;
        protected List<Tire> m_SetOfTires;
        protected Engine m_Engine;

        //public Vehicle(string i_LicenseNumber, Engine i_Engine, List<Tire> i_Wheels)
        //{
        //    r_LicenseNumber = i_LicenseNumber;
        //    m_Engine = i_Engine;
        //    m_SetOfTires = i_Wheels;
        //}

        public Vehicle(string i_LicenseNumber, Engine i_Engine)
        {
            r_LicenseNumber = i_LicenseNumber;
            m_Engine = i_Engine;
        }

        protected void initializeWheels(float i_MaxPressure, int i_NumOfWheels)
        {
            m_SetOfTires = new List<Tire>(i_NumOfWheels);

            for (int i = 0; i < i_NumOfWheels; i++)
            {
                Tire tire = new Tire(i_MaxPressure);
                m_SetOfTires.Add(tire);
            }
        }

        public void FillAllTiresToMaximum()
        {
            foreach (Tire wheel in m_SetOfTires)
            {
                wheel.FillToMaximum();
            }
        }
        public void SetWheelsPressure(float i_PressureToSet)
        {
            foreach (Tire wheel in m_SetOfTires)
            {
                wheel.AirPressure = i_PressureToSet;
            }
        }

        // TODO: What does this method do ?
        public void SetWheelsManufactory(string i_ManufactoryName)
        {
            foreach (Tire wheel in m_SetOfTires)
            {
                wheel.ManufactoryName = i_ManufactoryName;
            }
        }


//        public override string ToString()
//        {
//            return string.Format(@"Model Name:{0}
//License Number:{1}
//Energy Left:{2}
//{3}
//{4}", m_ModelName, r_LicenseNumber, m_Engine.EnergyUnitLeft, m_SetOfTires[0].ToString(), m_Engine.ToString());


//        }



        public string ModelName
        {
            set { m_ModelName = value; }
            get { return m_ModelName; }
        }

        //private float getEnergyLeft()
        //{
        //    return m_Engine.EnergyUnitLeft;
        //}

        public float CurrentEnergy
        {
            set { m_Engine.EnergyUnitLeft = value; }
            get
            {
                return m_Engine.EnergyUnitLeft;
            }
        }

        public string License
        {
            get { return r_LicenseNumber; }
        }

        public int NumOfWheels
        {
            get { return m_SetOfTires.Count; }
        }

        public float MaxWheelsPressure
        {
            get { return m_SetOfTires[0].MaxAirPressure; }
        }

        public Engine Engine
        {
            get { return m_Engine; }
            set { m_Engine = value; }
        }

        public void Fill(float i_ToFill)
        {
            m_Engine.Fill(i_ToFill);
        }
        public float CurrentAirInWheels
        {
            set { SetWheelsPressure(value); }
            get
            {
                return m_SetOfTires[0].AirPressure;
            }
        }
        public string ManufactoryName
        {
            set { SetWheelsManufactory(value); }
        }


    }
}
