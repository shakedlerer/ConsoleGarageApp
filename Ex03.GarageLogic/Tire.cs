using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Tire
    {
        private float m_CurrentPressure;
        private readonly float r_MaxPressure;
        private string m_ManufactoryName;
        private const int k_MinToFill = 0;

        public override string ToString()
        {
            return string.Format("Current Pressure:{1}{0}Maximum Pressure:{2}{0}ManuFactory Name:{3}", Environment.NewLine, m_CurrentPressure, r_MaxPressure, m_ManufactoryName);
        }

        public Tire(float i_MaxPressure)
        {
            r_MaxPressure = i_MaxPressure;
        }
        public Tire(float i_CurrentPressure, float i_MaxPressure, string i_ManufactoryName)
        {
            m_CurrentPressure = i_CurrentPressure;
            r_MaxPressure = i_MaxPressure;
            m_ManufactoryName = i_ManufactoryName;
        }

        public string ManufactoryName
        {
            set { m_ManufactoryName = value; }
            get { return m_ManufactoryName; }
        }
        public float AirPressure
        {
            set
            {
                if (value < k_MinToFill || value > r_MaxPressure)
                {
                    throw new ValueOutOfRangeException("Can't fill this amount of air",k_MinToFill, r_MaxPressure);
                }
                m_CurrentPressure = value;
            }
            get { return m_CurrentPressure; }
        }

        public float MaxAirPressure
        {
            get { return r_MaxPressure; }
        }

        public void FillToMaximum()
        {
            m_CurrentPressure = r_MaxPressure;
        }

        public void FillPressure(float i_AmoutOfAir)
        {
            if (m_CurrentPressure + i_AmoutOfAir <= r_MaxPressure)
            {
                m_CurrentPressure += i_AmoutOfAir;
            }
            else
            {
                throw new ValueOutOfRangeException(k_MinToFill, r_MaxPressure);
            }
        }
    }
}