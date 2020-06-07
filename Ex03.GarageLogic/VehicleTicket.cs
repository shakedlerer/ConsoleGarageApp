using System;

namespace Ex03.GarageLogic
{
    public class VehicleTicket
    {
        private readonly Vehicle r_Vehicle;
        private VehiclesEnums.eVehicleStatus m_VehicleStatus;
        private string m_PhoneNumber;
        private string m_OwnerName;

        public VehicleTicket(Vehicle i_Vehicle)
        {
            r_Vehicle = i_Vehicle;
            m_VehicleStatus = VehiclesEnums.eVehicleStatus.InProgress;
        }

        public VehiclesEnums.eVehicleStatus Status
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }

        public Vehicle Vehicle
        {
            get { return r_Vehicle; }
        }

        public string Phone
        {
            get { return m_PhoneNumber; }
            set { m_PhoneNumber = value; }
        }

        public string Owner
        {
            get { return m_OwnerName; }
            set { m_OwnerName = value; }
        }
    }
}