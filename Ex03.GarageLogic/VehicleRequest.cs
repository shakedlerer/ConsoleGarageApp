using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class VehicleRequest
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_EnergyLeft;
        private int m_NumberOfWheels;
        private Engine m_Engine;
        private float m_CurrentFuelCapacity;
        private float m_HoursLeft;
        private bool v_IsHoldsDangerCargo;
        private float m_CargoCapacity;
        private int m_EngineBikeCapaicty;
        public bool[] m_CheckedList = new bool[9];

        // Change direct access to eFuel Type to access through VehiclesEnums
        //private eFuelType m_FuelType;
        private VehiclesEnums.eFuelType m_FuelType;
        //private eColor m_Color;
        private VehiclesEnums.eColor m_Color;
        //private eNumberOfDoors m_NumberOfDoors;
        private VehiclesEnums.eNumberOfDoors m_NumberOfDoors;
        //private eBikeLicenseType m_LicenseBikeType;
        private VehiclesEnums.eBikeLicenseType m_LicenseBikeType;

        public float CurrentFuelCapacity
        {
            get { return m_CurrentFuelCapacity; }
        }


        public VehiclesEnums.eFuelType FuelType
        {
            get { return m_FuelType; }
        }

        public void AnyVehicle(string i_ModelNAme, string i_LicenseNumber, float i_EnergyLeft
             , int i_NumberOfWheels, Engine i_Engine)
        {
            m_ModelName = i_ModelNAme;
            m_LicenseNumber = i_LicenseNumber;
            m_EnergyLeft = i_EnergyLeft;
            m_NumberOfWheels = i_NumberOfWheels;
            m_Engine = i_Engine;
        }

        public void FuelVehicle(VehiclesEnums.eFuelType i_FuelType, float i_CurrentFuelCapacity)
        {
            m_FuelType = i_FuelType;
            m_CurrentFuelCapacity = i_CurrentFuelCapacity;
            m_CheckedList[0] = true;
            m_CheckedList[1] = true;
        }

        public void ElectricVehicle(float i_HoursLeft)
        {
            m_HoursLeft = i_HoursLeft;
            m_CheckedList[2] = true;
        }

        public void CarVehicle(VehiclesEnums.eColor i_Color, VehiclesEnums.eNumberOfDoors i_NumberOfDoors)
        {
            m_Color = i_Color;
            m_NumberOfDoors = i_NumberOfDoors;
            m_CheckedList[3] = true;
            m_CheckedList[4] = true;
        }

        public void TruckVehicle(bool i_IsHoldsDangerCargo, float i_CargoCapacity)
        {
            v_IsHoldsDangerCargo = i_IsHoldsDangerCargo;
            m_CargoCapacity = i_CargoCapacity;
            m_CheckedList[5] = true;
            m_CheckedList[6] = true;
        }

        public void BikeVehicle(VehiclesEnums.eBikeLicenseType i_LicenseBikeType, int i_EngineBikeCapaicty)
        {
            m_LicenseBikeType = i_LicenseBikeType;
            m_EngineBikeCapaicty = i_EngineBikeCapaicty;
            m_CheckedList[7] = true;
            m_CheckedList[8] = true;
        }

        public string ModelName
        {
            get { return m_ModelName; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
        }

        public float HoursLeft
        {
            get { return m_HoursLeft; }
        }

        public VehiclesEnums.eColor CarColor
        {
            get { return m_Color; }
        }

        public VehiclesEnums.eNumberOfDoors NumberOfDoors
        {
            get { return m_NumberOfDoors; }
        }

        public bool IsHoldDangerCargo
        {
            get { return v_IsHoldsDangerCargo; }
        }

        public float CargoCapacity
        {
            get { return m_CargoCapacity; }
        }

        public VehiclesEnums.eBikeLicenseType LicenseBikeType
        {
            get { return m_LicenseBikeType; }
        }

        public int EngineBikeCapacity
        {
            get { return m_EngineBikeCapaicty; }
        }

        public bool[] CheckedList
        {
            get { return m_CheckedList; }
        }

        // TODO Delete comments below:

        //public eFuelType FuelType
        //{
        //    get { return m_FuelType; }
        //}

        //public void FuelVehicle(eFuelType i_FuelType, float i_CurrentFuelCapacity)
        //{
        //    m_FuelType = i_FuelType;
        //    m_CurrentFuelCapacity = i_CurrentFuelCapacity;
        //    m_CheckedList[0] = true;
        //    m_CheckedList[1] = true;
        //}

        //public void CarVehicle(eColor i_Color, eNumberOfDoors i_NumberOfDoors)
        //{
        //    m_Color = i_Color;
        //    m_NumberOfDoors = i_NumberOfDoors;
        //    m_CheckedList[3] = true;
        //    m_CheckedList[4] = true;
        //}

        //public void BikeVehicle(eBikeLicenseType i_LicenseBikeType, int i_EngineBikeCapaicty)
        //{
        //    m_LicenseBikeType = i_LicenseBikeType;
        //    m_EngineBikeCapaicty = i_EngineBikeCapaicty;
        //    m_CheckedList[7] = true;
        //    m_CheckedList[8] = true;
        //}

        //public eColor CarColor
        //{
        //    get { return m_Color; }
        //}

        //public eNumberOfDoors NumberOfDoors
        //{
        //    get { return m_NumberOfDoors; }
        //}

        //public eBikeLicenseType LicenseBikeType
        //{
        //    get { return m_LicenseBikeType; }
        //}

    }
}
