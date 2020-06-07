namespace Ex03.GarageLogic
{
    public class VehiclesEnums
    {
        public enum eBikeLicenseType
        {
            A = 1,
            A1,
            AA,
            B
        }

        public enum eColor
        {
            Red = 1,
            White,
            Black,
            Silver
        }

        public enum eFuelType
        {
            Octan95 = 1,
            Octan96,
            Octan98,
            Soler
        }

        public enum eNumberOfDoors
        {
            Two = 1,
            Three,
            Four,
            Five
        }

        public enum eVehicleStatus
        {
            InProgress = 1,
            Fixed,
            Paid
        }

        public enum eVehicleType
        {
            FuelBike = 1,
            ElectricBike,
            FuelCar,
            ElectricCar,
            Truck
        }
    }
}
