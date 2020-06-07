using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private const string k_NotFuelVehicle = "Error: Vehicle {0} does not have a fuel engine {1}{1}";
        private const string k_NotElectricVehicle = "Error: Vehicle {0} does not have an electric engine {1}{1}";
        private Dictionary<string, VehicleTicket> m_Vehicles;
        private VehicleFactory m_Factory;

        public Garage()
        {
            m_Vehicles = new Dictionary<string, VehicleTicket>();
            m_Factory = new VehicleFactory();
        }

        public bool VehicleExistInGarage(string i_LicenseId)
        {
            return m_Vehicles.ContainsKey(i_LicenseId);
        }

        public void FillFuel(string i_LicenseId, float i_AmountOfFuel, VehiclesEnums.eFuelType i_TypeOfFuel)
        {
            FuelEngine eng = m_Vehicles[i_LicenseId].Vehicle.Engine as FuelEngine;

            if(eng == null)
            {
                throw new ArgumentException(string.Format(k_NotFuelVehicle, i_LicenseId, Environment.NewLine));
            }

            eng.FillFuel(i_AmountOfFuel, i_TypeOfFuel);
        }

        public void FillElectric(string i_LicenseId, int i_AmountOfMinutes)
        {
            float toHour = i_AmountOfMinutes / 60f;
            ElectricEngine eng = m_Vehicles[i_LicenseId].Vehicle.Engine as ElectricEngine;

            if (eng == null)
            {
                throw new ArgumentException(string.Format(k_NotElectricVehicle, i_LicenseId, Environment.NewLine));
            }

            eng.ChargeBattery(toHour);
        }

        public string ShowFullDetailsByLicense(string i_LicenseId)
        {
            return m_Vehicles[i_LicenseId].ToString();
        }

        public void FillTiresToMax(string i_LicenseId)
        {
            m_Vehicles[i_LicenseId].Vehicle.FillTiresToMax();
        }

        public StringBuilder AllLicenseNumbers()
        {
            StringBuilder allLicenseNumbers = new StringBuilder();

            foreach (KeyValuePair<string, VehicleTicket> record in m_Vehicles)
            {
                allLicenseNumbers.Append(record.Key);
                allLicenseNumbers.Append(Environment.NewLine);
            }

            return allLicenseNumbers;
        }

        public StringBuilder AllLicenseNumbersByStatus(VehiclesEnums.eVehicleStatus i_VehicleStatus)
        {
            StringBuilder allLicenseNumbersByStatus = new StringBuilder();

            foreach (KeyValuePair<string, VehicleTicket> record in m_Vehicles)
            {
                if (record.Value.Status == i_VehicleStatus)
                {
                    allLicenseNumbersByStatus.Append(record.Key);
                    allLicenseNumbersByStatus.Append(Environment.NewLine);
                }
            }

            return allLicenseNumbersByStatus;
        }

        public VehicleTicket AddNewVehicle(string i_LicenseNumber, VehiclesEnums.eVehicleType i_VehicleType)
        {
            Vehicle vehicle = m_Factory.CreateNewVehicleOfType(i_VehicleType, i_LicenseNumber);
            VehicleTicket newVehicleTicket = new VehicleTicket(vehicle);
            m_Vehicles.Add(vehicle.GetLicenseNumber(), newVehicleTicket);

            return newVehicleTicket;
        }

        public void SetInProgressStatus(string i_LicenseId)
        {
            UpdateVehicleStatus(i_LicenseId, VehiclesEnums.eVehicleStatus.InProgress);
        }

        public void UpdateVehicleStatus(string i_LicenseId, VehiclesEnums.eVehicleStatus i_NewStatus)
        {
            m_Vehicles[i_LicenseId].Status = i_NewStatus;
        }

        public string GetVehicleDescription(string i_LicenseId)
        {
            VehicleTicket vehiclesTicket = m_Vehicles[i_LicenseId];
            string vehicleDescription = CreateDescriptionOfVehicle(vehiclesTicket.Vehicle);
            string ticketDescription = string.Format(
@"-Vehicle Description-
License Number: {0}
Status In Garage: {1}
Owner Name: {2}
Owner Phone Number: {3}
------------
{4}", 
i_LicenseId, 
vehiclesTicket.Status, 
vehiclesTicket.Owner, 
vehiclesTicket.Phone, 
vehicleDescription);
          
            return ticketDescription;
        }

        private string CreateDescriptionOfVehicle(Vehicle i_Vehicle)
        {
            StringBuilder vehiclesDescription = new StringBuilder();
            PropertyInfo[] vehicleProperties = i_Vehicle.GetType().GetProperties(BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.Public);

            foreach (PropertyInfo property in vehicleProperties)
            {
                if(property.CanRead && property.GetValue(i_Vehicle, null) != null)
                {
                    vehiclesDescription.Append(string.Format("{0}: {1}{2}", property.Name, property.GetValue(i_Vehicle, null), Environment.NewLine));
                }
            }

            return vehiclesDescription.ToString();
        }
    }
}
