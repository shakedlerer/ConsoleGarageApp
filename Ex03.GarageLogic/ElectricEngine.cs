﻿namespace Ex03.GarageLogic
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
                string msg = "Error: Can't charge this much time, please try again";
                throw new ValueOutOfRangeException(msg, e.MinValue, e.MaxValue);
            }
        }
    }
}