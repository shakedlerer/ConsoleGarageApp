using System;
using System.CodeDom;
using System.Reflection;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class App
    {
        private const string k_VehicleDoesntExist = "Error: Vehicle {0} doesn't exist in the garage {1}{1}";
        private const string k_InvalidMenuOption = "Error: Invalid option {0} was selected. {1}";
        private readonly UI r_Ui;
        private readonly Garage r_Garage;

        public App()
        {
            r_Ui = new UI();
            r_Garage = new GarageLogic.Garage();
        }

        public void Start()
        {
            int menuOption;
            const bool v_Run = true;

            while (v_Run)
            {
                try
                {
                    r_Ui.PrintMenu();
                    menuOption = r_Ui.GetOptionFromMenu();
                    PerformSelectedOption(menuOption);
                }
                catch (Exception ex)
                {
                    r_Ui.PrintMessage(ex.Message);
                }
            }
        }

        public void PerformSelectedOption(int i_Option)
        {
            string errorMsg = string.Format(k_InvalidMenuOption, i_Option, Environment.NewLine);

            switch (i_Option)
            {
                case 1:
                    AddNewVehicle();
                    break;
                case 2:
                    ShowVehiclesLicenseNumbers();
                    break;
                case 3:
                    ChangeVehiclesStatus();
                    break;
                case 4:
                    FillTiresToMax();
                    break;
                case 5:
                    FillFuelInVehicle();
                    break;
                case 6:
                    ChargeElectricVehicle();
                    break;
                case 7:
                    ShowVehicleDetails();
                    break;
                case 8:
                    Environment.Exit(1);
                    break;

                default:
                    throw new FormatException(errorMsg);
            }
        }

        public void ShowVehiclesLicenseNumbers()
        {
            const string k_ChooseVehiclesByStatus = "Please choose which vehicle's license numbers to show (by status or all)";
            const string k_ShowLicenseNumbersList = "The desired vehicle license numbers list is:";
            const int k_NumberOfStatusOptions = 4;
            const int k_AllVehicles = 4;
            const string k_AllVehiclesOption = "All Vehicles";
            string[] statusOptions = Enum.GetNames(typeof(VehiclesEnums.eVehicleStatus));
            int option;

            Array.Resize(ref statusOptions, k_NumberOfStatusOptions);
            statusOptions[k_NumberOfStatusOptions - 1] = k_AllVehiclesOption;
            option = r_Ui.GetNumberFromOptions(statusOptions, k_ChooseVehiclesByStatus);
            r_Ui.PrintMessage(k_ShowLicenseNumbersList);
            if (option == k_AllVehicles)
            {
                ShowAllLicenseNumberVehicle();
            }
            else
            {
                ShowLicenseNumberByStatus((VehiclesEnums.eVehicleStatus)option);
            }
        }

        public void ShowAllLicenseNumberVehicle()
        {
            StringBuilder allLicenseNumbers = r_Garage.AllLicenseNumbers();
            r_Ui.PrintMessage(allLicenseNumbers.ToString() + Environment.NewLine);
        }

        public void ShowLicenseNumberByStatus(VehiclesEnums.eVehicleStatus i_Status)
        {
            StringBuilder licenseNumbersByStatus = r_Garage.AllLicenseNumbersByStatus(i_Status);
            r_Ui.PrintMessage(licenseNumbersByStatus.ToString() + Environment.NewLine);
        }

        public void ChangeVehiclesStatus()
        {
            const string k_ChooseNewStatus = "Please choose new status:";
            const string k_StatusUpdated = "Status updated successfully!";
            int option;
            string[] statusOptions = Enum.GetNames(typeof(VehiclesEnums.eVehicleStatus));
            string licenseNumber = r_Ui.GetLicenseNumber();
            bool vehicleExist = r_Garage.VehicleExistInGarage(licenseNumber);
            string errorMsg = string.Format(k_VehicleDoesntExist, licenseNumber, Environment.NewLine);

            if (vehicleExist)
            {
                option = r_Ui.GetNumberFromOptions(statusOptions, k_ChooseNewStatus);
                r_Garage.UpdateVehicleStatus(licenseNumber, (VehiclesEnums.eVehicleStatus)option);
                r_Ui.PrintMessage(k_StatusUpdated + Environment.NewLine + Environment.NewLine);
            }
            else
            {
                throw new ArgumentException(errorMsg);
            }
        }

        public void FillTiresToMax()
        {
            const string k_TiresFilledToMax = "Tires filled to max!";
            string licenseNumber = r_Ui.GetLicenseNumber();
            bool vehicleExist = r_Garage.VehicleExistInGarage(licenseNumber);
            string errorMsg = string.Format(k_VehicleDoesntExist, licenseNumber, Environment.NewLine);

            if (vehicleExist)
            {
                r_Garage.FillTiresToMax(licenseNumber);
                r_Ui.PrintMessage(k_TiresFilledToMax + Environment.NewLine + Environment.NewLine);
            }
            else
            {
                throw new ArgumentException(errorMsg);
            }
        }

        public void FillFuelInVehicle()
        {
            const string k_EnterFuelAmount = "Please enter the desired fuel amount to fill:";
            const string k_ChooseFuelType = "Please choose fuel type:";
            float amountOfFuel;
            int typeOfFuel;
            string licenseNumber = r_Ui.GetLicenseNumber();
            bool vehicleExist = r_Garage.VehicleExistInGarage(licenseNumber);
            string[] fuelTypes = Enum.GetNames(typeof(VehiclesEnums.eFuelType));
            string errorMsg = string.Format(k_VehicleDoesntExist, licenseNumber, Environment.NewLine);

            if (vehicleExist)
            {
                r_Ui.PrintMessage(k_EnterFuelAmount);
                amountOfFuel = r_Ui.GetFloatInput();
                typeOfFuel = r_Ui.GetNumberFromOptions(fuelTypes, k_ChooseFuelType);
                r_Garage.FillFuel(licenseNumber, amountOfFuel, (VehiclesEnums.eFuelType)typeOfFuel);
            }
            else
            {
                throw new ArgumentException(errorMsg);
            }
        }

        public void ChargeElectricVehicle()
        {
            const string k_EnterChargingTime = "Please enter desired charging time, in minutes:";
            int amountOfMinutes;
            string licenseNumber = r_Ui.GetLicenseNumber();
            bool vehicleExist = r_Garage.VehicleExistInGarage(licenseNumber);
            string errorMsg = string.Format(k_VehicleDoesntExist, licenseNumber, Environment.NewLine);

            if (vehicleExist)
            {
                r_Ui.PrintMessage(k_EnterChargingTime);
                amountOfMinutes = r_Ui.GetIntInput();
                r_Garage.FillElectric(licenseNumber, amountOfMinutes);
            }
            else
            {
                throw new ArgumentException(errorMsg);
            }
        }

        public void ShowVehicleDetails()
        {
            string description;
            string licenseNumber = r_Ui.GetLicenseNumber();
            bool vehicleExist = r_Garage.VehicleExistInGarage(licenseNumber);
            string errorMsg = string.Format(k_VehicleDoesntExist, licenseNumber, Environment.NewLine);

            if (vehicleExist)
            {
                description = r_Garage.GetVehicleDescription(licenseNumber);
                r_Ui.PrintMessage(description + Environment.NewLine);
            }
            else
            {
                throw new ArgumentException(errorMsg);
            }
        }

        public void AddNewVehicle()
        {
            string licenseNumber = r_Ui.GetLicenseNumber();
            bool vehicleExist = r_Garage.VehicleExistInGarage(licenseNumber);
            VehiclesEnums.eVehicleType vehicleType;
            VehicleTicket vehicleTicket;
            string errorMsg = string.Format("Vehicle {0} is already in the Garage, status updated to In Progress.", licenseNumber);
            string successMsg = string.Format("Vehicle {0} was added successfully to the Garage!", licenseNumber);

            if (vehicleExist)
            {
                r_Garage.SetInProgressStatus(licenseNumber);
                r_Ui.PrintMessage(errorMsg + Environment.NewLine + Environment.NewLine);
            }
            else
            {
                vehicleType = GetVehicleType();
                vehicleTicket = r_Garage.AddNewVehicle(licenseNumber, vehicleType);
                UpdateVehicleTicket(vehicleTicket);
                r_Ui.PrintMessage(successMsg + Environment.NewLine + Environment.NewLine);
            }
        }

        public void UpdateVehicleTicket(VehicleTicket i_VehicleTicket)
        {
            i_VehicleTicket.Owner = r_Ui.GetOwnerName();
            i_VehicleTicket.Phone = r_Ui.GetPhoneNumber();
            updateVehicleProperties(i_VehicleTicket.Vehicle);
        }

        private void updateVehicleProperties(Vehicle i_Vehicle)
        {
            PropertyInfo[] vehicleProperties = i_Vehicle.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
    
            foreach (PropertyInfo propertyToUpdate in vehicleProperties)
            {
                if (propertyToUpdate.CanWrite)
                {
                    updatePropertyOfVehicle(i_Vehicle, propertyToUpdate);
                }
            }
        }

        private void updatePropertyOfVehicle(Vehicle i_Vehicle, PropertyInfo i_PropertyToUpdate)
        {
            bool propertyUpdated = false;

            while (!propertyUpdated)
            {
                try
                {
                    setPropertyOfVehicle(i_Vehicle, i_PropertyToUpdate);
                    propertyUpdated = true;
                }
                catch(TargetInvocationException ex)
                {
                    if(ex.InnerException != null)
                    {
                        r_Ui.PrintMessage(ex.InnerException.Message);
                    }
                    else
                    {
                        r_Ui.PrintMessage(ex.Message);
                    }
                }
            }
        }

        private void setPropertyOfVehicle(Vehicle i_Vehicle, PropertyInfo i_PropertyToSet)
        {
            Type fieldType = i_PropertyToSet.PropertyType;
            string selectValueForField = string.Format("Select the value for - {0}:", i_PropertyToSet.Name);
            r_Ui.PrintMessage(selectValueForField);

            if (fieldType.IsEnum)
            {
                setEnumProperty(i_PropertyToSet, i_Vehicle);
            }
            else if (fieldType == typeof(bool))
            {
                setBoolProperty(i_PropertyToSet, i_Vehicle);
            }
            else if (fieldType == typeof(float))
            {
                setFloatProperty(i_PropertyToSet, i_Vehicle);
            }
            else if (fieldType == typeof(int))
            {
                setIntProperty(i_PropertyToSet, i_Vehicle);
            }
            else
            {
                setStringProperty(i_PropertyToSet, i_Vehicle);
            }
        }

        private void setEnumProperty(PropertyInfo i_PropertyToSet, Vehicle i_Vehicle)
        {
            Type fieldType = i_PropertyToSet.PropertyType;
            string[] enumNames = Enum.GetNames(i_PropertyToSet.PropertyType);
            int selectedEnumNumber = r_Ui.GetNumberFromOptions(enumNames, null);

            i_PropertyToSet.SetValue(i_Vehicle, Enum.ToObject(fieldType, selectedEnumNumber), null);
        }

        private void setBoolProperty(PropertyInfo i_PropertyToSet, Vehicle i_Vehicle)
        {
            bool boolValue = r_Ui.GetBoolInput();
            i_PropertyToSet.SetValue(i_Vehicle, boolValue, null);
        }

        private void setFloatProperty(PropertyInfo i_PropertyToSet, Vehicle i_Vehicle)
        {
            float floatValue = r_Ui.GetFloatInput();
            i_PropertyToSet.SetValue(i_Vehicle, floatValue, null);
        }

        private void setIntProperty(PropertyInfo i_PropertyToSet, Vehicle i_Vehicle)
        {
            int intValue = r_Ui.GetIntInput();
            i_PropertyToSet.SetValue(i_Vehicle, intValue, null);
        }

        private void setStringProperty(PropertyInfo i_PropertyToSet, Vehicle i_Vehicle)
        {
            string strValue = r_Ui.GetStringInput();
            i_PropertyToSet.SetValue(i_Vehicle, strValue, null);
        }

        public VehiclesEnums.eVehicleType GetVehicleType()
        {
            string[] vehicleTypes = Enum.GetNames(typeof(VehiclesEnums.eVehicleType));
            const string k_ChooseVehicleType = "Please choose Vehicle type:";
            int typeOfVehicle = r_Ui.GetNumberFromOptions(vehicleTypes, k_ChooseVehicleType);
            return (VehiclesEnums.eVehicleType)typeOfVehicle;
        }
    }
}
