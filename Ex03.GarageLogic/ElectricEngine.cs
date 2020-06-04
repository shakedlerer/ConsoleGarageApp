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

        public void FillEnergy(float i_EnergyToFill)
        {
            base.Fill(i_EnergyToFill);
        }

        public float CurrentElectricityCapacity
        {
            set { base.Energy = value; }
            get { return base.Energy; }
        }

    }
}