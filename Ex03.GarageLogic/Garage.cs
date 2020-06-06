using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, VehicleTicket> m_Vehicles;
        VehicleFactory m_Factory;

        public Garage()
        {
            m_Vehicles = new Dictionary<string, VehicleTicket>();
            m_Factory = new VehicleFactory();

        }
        public bool VehicleExistInGarage(string i_LicenseId)
        {
            return m_Vehicles.ContainsKey(i_LicenseId);
        }

        public void FillFuel(string i_LicenseId, float i_amountOfFuel, VehiclesEnums.eFuelType i_typeOfFuel)
        {
            FuelEngine eng = m_Vehicles[i_LicenseId].Vehicle.Engine as FuelEngine;

            if(eng == null)
            {
                throw new ArgumentException(string.Format("Vehicle {0} does not have Fuel engine", i_LicenseId));
            }

            eng.FillFuel(i_amountOfFuel, i_typeOfFuel);
        }

        public void FillElectric(string i_LicenseId, int i_amountOfMinutes)
        {
            float toHour = (i_amountOfMinutes / 60f);
            ElectricEngine eng = m_Vehicles[i_LicenseId].Vehicle.Engine as ElectricEngine;

            if (eng == null)
            {
                throw new ArgumentException(string.Format("Vehicle {0} does not have Electric engine", i_LicenseId));
            }

            eng.ChargeBattery(toHour);
        }

        public string ShowFullDetailsByLicendeId(string i_LicenseId)
        {
            return m_Vehicles[i_LicenseId].ToString();
        }

        public void FillToMaximum(string i_LicenseId)
        {
            m_Vehicles[i_LicenseId].Vehicle.FillAllTiresToMaximum();
        }

        public void AddNewVehicle(VehicleTicket i_NewVehicleTicket)
        {

            m_Vehicles.Add(i_NewVehicleTicket.Vehicle.GetLicenseNumber(), i_NewVehicleTicket);
        }

        public StringBuilder AllLicenseNumbers()
        {
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, VehicleTicket> record in m_Vehicles)
            {
                sb.Append(record.Key);
                sb.Append(Environment.NewLine);
            }

            return sb;
        }

        public StringBuilder AllLicenseNumbersByStatus(VehiclesEnums.eVehicleStatus i_VehicleStatus)
        {
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, VehicleTicket> record in m_Vehicles)
            {
                if (record.Value.Status == i_VehicleStatus)
                {
                    sb.Append(record.Key);
                    sb.Append(Environment.NewLine);
                }
            }
            return sb;
        }

        public VehicleTicket AddNewVehicle(string i_LicenseNumber, VehiclesEnums.eVehicleType i_VehicleType)
        {
            Vehicle vehicle = m_Factory.CreateNewVehicleOfType(i_VehicleType, i_LicenseNumber);
            VehicleTicket newVehicleTicket = new VehicleTicket(vehicle);
            m_Vehicles.Add(vehicle.GetLicenseNumber(), newVehicleTicket);

            return newVehicleTicket;
        }

        public VehicleTicket AddNewVehicle(Vehicle i_Vehicle)
        {
            VehicleTicket newVehicleTicket = new VehicleTicket(i_Vehicle);
            m_Vehicles.Add(i_Vehicle.GetLicenseNumber(), newVehicleTicket);

            return newVehicleTicket;
        }

        public void setInProgressStatus(string i_LicenseId)
        {
            UpdateVehicleStatus(i_LicenseId, VehiclesEnums.eVehicleStatus.InProgress);
        }

        public void UpdateVehicleStatus(string i_LicenseId, VehiclesEnums.eVehicleStatus i_NewStatus)
        {
            m_Vehicles[i_LicenseId].Status = i_NewStatus;
        }

        public string GetVehicleDescription(string i_LicenseId)
        {
            VehicleTicket ticket = m_Vehicles[i_LicenseId];

            string vehicleDescription = CreateDescriptionOfVehicle(ticket.Vehicle);
            string ticketDescription = string.Format(@"
-Vehicle Description-
License Number: {0}
Status In Garage: {1}
Owner Name: {2}
Owner Phone Number: {3}
------------
{4}", i_LicenseId, ticket.Status, ticket.Owner, ticket.Phone, vehicleDescription);

            return ticketDescription;
        }

        private string CreateDescriptionOfVehicle(Vehicle i_Vehicle)
        {
            StringBuilder description = new StringBuilder(); // BindingFlags.Public |  | BindingFlags.DeclaredOnly
            PropertyInfo[] vehicleProperties = i_Vehicle.GetType().GetProperties(BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.Public);
            //TODO make sure all relevant fields are revealed

            foreach (PropertyInfo property in vehicleProperties)
            {
                if(property.CanRead && property.GetValue(i_Vehicle, null) != null)
                {
                    description.Append(string.Format("{0}: {1}{2}", property.Name, property.GetValue(i_Vehicle, null), Environment.NewLine));
                }
            }
            return description.ToString();
        }
    }

    // TODO Delete comments below:

    //public StringBuilder AllLicenseNumbersByStatus(eVehicleStatus i_VehicleStatus)
    //{
    //    StringBuilder sb = new StringBuilder();

    //    foreach (KeyValuePair<string, VehicleTicket> record in m_Vehicles)
    //    {
    //        if (record.Value.Status == i_VehicleStatus)
    //        {
    //            sb.Append(record.Key);
    //            sb.Append(Environment.NewLine);
    //        }
    //    }

    //    return sb;
    //}

    //public VehicleTicket AddNewVehicle(string i_LicenseNumber, eVehicleType i_VehicleType)
    //{
    //    Vehicle vehicle = m_Factory.CreateNewCarOfType(i_VehicleType, i_LicenseNumber);
    //    VehicleTicket newVehicleTicket = new VehicleTicket(vehicle);
    //    m_Vehicles.Add(vehicle.License, newVehicleTicket);

    //    return newVehicleTicket;
    //}

    //public void setInProgressStatus(string i_LicenseId)
    //{
    //    UpdateVehicleStatus(i_LicenseId, eVehicleStatus.InProgress);
    //}

    //public void UpdateVehicleStatus(string i_LicenseId, eVehicleStatus i_NewStatus)
    //{
    //    m_Vehicles[i_LicenseId].Status = i_NewStatus;
    //}

    //public void UpdateVehicleStatus(string i_LicenseId, string i_NewStatus)
    //{
    //    eVehicleStatus newStatus;
    //    try
    //    {
    //        newStatus = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), i_NewStatus);
    //        m_Vehicles[i_LicenseId].Status = newStatus;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new ArgumentException("Error: Invalid Value was entered.");

    //    }
    //}
}
