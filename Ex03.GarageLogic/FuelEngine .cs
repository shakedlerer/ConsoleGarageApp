using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class FuelEngine : Engine
    {
        //private eFuelType r_FuelType;
        private VehiclesEnums.eFuelType r_FuelType;

        //public FuelEngine(float i_MaxFuelCapacity, eFuelType i_FuelType) :
        //    base(i_MaxFuelCapacity)
        //{
        //    r_FuelType = i_FuelType;
        //}

        public FuelEngine(float i_MaxFuelCapacity, VehiclesEnums.eFuelType i_FuelType) :
            base(i_MaxFuelCapacity)
        {
            r_FuelType = i_FuelType;
        }

        //public void Fill(float i_AmoutOfLiters, eFuelType i_FuelType)
        //{
        //    if (r_FuelType == i_FuelType)
        //    {
        //        try {
        //            Fill(i_AmoutOfLiters);
        //        }
        //        catch (ValueOutOfRangeException e)
        //        {
        //            string msg = "Can't fill this much Fuel";
        //            throw new ValueOutOfRangeException(msg, e.MinValue, e.MaxValue);
        //        }
        //    }
        //    else
        //    {
        //        throw new ArgumentException(string.Format(@"Error: Incorrect Fuel entered, correct fuel type is {0}
        //                                                    ", r_FuelType));
        //    }
        //}

        public void Fill(float i_AmountOfLiters, VehiclesEnums.eFuelType i_FuelType)
        {
            if (r_FuelType == i_FuelType)
            {
                try
                {
                    Fill(i_AmountOfLiters);
                }
                catch (ValueOutOfRangeException e)
                {
                    string msg = "Can't fill this much Fuel";
                    throw new ValueOutOfRangeException(msg, e.MinValue, e.MaxValue);
                }
            }
            else
            {
                throw new ArgumentException(string.Format(@"Error: Incorrect Fuel entered, correct fuel type is {0}
                                                            ", r_FuelType));
            }
        }

        public override string ToString()
        {
            return string.Format(@"Fuel engine
FuelType: {0}
Current amount of liters: {1}
Maximum amount of liters: {2}", r_FuelType, m_EnergyUnitLeft, m_MaxEnergyUnit);

        }

        //public eFuelType FuelType
        //{
        //    set
        //    {
        //        if (Enum.IsDefined(typeof(eFuelType), value))
        //        {
        //            r_FuelType = value;
        //        }
        //        else
        //        {
        //            string errorMessage = string.Format("Error: Invalid Fuel type");
        //            throw new ArgumentException(errorMessage);
        //        }
        //    }
        //    get { return r_FuelType; }
        //}

        public VehiclesEnums.eFuelType FuelType
        {
            set
            {
                if (Enum.IsDefined(typeof(eFuelType), value))
                {
                    r_FuelType = value;
                }
                else
                {
                    string errorMessage = string.Format("Error: Invalid Fuel type");
                    throw new ArgumentException(errorMessage);
                }
            }
            get { return r_FuelType; }
        }

        public float MaxFuelCapacity
        {
            get { return m_MaxEnergyUnit; }
        }

        public float CurrentFuelCapacity
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