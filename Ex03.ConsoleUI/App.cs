using System;
using System.Reflection;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class App
    {
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
                    menuOption = r_Ui.GetOptionInput();
                    PerformSelectedOption(menuOption);
                }
                catch (Exception ex)
                {
                    r_Ui.PrintMessage(ex.Message);
                }
            }
        }

        public void PerformSelectedOption(int i_Selection)
        {
            switch (i_Selection)
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
                    ShowVehcilesDetails();
                    break;
                case 8:
                    Environment.Exit(1);
                    break;

                default:
                    string errMsg = string.Format("Error: Invalid option {0} was entered {1}", i_Selection, Environment.NewLine);
                    throw new FormatException(errMsg);
            }
        }

        public void ShowVehiclesLicenseNumbers()
        {
            const string k_ShowVehiclesLicenseNumbers = "Please choose which vehicle's license numbers to show (by status or all)";
            const string k_ShowLicenseNumbersList = "The desired vehicle license numbers list is:";
            const int k_AllVehicles = 4;
            const string k_AllVehiclesOption = "All Vehicles";
            string[] statusOptions = Enum.GetNames(typeof(VehiclesEnums.eVehicleStatus));

            Array.Resize(ref statusOptions, k_AllVehicles);
            statusOptions[k_AllVehicles - 1] = k_AllVehiclesOption;
            int option = r_Ui.GetNumberFromOptions(statusOptions, k_ShowVehiclesLicenseNumbers);
            r_Ui.PrintMessage(k_ShowLicenseNumbersList + Environment.NewLine);
            if (option == k_AllVehicles)
            {
                ShowAllLicenseNumberVehicle();
            }
            else
            {
                ShowLicenseNumberByStatus((VehiclesEnums.eVehicleStatus)option);
            }

            r_Ui.PrintMessage(Environment.NewLine + Environment.NewLine);
        }

        public void ShowAllLicenseNumberVehicle()
        {
            StringBuilder sb = new StringBuilder();

            sb = r_Garage.AllLicenseNumbers();
            r_Ui.PrintMessage(sb.ToString());
        }

        public void ShowLicenseNumberByStatus(VehiclesEnums.eVehicleStatus i_Status)
        {
            StringBuilder sb = new StringBuilder();

            sb = r_Garage.AllLicenseNumbersByStatus(i_Status);
            r_Ui.PrintMessage(sb.ToString());
        }

        public void ChangeVehiclesStatus()
        {
            string[] statusOptions = Enum.GetNames(typeof(VehiclesEnums.eVehicleStatus));
            //string[] statusOptions = { "In Progress", "Fixed", "Paid" };
            string licenseNumber = r_Ui.GetLicenseNumber();
            bool vehicleExist = r_Garage.VehicleExistInGarage(licenseNumber);

            if (vehicleExist)
            {
                int option = r_Ui.GetNumberFromOptions(statusOptions, "Please choose new status:");

                r_Garage.UpdateVehicleStatus(licenseNumber, (VehiclesEnums.eVehicleStatus)option);
            }
            else
            {
                string errMsg = string.Format("Error: Vehicle {0} doesn't exist in the garage {1}{1}{1}", licenseNumber, Environment.NewLine);
                throw new ArgumentException(errMsg);
            }
        }

        public void FillTiresToMax()
        {
            string licenseNumber = r_Ui.GetLicenseNumber();

            bool vehicleExist = r_Garage.VehicleExistInGarage(licenseNumber);

            if (vehicleExist)
            {
                r_Garage.FillToMaximum(licenseNumber);
                r_Ui.PrintMessage("Tires filled to max!" + Environment.NewLine + Environment.NewLine + Environment.NewLine);
            }
            else
            {
                string errMsg = string.Format("Error: Vehicle {0} doesn't exist in the garage {1}{1}{1}", licenseNumber, Environment.NewLine);
                throw new ArgumentException(errMsg);
            }
        }

        public void FillFuelInVehicle()
        {
            float amountOfFuel;
            int typeOfFuel;
            string licenseNumber = r_Ui.GetLicenseNumber();
            bool vehicleExist = r_Garage.VehicleExistInGarage(licenseNumber);
            string[] fuelTypes = Enum.GetNames(typeof(VehiclesEnums.eFuelType));

            if (vehicleExist)
            {
                r_Ui.PrintMessage("Please enter the desired fuel amount to fill:" + Environment.NewLine);
                amountOfFuel = r_Ui.GetFloatInput();
                typeOfFuel = r_Ui.GetNumberFromOptions(fuelTypes, "Please choose fuel type:");
                r_Garage.FillFuel(licenseNumber, amountOfFuel, (VehiclesEnums.eFuelType)typeOfFuel);
            }
            else
            {
                string errMsg = string.Format("Error: Vehicle {0} doesn't exist in the garage {1}{1}{1}", licenseNumber, Environment.NewLine);
                throw new ArgumentException(errMsg);
            }
        }

        public void ChargeElectricVehicle()
        {
            int amountOfMinutes;
            string licenseNumber = r_Ui.GetLicenseNumber();
            bool vehicleExist = r_Garage.VehicleExistInGarage(licenseNumber);

            if (vehicleExist)
            {
                r_Ui.PrintMessage("Please enter desired charging time, in minutes:" + Environment.NewLine);
                amountOfMinutes = r_Ui.GetIntInput();
                r_Garage.FillElectric(licenseNumber, amountOfMinutes);
            }
            else
            {
                string errMsg = string.Format("Error: Vehicle {0} doesn't exist in the garage {1}{1}{1}", licenseNumber, Environment.NewLine);
                throw new ArgumentException(errMsg);
            }
        }

        public void ShowVehcilesDetails()
        {
            string description;
            string licenseNumber = r_Ui.GetLicenseNumber();
            bool vehicleExist = r_Garage.VehicleExistInGarage(licenseNumber);
            if (vehicleExist)
            {
                description = r_Garage.GetVehicleDescription(licenseNumber);
                r_Ui.PrintMessage(description + Environment.NewLine + Environment.NewLine);
            }
            else
            {
                string errMsg = string.Format("Error: Vehicle {0} doesn't exist in the garage {1}{1}{1}", licenseNumber, Environment.NewLine);
                throw new ArgumentException(errMsg);
            }
        }

        public void AddNewVehicle()
        {
            string licenseNumber = r_Ui.GetLicenseNumber();
            bool vehicleExist = r_Garage.VehicleExistInGarage(licenseNumber);

            if (vehicleExist)
            {
                r_Garage.SetInProgressStatus(licenseNumber);
                string errMsg = string.Format("Vehicle {0} is already in the Garage, status updated to In Progress.", licenseNumber);
                r_Ui.PrintMessage(errMsg + Environment.NewLine + Environment.NewLine + Environment.NewLine);
            }
            else
            {
                VehiclesEnums.eVehicleType vehicleType = GetVehicleType();
                VehicleTicket vehicleTicket = r_Garage.AddNewVehicle(licenseNumber, vehicleType);
                UpdateVehicleTicket(vehicleTicket);
                string errMsg = string.Format("Vehicle {0} was added successfully to the Garage!", licenseNumber);
                r_Ui.PrintMessage(errMsg + Environment.NewLine + Environment.NewLine + Environment.NewLine);
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

            if (fieldType.IsEnum)
            {
                setEnumProperty(i_PropertyToSet, i_Vehicle);
            }
            else if (fieldType == typeof(bool))
            {
                setBooleanProperty(i_PropertyToSet, i_Vehicle);
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
            string title = string.Format("Select the value for - {0}:", i_PropertyToSet.Name);

            string[] enumNames = Enum.GetNames(i_PropertyToSet.PropertyType);
            int selectedEnumNumber = r_Ui.GetNumberFromOptions(enumNames, title);
            i_PropertyToSet.SetValue(i_Vehicle, Enum.ToObject(fieldType, selectedEnumNumber), null);
        }

        private void setBooleanProperty(PropertyInfo i_PropertyToSet, Vehicle i_Vehicle)
        {
            string title = string.Format("Select the value for - {0}:", i_PropertyToSet.Name);
            r_Ui.PrintMessage(title);
            bool boolValue = r_Ui.GetBoolInput();
            i_PropertyToSet.SetValue(i_Vehicle, boolValue, null);
        }

        private void setFloatProperty(PropertyInfo i_PropertyToSet, Vehicle i_Vehicle)
        {
            string title = string.Format("Select the value for - {0}:", i_PropertyToSet.Name);
            r_Ui.PrintMessage(title + Environment.NewLine);
            float floatValue = r_Ui.GetFloatInput();
            i_PropertyToSet.SetValue(i_Vehicle, floatValue, null);
        }

        private void setIntProperty(PropertyInfo i_PropertyToSet, Vehicle i_Vehicle)
        {
            string title = string.Format("Select the value for - {0}:", i_PropertyToSet.Name);
            r_Ui.PrintMessage(title + Environment.NewLine);
            int intValue = r_Ui.GetIntInput();
            i_PropertyToSet.SetValue(i_Vehicle, intValue, null);
        }

        private void setStringProperty(PropertyInfo i_PropertyToSet, Vehicle i_Vehicle)
        {
            string title = string.Format("Select the value for - {0}:", i_PropertyToSet.Name);
            r_Ui.PrintMessage(title + Environment.NewLine);
            string strValue = r_Ui.GetStringInput();
            i_PropertyToSet.SetValue(i_Vehicle, strValue, null);
        }

        public VehiclesEnums.eVehicleType GetVehicleType()
        {
            string[] vehicleTypes = Enum.GetNames(typeof(VehiclesEnums.eVehicleType));
            int typeOfVehicle = r_Ui.GetNumberFromOptions(vehicleTypes, "Please choose Vehicle type:");
            return (VehiclesEnums.eVehicleType)typeOfVehicle;
        }
    }
}
