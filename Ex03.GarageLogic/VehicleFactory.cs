using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class VehicleFactory
    {
        private const float k_CarMaxElectricEngTime = 2.1f;
        private const float k_BikeMaxElectricEngTime = 1.2f;

        private const int k_CarMaxFuelCapacity = 60;
        private const int k_BikeMaxFuelCapacity = 7;
        private const int k_TruckMaxFuelCapacity = 120;

        private const VehiclesEnums.eFuelType k_CarFuelType = VehiclesEnums.eFuelType.Octan96;
        private const VehiclesEnums.eFuelType k_BikeFuelType = VehiclesEnums.eFuelType.Octan95;
        private const VehiclesEnums.eFuelType k_TruckFuelType = VehiclesEnums.eFuelType.Soler;

        public Vehicle CreateNewVehicleOfType(VehiclesEnums.eVehicleType i_VehicleType, string i_LicenseNumber)
        {
            Vehicle vehicle;
            Engine engine = null;

            switch (i_VehicleType)
            {
                case (VehiclesEnums.eVehicleType.FuelCar):
                    engine = new FuelEngine(k_CarMaxFuelCapacity, k_CarFuelType);
                    vehicle = new Car(i_LicenseNumber, engine);
                    break;
                case (VehiclesEnums.eVehicleType.ElectricCar):
                    engine = new ElectricEngine(k_CarMaxElectricEngTime);
                    vehicle = new Car(i_LicenseNumber, engine);
                    break;
                case (VehiclesEnums.eVehicleType.FuelBike):
                    engine = new FuelEngine(k_BikeMaxFuelCapacity, k_BikeFuelType);
                    vehicle = new Bike(i_LicenseNumber, engine);
                    break;
                case (VehiclesEnums.eVehicleType.ElectricBike):
                    engine = new ElectricEngine(k_BikeMaxElectricEngTime);
                    vehicle = new Bike(i_LicenseNumber, engine);
                    break;
                case (VehiclesEnums.eVehicleType.Truck):
                    engine = new FuelEngine(k_TruckMaxFuelCapacity, k_TruckFuelType);
                    vehicle = new Truck(i_LicenseNumber, engine);
                    break;
                default:
                    throw new ArgumentException(string.Format("Error: Invalid vehicle type {0}", i_VehicleType));
            }
            return vehicle;
        }

        public List<Tire> CreateSetOfTires(float i_MaxPressure, int i_NumOfWheels)
        {
            List<Tire> tires = new List<Tire>(i_NumOfWheels);
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                Tire tire = new Tire(i_MaxPressure);
                tires.Add(tire);
            }

            return tires;
        }
    }
}
