using System;

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

        public void FillEnergy(float i_AmountToFill)
        {
            if (m_EnergyUnitLeft + i_AmountToFill <= m_MaxEnergyUnit)
            {
                m_EnergyUnitLeft += i_AmountToFill;
                Console.WriteLine(string.Format("Successfully filled! {0}{0}", Environment.NewLine));
            }
            else
            {
                float ableToFill = m_MaxEnergyUnit - m_EnergyUnitLeft;
                throw new ValueOutOfRangeException(k_MinToFill, ableToFill);
            }
        }
    }
}