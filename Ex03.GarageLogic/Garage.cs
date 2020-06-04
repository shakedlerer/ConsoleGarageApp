using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Record> m_Vehicles;
        VehicleFactory m_Factory;

        public Garage()
        {
            m_Vehicles = new Dictionary<string, Record>();
            m_Factory = new VehicleFactory();

        }
        public bool VehicleExistInGarage(string i_LicenseId)
        {
            return m_Vehicles.ContainsKey(i_LicenseId);
        }

        public void FillFuel(string i_LicenseId, float i_amountOfFuel, eFuelType i_typeOfFuel)
        {
            FuelEngine eng = m_Vehicles[i_LicenseId].Vehicle.Engine as FuelEngine;
            eng.Fill(i_amountOfFuel, i_typeOfFuel);
        }

        public void FillElectric(string i_LicenseId, int i_amountOfMinutes)
        {
            float toHour = (i_amountOfMinutes / 60) + (i_amountOfMinutes % 60);
            ElectricEngine eng = m_Vehicles[i_LicenseId].Vehicle.Engine as ElectricEngine;
            eng.FillEnergy(toHour);
        }

        public string ShowFullDetailsByLicendeId(string i_LicenseId)
        {
            return m_Vehicles[i_LicenseId].ToString();
        }

        public void FillToMaximum(string i_LicenseId)
        {
            m_Vehicles[i_LicenseId].Vehicle.FillAllWhellsToMaximum();
        }

        public void AddNewVehicle(Record i_NewRecord)
        {

            m_Vehicles.Add(i_NewRecord.Vehicle.License, i_NewRecord);
        }

        public StringBuilder AllLicenseNumbers()
        {
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, Record> record in m_Vehicles)
            {
                sb.Append(record.Key);
                sb.Append(Environment.NewLine);
            }

            return sb;
        }

        public StringBuilder AllLicenseNumbersByStatus(eVehicleStatus i_VehicleStatus)
        {
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, Record> record in m_Vehicles)
            {
                if (record.Value.Status == i_VehicleStatus)
                {
                    sb.Append(record.Key);
                    sb.Append(Environment.NewLine);
                }
            }

            return sb;
        }

        public Record AddNewVehicle(string i_LicenseNumber, eVehicleType i_VehicleType)
        {
            Vehicle vehicle = m_Factory.CreateNewCarOfType(i_VehicleType, i_LicenseNumber);
            Record newRecord = new Record(vehicle);
            m_Vehicles.Add(vehicle.License, newRecord);

            return newRecord;
        }

        public Record AddNewVehicle(Vehicle i_Vehicle)
        {
            Record newRecord = new Record(i_Vehicle);
            m_Vehicles.Add(i_Vehicle.License, newRecord);

            return newRecord;
        }

        public void setInProgressStatus(string i_LicenseId)
        {
            UpdateVehicleStatus(i_LicenseId, eVehicleStatus.InProgress);
        }

        public void UpdateVehicleStatus(string i_LicenseId, eVehicleStatus i_NewStatus)
        {
            m_Vehicles[i_LicenseId].Status = i_NewStatus;
        }

        public void UpdateVehicleStatus(string i_LicenseId, string i_NewStatus)
        {
            eVehicleStatus newStatus;
            try
            {
                newStatus = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), i_NewStatus);
                m_Vehicles[i_LicenseId].Status = newStatus;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error: Invalid Value was entered.");

            }
        }
    }
}
