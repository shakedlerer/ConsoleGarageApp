using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class VehicleFactory
    {
        private const int k_CarNumberOfWheels = 4;
        private const int k_BikeNumberOfWheels = 2;
        private const int k_TruckNumberOfWheels = 12;

        private const float k_CarMaxPressure = 31f;
        private const float k_BikeMaxPressure = 33f;
        private const float k_TruckMaxPressure = 26f;

        private const float k_CarMaxElectricEngTime = 1.8f;
        private const float k_BikeMaxElectricEngTime = 1.4f;

        private const int k_CarMaxFuelCapacity = 55;
        private const int k_BikeMaxFuelCapacity = 8;
        private const int k_TruckMaxFuelCapacity = 110;

        private const eFuelType k_CarFuelType = eFuelType.Octan96;
        private const eFuelType k_BikeFuelType = eFuelType.Octan95;
        private const eFuelType k_TruckFuelType = eFuelType.Soler;

        public Vehicle CreateNewCarOfType(eVehicleType i_VehicleType, string i_LicenseNumber)
        {
            Vehicle vehicle;
            Engine engine = null;
            List<Wheel> wheels;
            switch (i_VehicleType)
            {
                case (eVehicleType.FuelCar):
                    wheels = CreateWheels(k_CarMaxPressure, k_CarNumberOfWheels);
                    engine = new FuelEngine(k_CarMaxFuelCapacity, k_CarFuelType);
                    vehicle = new Car(i_LicenseNumber, engine, wheels);
                    break;
                case (eVehicleType.ElectricCar):
                    wheels = CreateWheels(k_CarMaxPressure, k_CarNumberOfWheels);
                    engine = new ElectricEngine(k_CarMaxElectricEngTime);
                    vehicle = new Car(i_LicenseNumber, engine, wheels);
                    break;
                case (eVehicleType.FuelBike):
                    wheels = CreateWheels(k_BikeMaxPressure, k_BikeNumberOfWheels);
                    engine = new FuelEngine(k_BikeMaxFuelCapacity, k_BikeFuelType);
                    vehicle = new Bike(i_LicenseNumber, engine, wheels);

                    break;
                case (eVehicleType.ElectricBike):
                    wheels = CreateWheels(k_BikeMaxPressure, k_BikeNumberOfWheels);
                    engine = new ElectricEngine(k_BikeMaxElectricEngTime);
                    vehicle = new Bike(i_LicenseNumber, engine, wheels);
                    break;
                case (eVehicleType.Truck):
                    wheels = CreateWheels(k_TruckMaxPressure, k_TruckNumberOfWheels);
                    engine = new FuelEngine(k_TruckMaxFuelCapacity, k_TruckFuelType);
                    vehicle = new Truck(i_LicenseNumber, engine, wheels);
                    break;

                default:
                    throw new ArgumentException(string.Format("Error: Invalid vehicle type {0}", i_VehicleType));
            }

            return vehicle;
        }
        public List<Wheel> CreateWheels(float i_MaxPressure, int i_NumOfWheels)
        {
            List<Wheel> wheels = new List<Wheel>(i_NumOfWheels);
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                Wheel wheel = new Wheel(i_MaxPressure);
                wheels.Add(wheel);
            }

            return wheels;
        }
    }
}
