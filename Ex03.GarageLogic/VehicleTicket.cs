using System;
namespace Ex03.GarageLogic
{
    public class VehicleTicket
    {
        private Vehicle m_Vehicle;
        private string m_PhoneNumber;
        private string m_OwnerName;
        private VehiclesEnums.eVehicleStatus m_VehicleStatus;

        public override string ToString()
        {
            return string.Format(@"{0}
Phone Number:{1}
Owner Name:{2}
Vehicle Status:{3}", m_Vehicle.ToString(), m_PhoneNumber, m_OwnerName, m_VehicleStatus);
        }

        public VehicleTicket(Vehicle i_Vehicle)
        {
            m_Vehicle = i_Vehicle;
            m_VehicleStatus = VehiclesEnums.eVehicleStatus.InProgress;
        }

        public VehiclesEnums.eVehicleStatus Status
        {
            set { m_VehicleStatus = value; }
            get { return m_VehicleStatus; }
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }

        public string Phone
        {
            set
            {
                if (value != null && isValidNumber(value))
                {
                    m_PhoneNumber = value;
                }
                // TODO We do a phone number validation in UI's method 'GetPhoneNumber()' - do we need this exception here ?
                else
                {
                    string errorMsg = string.Format("Error: Invalid Phone Number: {0}", value);
                    throw new ArgumentException(errorMsg);
                }
            }
            get { return m_PhoneNumber; }
        }

        public string Owner
        {
            set
            {
                if (value != null && allCharsAreLetters(value))
                {
                    m_OwnerName = value;
                }
                // TODO We do a name validation in UI's method 'GetOwnerName()' - do we need this exception here ?
                else
                {
                    string errorMsg = string.Format("Error: Invalid Name, must be string only..: {0}", value);
                    throw new ArgumentException(errorMsg);
                }
            }
            get { return m_OwnerName; }
        }

        private bool allCharsAreLetters(string I_Str)
        {
            bool isValid = true;
            foreach (char ch in I_Str)
            {
                if (!char.IsLetter(ch))
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        private bool isValidNumber(string i_PhoneNumber)
        {
            int number;
            bool retVal = false;
            if (int.TryParse(i_PhoneNumber, out number))
            {
                retVal = true;
            }

            return retVal;
        }
    }
}