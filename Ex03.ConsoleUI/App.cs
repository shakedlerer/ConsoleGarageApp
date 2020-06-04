using System;
using System.Reflection;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class App
    {
        readonly InputValidator r_Validator;
        readonly UI r_UI;
        readonly Garage r_Garage;

        public App()
        {
            r_Validator = new InputValidator();
            r_UI = new UI();
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
                    r_UI.PrintMenu();
                    menuOption = r_UI.GetOptionInput();
                    PerformSelectedOption(menuOption);
                }
                catch (Exception ex)
                {
                    r_UI.PrintMessage(ex.Message);
                }
            }
        }

        public void PerformSelectedOption(int i_Selection)
        {
            switch (i_Selection)
            {
                case (1):
                    AddNewVehicle();
                    break;
                case (2):
                    ShowVehiclesLicenseNumbers();
                    break;
                case (3):
                    ChangeVehiclesStatus();
                    break;
                case (4):
                    FillTiresToMax();
                    break;
                case (5):
                    FillFuelInVehicle();
                    break;
                case (6):
                    ChargeElectricVehicle();
                    break;
                case (7):
                    ShowVehcilesDetails();
                    break;
                case (8):
                    Environment.Exit(1);
                    break;

                default:
                    string errMsg = string.Format("Error: Invalid option {0} was entered", i_Selection);
                    throw new FormatException(errMsg);
            }
        }

        public void ShowVehiclesLicenseNumbers()
        {
            const int k_AllVehicles = 4;
            string[] statusOptions = {"In Progress", "Fixed", "Paid", "All Vehicles"};

            int option = r_UI.GetNumberFromOptions(statusOptions, Messages.ShowVehiclesLicenseNumbers);

            if (option == k_AllVehicles)
            {
                ShowAllLicenseNumberVehicle();
            }
            else
            {
                ShowLicenseNumberByStatus((eVehicleStatus)option);
            }
        }

        public void ShowAllLicenseNumberVehicle()
        {
            StringBuilder sb = new StringBuilder();

            sb = r_Garage.AllLicenseNumbers();
            r_UI.PrintMessage(sb.ToString());
        }

        public void ShowLicenseNumberByStatus(eVehicleStatus i_Status)
        {
            StringBuilder sb = new StringBuilder();

            sb = r_Garage.AllLicenseNumbersByStatus(i_Status);
            r_UI.PrintMessage(sb.ToString());
        }

        public void ChangeVehiclesStatus()
        {
            string[] statusOptions = { "In Progress", "Fixed", "Paid" };
            string licenseNumber = r_UI.GetLicenseNumber();
            bool vehicleExist = r_Garage.VehicleExistInGarage(licenseNumber);

            if (vehicleExist)
            {
                int option = r_UI.GetNumberFromOptions(statusOptions, "Please choose new status:");

                r_Garage.UpdateVehicleStatus(licenseNumber, (eVehicleStatus)option);
            }
            else
            {
                string errMsg = string.Format("Vehicle {0} doesn't exist in the garage", licenseNumber);
                throw new ArgumentException(errMsg);
            }
        }

        public void FillTiresToMax()
        {
            string licenseNumber = r_UI.GetLicenseNumber();

            bool vehicleExist = r_Garage.VehicleExistInGarage(licenseNumber);

            if (vehicleExist)
            {
                r_Garage.FillToMaximum(licenseNumber);
                r_UI.PrintMessage("Tires filled to max!");
            }
            else
            {
                string errMsg = string.Format("Vehicle {0} is not existing in the garage", licenseNumber);
                throw new ArgumentException(errMsg);
            }
        }





        public void FillFuelInVehicle()
        {
            float amountOfFuel;
            int typeOfFuel;
            string licenseNumber = r_UI.GetLicenseNumber();
            bool vehicleExist = r_Garage.VehicleExistInGarage(licenseNumber);

            if (vehicleExist)
            {
                r_UI.PrintMessage("Please enter desired fuel amount to fill:");
                amountOfFuel = r_UI.GetFloatInput();
                r_UI.PrintMessage(Messages.AskingTypeOfFuel);
                typeOfFuel = r_UI.GetIntInRange(1, 4);
                r_Garage.FillFuel(licenseNumber, amountOfFuel, (eFuelType)typeOfFuel);
            }
            else
            {
                string errMsg = string.Format("Vehicle {0} is not existing in the garage", licenseNumber);
                throw new ArgumentException(errMsg);
            }
        }




        public void ChargeElectricVehicle()
        {
            int amountOfMinutes;
            string licenseNumber = GetLicenseNumber();
            bool vehicleExist = r_Garage.VehicleExistInGarage(licenseNumber);

            if (vehicleExist)
            {
                r_UI.PrintMessage("Please enter charging time, in minutes:");
                amountOfMinutes = r_UI.GetIntNumber();
                r_Garage.FillElectric(licenseNumber, amountOfMinutes);
            }
            else
            {
                string errMsg = string.Format("Vehicle {0} is not existing in the garage", licenseNumber);
                throw new ArgumentException(errMsg);
            }
        }

        public void ShowVehcilesDetails()
        {
            string description;
            string licenseNumber = GetLicenseNumber();
            bool vehicleExist = r_Garage.VehicleExistInGarage(licenseNumber);

            if (vehicleExist)
            {
                description = r_Garage.GetVehicleDescription(licenseNumber);
                r_UI.PrintMessage(description);
            }
            else
            {
                string errMsg = string.Format("Vehicle {0} is not existing in the garage", licenseNumber);
                throw new ArgumentException(errMsg);
            }
        }

        public void AddNewVehicle()
        {
            string licenseNumber = GetLicenseNumber();
            bool vehicleExist = r_Garage.VehicleExistInGarage(licenseNumber);

            if (vehicleExist)
            {
                r_Garage.setInProgressStatus(licenseNumber);
                string errMsg = string.Format("Vehicle {0} is already in the Garage, status updated to InProgress..", licenseNumber);
                r_UI.PrintMessage(errMsg);
            }
            else
            {
                eVehicleType vehicleType = GetVehicleType();
                VehicleTicket vehicleTicket = r_Garage.AddNewVehicle(licenseNumber, vehicleType);
                UpdateVehicleTicket(vehicleTicket);
                string errMsg = string.Format("Vehicle {0} was added successfully!", licenseNumber);
                r_UI.PrintMessage(errMsg);
            }
        }

        public void UpdateVehicleTicket(VehicleTicket i_VehicleTicket)
        {
            i_VehicleTicket.Owner = r_UI.GetOwnerName();
            i_VehicleTicket.Phone = r_UI.GetPhoneNumber();
            updateVehicleProperties(i_VehicleTicket.Vehicle);
        }

        private void updateVehicleProperties(Vehicle i_Vehicle)
        {
            PropertyInfo[] vehicleProperties = i_Vehicle.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.SetProperty);
            //TODO make sure all relevant fields are revealed

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

                catch(ArgumentException ex)
                {
                    r_UI.PrintMessage(ex.Message);
                }
            }
        }

        private void setPropertyOfVehicle(Vehicle i_Vehicle, PropertyInfo i_PropertyToSet)
        {
            Type fieldType = i_PropertyToSet.PropertyType;

            //TODO: move to switchcase
            if (fieldType.IsEnum)
            {
                setEnumProperty(i_PropertyToSet, i_Vehicle);
            }
            else if (fieldType == typeof(Boolean))
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
            string title = string.Format("Select the value for field - {0}:", i_PropertyToSet.Name);

            string[] enumNames = Enum.GetNames(i_PropertyToSet.PropertyType);
            int selectedEnumNumber = r_UI.GetNumberFromOptions(enumNames, title);

            i_PropertyToSet.SetValue(i_Vehicle, Enum.ToObject(fieldType, selectedEnumNumber), null);
        }

        private void setBooleanProperty(PropertyInfo i_PropertyToSet, Vehicle i_Vehicle)
        {
            string title = string.Format("Enter the value for field - {0}(1 - True, 0 - False):", i_PropertyToSet.Name);
            r_UI.PrintMessage(title);
            bool boolValue = r_UI.GetBool();
            i_PropertyToSet.SetValue(i_Vehicle, boolValue, null);
        }

        private void setFloatProperty(PropertyInfo i_PropertyToSet, Vehicle i_Vehicle)
        {
            string title = string.Format("Enter the value for field - {0}:", i_PropertyToSet.Name);
            r_UI.PrintMessage(title);
            float floatValue = r_UI.GetFloatInput();
            i_PropertyToSet.SetValue(i_Vehicle, floatValue, null);
        }

        private void setIntProperty(PropertyInfo i_PropertyToSet, Vehicle i_Vehicle)
        {
            string title = string.Format("Enter the number for field - {0}:", i_PropertyToSet.Name);
            r_UI.PrintMessage(title);
            int intValue = r_UI.GetIntNumber();
            i_PropertyToSet.SetValue(i_Vehicle, intValue, null);
        }

        private void setStringProperty(PropertyInfo i_PropertyToSet, Vehicle i_Vehicle)
        {
            string title = string.Format("Enter the value for field - {0}:", i_PropertyToSet.Name);
            r_UI.PrintMessage(title);
            string strValue = r_UI.GetInput();
            i_PropertyToSet.SetValue(i_Vehicle, strValue, null);
        }

        private void setMemberValue<T>(PropertyInfo i_memberField, GarageLogic.Vehicle i_Vehicle, T i_Value)
        {
            i_memberField.SetValue(i_Vehicle, i_Value, null);
        }

        private void printOptionsForMemberField(PropertyInfo i_memberField)
        {
            Type fieldType = i_memberField.GetType();
            System.Array enumValues = System.Enum.GetValues(fieldType);
            string fieldOutName = string.Format("Enter the value for field - {0}:{1}", i_memberField.Name, Environment.NewLine);
            r_UI.ShowOptionFromArray(fieldOutName, enumValues);


            //typeof(memberField) asd; //.//.DeclaringType type;
            //GarageLogic.eVehicleType vehicleType;
            //try
            //{
            //    vehicleType = GetEnumType<GarageLogic.eVehicleType>(Messages.SelectVehicleType);
            //}
            //catch (Exception ex)
            //{
            //    m_UI.PrintMessage(ex.Message);
            //    return GetVehicleType();
            //}

        }

        private string getName()
        {
            r_UI.PrintMessage(Messages.EnterOwnerName);
            string ownerName = r_UI.GetInput();

            try
            {
                r_Validator.CheckIfStringIsValidOwnerName(ownerName);
            }
            catch (Exception ex)
            {
                r_UI.PrintMessage(string.Format("Error: {0}", ex.Message));

            }

            return ownerName;
        }

        public GarageLogic.eVehicleType GetVehicleType()
        {
            GarageLogic.eVehicleType vehicleType;
            try
            {
                vehicleType = GetEnumType<GarageLogic.eVehicleType>(Messages.SelectVehicleType);
            }
            catch (Exception ex)
            {
                r_UI.PrintMessage(ex.Message);
                return GetVehicleType();
            }

            return vehicleType;
        }

        public T GetEnumTypeFromUser<T>(string i_Message)
        {
            T enumType;
            try
            {
                enumType = GetEnumType<T>(i_Message);
            }
            catch (Exception ex)
            {
                r_UI.PrintMessage(ex.Message);
                return GetEnumTypeFromUser<T>(i_Message);
            }

            return enumType;
        }

        public T GetEnumType<T>(string i_Message)
        {
            string[] enumOptions = GarageLogic.eNumUtils.GetValues<T>();

            string message = string.Format("Enter desired option from {0} to {1}", 1, enumOptions.Length);

            int selectedNumber = r_UI.GetNumberFromOptions(enumOptions, message);
            T selectEnum = (T)Enum.ToObject(typeof(T), selectedNumber);

            return selectEnum;
        }

        public string GetLicenseNumber()
        {
            string license = r_UI.GetLicenseNumber();

            try
            {
                r_Validator.ValidateLicenseNumber(license);
            }
            catch (Exception ex)
            {
                r_UI.PrintMessage(ex.Message);
                return GetLicenseNumber();
            }

            return license;
        }

        public int GetNumber(string i_Message)
        {
            string numberString;
            int number = 0;
            bool stringIsNumber = false;

            while (!stringIsNumber)
            {
                r_UI.PrintMessage(i_Message);
                numberString = r_UI.GetInput();
                stringIsNumber = r_Validator.CheckIfInputIsNumber(numberString, out number);
                if (!stringIsNumber)
                {
                    r_UI.ShowFormatMessages();
                    //format exeption
                }
            }

            return number;
        }
    }
}
