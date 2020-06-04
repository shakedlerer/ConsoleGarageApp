using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxHours) :
            base(i_MaxHours)
        {
        }

        public override string ToString()
        {
            return string.Format(@"Electric engine
Hours left:{0}
Maximum loading time:{1}", m_EnergyUnitLeft, m_MaxEnergyUnit);
        }

        public void FillEnergy(float i_MinutesToFill)
        {
            try
            {
                Fill(i_MinutesToFill);
            }
            catch(ValueOutOfRangeException e)
            {
                string msg = "Can't charge this much Energy";
                throw new ValueOutOfRangeException(msg, e.MinValue, e.MaxValue);
            }
        }

        public float CurrentElectricityCapacity
        {
            set { m_EnergyUnitLeft = value; }
            get { return m_EnergyUnitLeft; }
        }

        //public float EnergyUnitLeft
        //{
        //    get { return m_EnergyUnitLeft; }
        //    set { m_EnergyUnitLeft = value; }
        //}

    }
}