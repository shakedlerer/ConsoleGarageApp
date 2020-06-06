using System;
using System.Collections.Generic;
using System.Text;

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
            return GetType().Name;
        }

        public void ChargeBattery(float i_MinutesToFill)
        {
            try
            {
                FillEnergy(i_MinutesToFill);
            }
            catch(ValueOutOfRangeException e)
            {
                string msg = "Can't charge this much Energy";
                throw new ValueOutOfRangeException(msg, e.MinValue, e.MaxValue);
            }
        }

        // TODO Delete comments below:

        //public float CurrentElectricityCapacity
        //{
        //    set { m_EnergyUnitLeft = value; }
        //    get { return m_EnergyUnitLeft; }
        //}
    }
}