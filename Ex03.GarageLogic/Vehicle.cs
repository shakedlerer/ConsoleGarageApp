using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_Model;
        protected readonly string r_LicenseNumber;
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
            get { return m_Engine.EnergyUnitLeft; }
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
            set { SetTiresManufacturer(value); }
            get { return m_SetOfTires[0].Manufacturer; }
        }

        public float CurrentAirInWheels
        {
            get { return m_SetOfTires[0].AirPressure; }
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

        public void SetTiresManufacturer(string i_TiresManufacturer)
        {
            foreach (Tire tire in m_SetOfTires)
            {
                tire.Manufacturer = i_TiresManufacturer;
            }
        }

        public string GetLicenseNumber()
        {
            return r_LicenseNumber;
        }
    }
}
