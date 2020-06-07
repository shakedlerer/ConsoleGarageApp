namespace Ex03.GarageLogic
{
    public class Tire
    {
        private const string k_InvalidAirAmount = "Can't fill this amount of air in tires";
        private const int k_MinToFill = 0;
        private readonly float r_MaxPressure;
        private float m_CurrentPressure;
        private string m_Manufacturer;

        public Tire(float i_MaxPressure)
        {
            r_MaxPressure = i_MaxPressure;
            m_CurrentPressure = 0;
        }

        public string Manufacturer
        {
            get { return m_Manufacturer; }
            set { m_Manufacturer = value; }
        }

        public float AirPressure
        {
            get { return m_CurrentPressure; }
            set { m_CurrentPressure = value; }
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