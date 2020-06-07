namespace Ex03.GarageLogic
{
    public class Tire
    {
        private const int k_MinToFill = 0;
        private readonly float r_MaxPressure;
        private float m_CurrentPressure;
        private string m_Manufacturer;

        public Tire(float i_MaxPressure)
        {
            r_MaxPressure = i_MaxPressure;
        }

        public Tire(float i_CurrentPressure, float i_MaxPressure, string i_Manufacturer)
        {
            m_CurrentPressure = i_CurrentPressure;
            r_MaxPressure = i_MaxPressure;
            m_Manufacturer = i_Manufacturer;
        }

        public string Manufacturer
        {
            get { return m_Manufacturer; }
            set { m_Manufacturer = value; }
        }

        public float AirPressure
        {
            get { return m_CurrentPressure; }

            set
            {
                if (value < k_MinToFill || value > r_MaxPressure)
                {
                    throw new ValueOutOfRangeException("Can't fill this amount of air", k_MinToFill, r_MaxPressure);
                }

                m_CurrentPressure = value;
            }
        }

        public float MaxAirPressure
        {
            get { return r_MaxPressure; }
        }

        public void FillToMaximum()
        {
            m_CurrentPressure = r_MaxPressure;
        }
    }
}