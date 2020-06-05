using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected float m_EnergyUnitLeft;
        protected float m_MaxEnergyUnit;
        protected const float k_MinToFill = 0;

        public float EnergyUnitLeft
        {
            get { return m_EnergyUnitLeft; }
            set { m_EnergyUnitLeft = value; }
        }
        public float MaxEnergyUnit
        {
            get { return m_MaxEnergyUnit; }
            set { m_MaxEnergyUnit = value; }

        }

        public Engine(float i_MaxEnergyUnit)
        {
            m_MaxEnergyUnit = i_MaxEnergyUnit;
        }

        //public float Energy
        //{
        //    //set
        //    //{
        //    //    if (value < k_MinToFill || value > m_MaxEnergyUnit)
        //    //    {
        //    //        throw new ValueOutOfRangeException("Can't charge this much energy,",k_MinToFill, m_MaxEnergyUnit);
        //    //    }
        //    //    m_MaxEnergyUnit = value;
        //    //}
        //    get { return m_EnergyUnitLeft; }
        //}

        public void Fill(float i_AmountToFill)
        {
            if (m_EnergyUnitLeft + i_AmountToFill <= m_MaxEnergyUnit)
            {
                m_EnergyUnitLeft += i_AmountToFill;
                Console.WriteLine(string.Format(@"Successfully filled!
"));
            }
            else
            {
                float ableToFill = m_MaxEnergyUnit - m_EnergyUnitLeft;
                Console.WriteLine();
                throw new ValueOutOfRangeException(k_MinToFill, ableToFill);
            }
        }
    }
}