using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {

        private string m_ModelName;
        private readonly string r_LicenseNumber;
        protected float m_EnergyLeft;
        protected readonly List<Wheel> r_CollectionOfWheels;
        protected readonly Engine r_Engine;

        public void FillAllWhellsToMaximum()
        {
            foreach (Wheel wheel in r_CollectionOfWheels)
            {
                wheel.FillToMaximum();
            }
        }
        public void SetWheelsPressure(float i_PressureToSet)
        {
            foreach (Wheel wheel in r_CollectionOfWheels)
            {
                wheel.AirPressure = i_PressureToSet;
            }
        }

        public void SetWheelsManufactory(string i_ManufactoryName)
        {
            foreach (Wheel wheel in r_CollectionOfWheels)
            {
                wheel.ManufactoryName = i_ManufactoryName;
            }
        }


        public override string ToString()
        {
            return string.Format(@"Model Name:{0}
License Number:{1}
Energy Left:{2}
{3}
{4}", m_ModelName, r_LicenseNumber, m_EnergyLeft, r_CollectionOfWheels[0].ToString(), r_Engine.ToString());


        }
        public Vehicle(string i_LicenseNumber, Engine i_Engine, List<Wheel> i_Wheels)
        {
            r_LicenseNumber = i_LicenseNumber;
            r_Engine = i_Engine;
            r_CollectionOfWheels = i_Wheels;
        }

        public string ModelName
        {
            set { m_ModelName = value; }
            get { return m_ModelName; }
        }

        private float getEnergyLeft()
        {
            return r_Engine.EnergyUnitLeft;
        }

        public string License
        {
            get { return r_LicenseNumber; }
        }

        public int NumOfWheels
        {
            get { return r_CollectionOfWheels.Count; }
        }

        public float MaxWheelsPressure
        {
            get { return r_CollectionOfWheels[0].MaxAirPressure; }
        }

        public Engine Engine
        {
            get { return r_Engine; }
        }

        public void Fill(float i_ToFill)
        {
            r_Engine.Fill(i_ToFill);
        }
        public float CurrentAirInWheels
        {
            set { SetWheelsPressure(value); }
        }
        public string ManufactoryName
        {
            set { SetWheelsManufactory(value); }
        }


    }
}
