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
        protected readonly List<Tire> r_CollectionOfWheels;
        protected Engine r_Engine;

        public void FillAllWhellsToMaximum()
        {
            foreach (Tire wheel in r_CollectionOfWheels)
            {
                wheel.FillToMaximum();
            }
        }
        public void SetWheelsPressure(float i_PressureToSet)
        {
            foreach (Tire wheel in r_CollectionOfWheels)
            {
                wheel.AirPressure = i_PressureToSet;
            }
        }

        public void SetWheelsManufactory(string i_ManufactoryName)
        {
            foreach (Tire wheel in r_CollectionOfWheels)
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
//{4}", m_ModelName, r_LicenseNumber, r_Engine.EnergyUnitLeft, r_CollectionOfWheels[0].ToString(), r_Engine.ToString());


//        }

        public Vehicle(string i_LicenseNumber, Engine i_Engine, List<Tire> i_Wheels)
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

        //private float getEnergyLeft()
        //{
        //    return r_Engine.EnergyUnitLeft;
        //}

        public float CurrentEnergy
        {
            set { r_Engine.EnergyUnitLeft = value; }
            get
            {
                return r_Engine.EnergyUnitLeft;
            }
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
            set { r_Engine = value; }
        }

        public void Fill(float i_ToFill)
        {
            r_Engine.Fill(i_ToFill);
        }
        public float CurrentAirInWheels
        {
            set { SetWheelsPressure(value); }
            get
            {
                return r_CollectionOfWheels[0].AirPressure;
            }
        }
        public string ManufactoryName
        {
            set { SetWheelsManufactory(value); }
        }


    }
}
