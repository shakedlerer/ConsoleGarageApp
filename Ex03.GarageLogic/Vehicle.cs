using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_Model;
        protected readonly string r_LicenseNumber;
        //protected float m_EnergyLeft;
        protected List<Tire> m_SetOfTires;
        protected Engine m_Engine;

        // C'TOR :
        public Vehicle(string i_LicenseNumber, Engine i_Engine)
        {
            r_LicenseNumber = i_LicenseNumber;
            m_Engine = i_Engine;
        }

        // PROPERTIES :

        public string ModelName
        {
            set { m_Model = value; }
            get { return m_Model; }
        }

        public Engine Engine
        {
            get { return m_Engine; }
            //set { m_Engine = value; }                 // Avital put this in comment because when adding a new fuel bike it asked to enter value for the field Engine
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

        public float CurrentEnergy
        {
            //set { m_Engine.EnergyUnitLeft = value; }
            get
            {
                return m_Engine.EnergyUnitLeft;
            }
        }

        public float MaxEnergy
        {
            get { return m_Engine.MaxEnergyUnit; }
        }

        public int NumOfWheels
        {
            get { return m_SetOfTires.Count; }
        }

        public string TiresManufactor
        {
            set
            {
                SetTiresManufactor(value);
            }
            get
            {
                return m_SetOfTires[0].ManufactoryName;
            }
        }

        public float CurrentAirInWheels
        {
            //set { SetWheelsPressure(value); }         // Avital put this in comment because when adding a new fuel bike it asked to enter value for the field CurrentAirInWheels
            get
            {
                return m_SetOfTires[0].AirPressure;
            }
        }

        public float MaxWheelsPressure
        {
            get { return m_SetOfTires[0].MaxAirPressure; }
        }

        // METHODS:

        public void Fill(float i_ToFill)
        {
            m_Engine.FillEnergy(i_ToFill);
        }

        protected void initializeTires(float i_MaxPressure, int i_NumOfTires)
        {
            m_SetOfTires = new List<Tire>(i_NumOfTires);

            for (int i = 0; i < i_NumOfTires; i++)
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
        public void SetTiresAirPressure(float i_PressureToSet)
        {
            foreach (Tire wheel in m_SetOfTires)
            {
                wheel.AirPressure = i_PressureToSet;
            }
        }

        public void SetTiresManufactor(string i_TiresManufactor)
        {
            foreach (Tire tire in m_SetOfTires)
            {
                tire.ManufactoryName = i_TiresManufactor;
            }
        }

        public string GetLicenseNumber()
        {
            return r_LicenseNumber;
        }

        // TODO Delete comments below:

        //        public override string ToString()
        //        {
        //            return string.Format(@"Model Name:{0}
        //License Number:{1}
        //Energy Left:{2}
        //{3}
        //{4}", m_ModelName, r_LicenseNumber, m_Engine.EnergyUnitLeft, m_SetOfTires[0].ToString(), m_Engine.ToString());
        //}

        //private float getEnergyLeft()
        //{
        //    return m_Engine.EnergyUnitLeft;
        //}

        //public string ManufactoryName
        //{
        //    set { SetWheelsManufactory(value); }
        //    get { return m_SetOfTires[0].ManufactoryName; }
        //}

        //public Vehicle(string i_LicenseNumber, Engine i_Engine, List<Tire> i_Wheels)
        //{
        //    r_LicenseNumber = i_LicenseNumber;
        //    m_Engine = i_Engine;
        //    m_SetOfTires = i_Wheels;
        //}
    }
}
