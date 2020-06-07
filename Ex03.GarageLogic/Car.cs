namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        private const int k_CarNumberOfWheels = 4;
        private const float k_CarMaxPressure = 32f;
        private VehiclesEnums.eColor m_Color;
        private VehiclesEnums.eNumberOfDoors m_NumberOfDoors;

        // C'TOR :
        public Car(string i_LicenseNumber, Engine i_Engine) : base(i_LicenseNumber, i_Engine)
        {
            initializeTires(k_CarMaxPressure, k_CarNumberOfWheels);
        }

        // PROPERTIES :
        public VehiclesEnums.eNumberOfDoors NumberOfDoors
        {
            get { return m_NumberOfDoors; }
            set { m_NumberOfDoors = value; }
        }

        public VehiclesEnums.eColor Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }
    }
}