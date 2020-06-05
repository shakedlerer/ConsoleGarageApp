using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class VehicleFactory
    {
        private const int k_CarNumberOfWheels = 4;
        private const int k_BikeNumberOfWheels = 2;
        private const int k_TruckNumberOfWheels = 16;

        private const float k_CarMaxPressure = 32f;
        private const float k_BikeMaxPressure = 30f;
        private const float k_TruckMaxPressure = 28f;

        private const float k_CarMaxElectricEngTime = 2.1f;
        private const float k_BikeMaxElectricEngTime = 1.2f;

        private const int k_CarMaxFuelCapacity = 60;
        private const int k_BikeMaxFuelCapacity = 7;
        private const int k_TruckMaxFuelCapacity = 120;

        //private const eFuelType k_CarFuelType = eFuelType.Octan96;
        //private const eFuelType k_BikeFuelType = eFuelType.Octan95;
        //private const eFuelType k_TruckFuelType = eFuelType.Soler;
        private const VehiclesEnums.eFuelType k_CarFuelType = VehiclesEnums.eFuelType.Octan96;
        private const VehiclesEnums.eFuelType k_BikeFuelType = VehiclesEnums.eFuelType.Octan95;
        private const VehiclesEnums.eFuelType k_TruckFuelType = VehiclesEnums.eFuelType.Soler;

        //public Vehicle CreateNewCarOfType(eVehicleType i_VehicleType, string i_LicenseNumber)
        //{
        //    Vehicle vehicle;
        //    Engine engine = null;
        //    List<Tire> wheels;
        //    switch (i_VehicleType)
        //    {
        //        case (eVehicleType.FuelCar):
        //            wheels = CreateWheels(k_CarMaxPressure, k_CarNumberOfWheels);
        //            engine = new FuelEngine(k_CarMaxFuelCapacity, k_CarFuelType);
        //            vehicle = new Car(i_LicenseNumber, engine, wheels);
        //            break;
        //        case (eVehicleType.ElectricCar):
        //            wheels = CreateWheels(k_CarMaxPressure, k_CarNumberOfWheels);
        //            engine = new ElectricEngine(k_CarMaxElectricEngTime);
        //            vehicle = new Car(i_LicenseNumber, engine, wheels);
        //            break;
        //        case (eVehicleType.FuelBike):
        //            wheels = CreateWheels(k_BikeMaxPressure, k_BikeNumberOfWheels);
        //            engine = new FuelEngine(k_BikeMaxFuelCapacity, k_BikeFuelType);
        //            vehicle = new Bike(i_LicenseNumber, engine, wheels);
        //            break;
        //        case (eVehicleType.ElectricBike):
        //            wheels = CreateWheels(k_BikeMaxPressure, k_BikeNumberOfWheels);
        //            engine = new ElectricEngine(k_BikeMaxElectricEngTime);
        //            vehicle = new Bike(i_LicenseNumber, engine, wheels);
        //            break;
        //        case (eVehicleType.Truck):
        //            wheels = CreateWheels(k_TruckMaxPressure, k_TruckNumberOfWheels);
        //            engine = new FuelEngine(k_TruckMaxFuelCapacity, k_TruckFuelType);
        //            vehicle = new Truck(i_LicenseNumber, engine, wheels);
        //            break;

        //        default:
        //            throw new ArgumentException(string.Format("Error: Invalid vehicle type {0}", i_VehicleType));
        //    }

        //    return vehicle;
        //}

        public Vehicle CreateNewVehicleOfType(VehiclesEnums.eVehicleType i_VehicleType, string i_LicenseNumber)
        {
            Vehicle vehicle;
            Engine engine = null;
            //List<Tire> wheels;

            switch (i_VehicleType)
            {
                case (VehiclesEnums.eVehicleType.FuelCar):
                    //wheels = CreateWheels(k_CarMaxPressure, k_CarNumberOfWheels);
                    engine = new FuelEngine(k_CarMaxFuelCapacity, k_CarFuelType);
                    //vehicle = new Car(i_LicenseNumber, engine, wheels);
                    vehicle = new Car(i_LicenseNumber, engine);
                    break;
                case (VehiclesEnums.eVehicleType.ElectricCar):
                    //wheels = CreateWheels(k_CarMaxPressure, k_CarNumberOfWheels);
                    engine = new ElectricEngine(k_CarMaxElectricEngTime);
                    //vehicle = new Car(i_LicenseNumber, engine, wheels);
                    vehicle = new Car(i_LicenseNumber, engine);
                    break;
                case (VehiclesEnums.eVehicleType.FuelBike):
                    //wheels = CreateWheels(k_BikeMaxPressure, k_BikeNumberOfWheels);
                    engine = new FuelEngine(k_BikeMaxFuelCapacity, k_BikeFuelType);
                    //vehicle = new Bike(i_LicenseNumber, engine, wheels);
                    vehicle = new Bike(i_LicenseNumber, engine);
                    break;
                case (VehiclesEnums.eVehicleType.ElectricBike):
                    //wheels = CreateWheels(k_BikeMaxPressure, k_BikeNumberOfWheels);
                    engine = new ElectricEngine(k_BikeMaxElectricEngTime);
                    //vehicle = new Bike(i_LicenseNumber, engine, wheels);
                    vehicle = new Bike(i_LicenseNumber, engine);
                    break;
                case (VehiclesEnums.eVehicleType.Truck):
                    //wheels = CreateWheels(k_TruckMaxPressure, k_TruckNumberOfWheels);
                    engine = new FuelEngine(k_TruckMaxFuelCapacity, k_TruckFuelType);
                    //vehicle = new Truck(i_LicenseNumber, engine, wheels);
                    vehicle = new Truck(i_LicenseNumber, engine);
                    break;
                default:
                    throw new ArgumentException(string.Format("Error: Invalid vehicle type {0}", i_VehicleType));
            }
            return vehicle;
        }


        public List<Tire> CreateWheels(float i_MaxPressure, int i_NumOfWheels)
        {
            List<Tire> wheels = new List<Tire>(i_NumOfWheels);
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                Tire tire = new Tire(i_MaxPressure);
                wheels.Add(tire);
            }

            return wheels;
        }
    }
}
