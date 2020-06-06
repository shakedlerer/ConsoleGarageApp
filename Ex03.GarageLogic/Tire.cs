namespace Ex03.GarageLogic
{
    public class Tire
    {
        private float m_CurrentPressure;
        private readonly float r_MaxPressure;
        private string m_Manufacturer;
        private const int k_MinToFill = 0;

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
            set { m_Manufacturer = value; }
            get { return m_Manufacturer; }
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
    }
}