using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{

    // AVITAL
    public class IOhandler
    {
        readonly InputValidator r_Validator;
        UI m_UI;
        GarageLogic.Garage m_Garage;

        public IOhandler()
        {
            r_Validator = new InputValidator();
            m_UI = new UI();
            m_Garage = new GarageLogic.Garage();
        }

        public void RunTheSystem()
        {
            int optionMenu;
            bool isQuit = false;

            while (!isQuit)
            {
                try
                {
                    m_UI.PrintMenu();
                    optionMenu = m_UI.GetOptionInput();
                    RunSelectedOption(optionMenu);
                }
                catch (Exception ex)
                {

                    m_UI.PrintMessage(ex.Message);
                }

            }
        }

        public void RunSelectedOption(int i_Selection)
        {
            switch (i_Selection)
            {
                case (1):
                    AddNewVehicle();
                    break;
                case (2):
                    ShowLicenseNumberVehicle();
                    break;
                case (3):
                    ChangeStatusOfVehicle();
                    break;
                case (4):
                    FillWheelsToMaximum();
                    break;
                case (5):
                    FillFuelVehicle();
                    break;
                case (6):
                    FillElectricVehicle();
                    break;
                case (7):
                    ShowFullDetailsOfVehcile();
                    break;
                case (8):
                    Environment.Exit(1);
                    break;

                default:
                    string errMsg = string.Format("Error: Invalid option was entered: {0}", i_Selection);
                    throw new FormatException(errMsg);
            }
        }

        public void ShowLicenseNumberVehicle()
        {
            m_UI.PrintMessage(Messages.AskingAllOrByStatus);
            int statusNumber;
            string statusNumberString = m_UI.GetInput();

            if (!r_Validator.CheckIfInputIsNumber(statusNumberString, out statusNumber))
            {
                throw new FormatException(Messages.FormatMessages);
            }
            else
            {
                if (!r_Validator.CheckIfNumberInRangeOfNewStatus(ref statusNumber))
                {
                    ShowAllLicenseNumberVehicle();
                }
                else
                {
                    ShowLicenseNumberByStatus((eVehicleStatus)statusNumber);
                }
            }
        }

        public void ShowAllLicenseNumberVehicle()
        {
            StringBuilder sb = new StringBuilder();

            sb = m_Garage.AllLicenseNumbers();
            m_UI.PrintMessage(sb.ToString());
        }

        public void ShowLicenseNumberByStatus(eVehicleStatus i_Status)
        {
            StringBuilder sb = new StringBuilder();

            sb = m_Garage.AllLicenseNumbersByStatus(i_Status);
            m_UI.PrintMessage(sb.ToString());
        }

        public void ChangeStatusOfVehicle()
        {
            string licenseNumber = GetLicenseNumber();
            string statusNumberString = m_UI.AskingNewStatusOfVehicle();

            m_Garage.UpdateVehicleStatus(licenseNumber, statusNumberString);
        }

        public void FillWheelsToMaximum()
        {
            string licenseNumber = GetLicenseNumber();
            bool vehicleExist = m_Garage.VehicleExistInGarage(licenseNumber);

            if (vehicleExist)
            {
                m_Garage.FillToMaximum(licenseNumber);
            }
            else
            {
                string errMsg = string.Format("Vehicle {0} is not existing in the garage", licenseNumber);
                throw new ArgumentException(errMsg);
            }
        }

        public void FillFuelVehicle()
        {
            float amountOfFuel;
            int typeOfFuel;
            string licenseNumber = GetLicenseNumber();
            bool vehicleExist = m_Garage.VehicleExistInGarage(licenseNumber);

            if (vehicleExist)
            {
                amountOfFuel = m_UI.GetFloatInput();
                m_UI.PrintMessage(Messages.AskingTypeOfFuel);
                typeOfFuel = m_UI.GetIntInRange(1, 4);
                m_Garage.FillFuel(licenseNumber, amountOfFuel, (eFuelType)typeOfFuel);
            }
            else
            {
                string errMsg = string.Format("Vehicle {0} is not existing in the garage", licenseNumber);
                throw new ArgumentException(errMsg);
            }
        }

        public void FillElectricVehicle()
        {
            int amountOfMinutes;
            string licenseNumber = GetLicenseNumber();
            bool vehicleExist = m_Garage.VehicleExistInGarage(licenseNumber);

            if (vehicleExist)
            {
                amountOfMinutes = m_UI.GetIntNumber();
                m_Garage.FillElectric(licenseNumber, amountOfMinutes);
            }
            else
            {
                string errMsg = string.Format("Vehicle {0} is not existing in the garage", licenseNumber);
                throw new ArgumentException(errMsg);
            }
        }

        public void ShowFullDetailsOfVehcile()
        {
            string licenseNumber = GetLicenseNumber();
            bool vehicleExist = m_Garage.VehicleExistInGarage(licenseNumber);

            if (vehicleExist)
            {
                m_UI.PrintMessage(m_Garage.ShowFullDetailsByLicendeId(licenseNumber));
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
            bool vehicleExist = m_Garage.VehicleExistInGarage(licenseNumber);

            if (vehicleExist)
            {
                m_Garage.setInProgressStatus(licenseNumber);
                string errMsg = string.Format("Vehicle {0} is already in the Garage, status updated to InProgress..", licenseNumber);
                throw new ArgumentException(errMsg);
            }
            else
            {
                GarageLogic.eVehicleType vehicleType = GetVehicleType();
                GarageLogic.Record record = m_Garage.AddNewVehicle(licenseNumber, vehicleType);
                UpdateRecordWithRelevantInformation(record);
            }

        }

        public void UpdateRecordWithRelevantInformation(GarageLogic.Record record)
        {

            string ownerName = getName();
            string phoneNumber = getPhoneNumber();
            record.Owner = ownerName;
            record.Phone = phoneNumber;

            updateVehicleWithAnyExtraFields(record.Vehicle);
        }

        private void updateVehicleWithAnyExtraFields(GarageLogic.Vehicle i_Vehicle)
        {
            //FieldInfo[] vehicleMembers = i_Vehicle.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            //foreach (FieldInfo memberField in vehicleMembers)
            //{
            //    setValueOfMemberField(memberField, i_Vehicle);
            //    printOptionsForMemberField(memberField);
            //}

            PropertyInfo[] props = (i_Vehicle).GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);//BindingFlags.Public | BindingFlags.DeclaredOnly);
            foreach (PropertyInfo memberField in props)
            {
                if (!memberField.CanWrite)
                {
                    continue;
                }
                bool v_InvalidInputType = true;
                while (v_InvalidInputType)
                {
                    //printOptionsForMemberField(memberField);
                    try
                    {
                        //string fieldOutName = string.Format("Enter the value for field - {0}:{1}", memberField.Name, Environment.NewLine);
                        //Type type = memberField.GetType();
                        //var x = GetEnumTypeFromUser<memberField.DeclaringType>(fieldOutName);
                        //vehicleType = GetEnumType<GarageLogic.eVehicleType>(Messages.SelectVehicleType);
                        setValueOfMemberField(memberField, i_Vehicle);
                        v_InvalidInputType = false;
                    }
                    catch (Exception ex)
                    {
                        m_UI.PrintMessage(ex.Message);
                    }
                }



            }
        }



        private void setValueOfMemberField(PropertyInfo i_memberField, GarageLogic.Vehicle i_Vehicle)
        {

            string nameOfMemberField = i_memberField.Name;
            Type fieldType = i_memberField.PropertyType;
            //Type type = i_memberField.DeclaringType.FullName;
            string fieldOutName = string.Format("Enter the value for field - {0}:{1}", nameOfMemberField, Environment.NewLine);
            if (fieldType.IsEnum)
            {
                System.Array enumValues = System.Enum.GetValues(fieldType);

                m_UI.ShowOptionFromArray(fieldOutName, enumValues);

                int intValue = m_UI.GetIntNumber();
                PropertyInfo propertyInfo = i_Vehicle.GetType().GetProperty(i_memberField.Name);
                //propertyInfo.SetValue(i_Vehicle, Convert.ChangeType(intValue, fieldType), null);
                propertyInfo.SetValue(i_Vehicle, Enum.ToObject(fieldType, intValue), null);
            }
            else if (fieldType == typeof(Boolean))
            {
                fieldOutName = string.Concat(fieldOutName, string.Format("(1 - True, 0 - False){0}", Environment.NewLine));
                m_UI.PrintMessage(fieldOutName);
                bool boolValue = m_UI.GetBool();
                setMemberValue<bool>(i_memberField, i_Vehicle, boolValue);
            }
            else if (fieldType == typeof(float))
            {
                m_UI.PrintMessage(fieldOutName);
                float floatValue = m_UI.GetFloatInput();
                setMemberValue<float>(i_memberField, i_Vehicle, floatValue);
            }
            else if (fieldType == typeof(int))
            {
                m_UI.PrintMessage(fieldOutName);
                int intValue = m_UI.GetIntNumber();
                setMemberValue<int>(i_memberField, i_Vehicle, intValue);
            }
            else
            {
                m_UI.PrintMessage(fieldOutName);
                string value = m_UI.GetInput();
                setMemberValue<string>(i_memberField, i_Vehicle, value);
            }


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
            m_UI.ShowOptionFromArray(fieldOutName, enumValues);


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
            m_UI.PrintMessage(Messages.EnterOwnerName);
            string ownerName = m_UI.GetInput();

            try
            {
                r_Validator.CheckIfStringIsValidOwnerName(ownerName);
            }
            catch (Exception ex)
            {
                m_UI.PrintMessage(string.Format("Error: {0}", ex.Message));

            }

            return ownerName;
        }

        private string getPhoneNumber()
        {
            m_UI.PrintMessage(Messages.EnterPhoneNumber);
            string phoneNumber = m_UI.GetInput();

            try
            {
                r_Validator.CheckIfStringIsValidPhoneNumber(phoneNumber);
            }
            catch (Exception ex)
            {
                m_UI.PrintMessage(ex.Message);
            }

            return phoneNumber;
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
                m_UI.PrintMessage(ex.Message);
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
                m_UI.PrintMessage(ex.Message);
                return GetEnumTypeFromUser<T>(i_Message);
            }

            return enumType;
        }

        public T GetEnumType<T>(string i_Message)
        {
            string[] enumOptions = GarageLogic.eNumUtils.GetValues<T>();

            string message = string.Format("Enter desired option from {0} to {1}", 1, enumOptions.Length);

            int selectedNumber = m_UI.GetNumberFromOptions(enumOptions, message);
            T selectEnum = (T)Enum.ToObject(typeof(T), selectedNumber);

            return selectEnum;
        }

        public string GetLicenseNumber()
        {
            string license = m_UI.GetLicenseNumber();

            try
            {
                r_Validator.ValidateLicenseNumber(license);
            }
            catch (Exception ex)
            {
                m_UI.PrintMessage(ex.Message);
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
                m_UI.PrintMessage(i_Message);
                numberString = m_UI.GetInput();
                stringIsNumber = r_Validator.CheckIfInputIsNumber(numberString, out number);
                if (!stringIsNumber)
                {
                    m_UI.ShowFormatMessages();
                    //format exeption
                }
            }

            return number;
        }
    }
}
