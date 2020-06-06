using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class UI
    {
        // SHAKED - try to put the unique msg inside their methods

        //private const string k_AskingOptionOfMenu = "Please choose one of the option below";

        private readonly string k_GarageMenu = string.Format(
@" --------------------------------------------------
|              Welcome to our Garage:              |
 --------------------------------------------------
1. Add New Car
2. See all license Number Vehicle in garage
3. Change status of car
4. Fill air pressure in wheels of vehicle to Maximum
5. Fill fuel vehicle
6. Fill electric vehicle
7. Show all details of vehicle
8. Exit");

        // Get input from user

        public string GetStringInput()
        {
            Console.WriteLine("><><><");
            string userInput = Console.ReadLine();
            Console.WriteLine("{0}", Environment.NewLine);
            return userInput;
        }

        public int GetNumberFromOptions(string[] i_Options, string i_Title)
        {
            int selectedNumber;
            //PrintMessage(i_Title);
            // SHAKED try to solve
            PrintMessage(i_Title);
            ShowStringOptions(i_Options);
            selectedNumber = GetNumberInRange(1, i_Options.Length);
            return selectedNumber;
        }

        public string GetLicenseNumber()
        {
            const string k_InvalidPhoneNumberError = "Invalid Phone Number entered, please try again";
            const string k_AskingLicenseNumber = "Please Enter your License Number";
            int number;
            bool validLicenseNumber = false;

            PrintMessage(k_AskingLicenseNumber + Environment.NewLine);
            string licenseNumber = GetStringInput();

            while (!validLicenseNumber)
            {
                validLicenseNumber = int.TryParse(licenseNumber, out number);

                if (!validLicenseNumber)
                {
                    PrintMessage(k_InvalidPhoneNumberError + Environment.NewLine);
                    licenseNumber = GetStringInput();
                }
            }

            return licenseNumber;
        }

        public string GetPhoneNumber()
        {
            const string k_EnterPhoneNumber = "Enter Phone Number:";
            const string k_InvalidPhoneNumberError = "Invalid Phone Number entered, please try again";
            int number;
            bool validPhoneNumber = false;
            PrintMessage(k_EnterPhoneNumber + Environment.NewLine);
            string phoneNumber = GetStringInput();
            
            while (!validPhoneNumber)
            {
                validPhoneNumber = int.TryParse(phoneNumber, out number);

                if (!validPhoneNumber)
                {
                    PrintMessage(k_InvalidPhoneNumberError + Environment.NewLine);
                    phoneNumber = GetStringInput();
                }
            }
            return phoneNumber;
        }

        public string GetOwnerName()
        {
            const string k_EnterOwnerName = "Enter Owner Name:";
            const string k_InvalidNameError = "Invalid Owner Name entered. please try again";
            string ownerName = " ";
            bool invalidOwnerName = false;

            PrintMessage(k_EnterOwnerName + Environment.NewLine);

            while (!invalidOwnerName)
            {
                invalidOwnerName = true;
                ownerName = GetStringInput();

                foreach (char ch in ownerName)
                {
                    if(!char.IsLetter(ch))
                    {
                        invalidOwnerName = false;
                        PrintMessage(k_InvalidNameError + Environment.NewLine);
                        break;
                    }
                }
            }
            return ownerName;
        }

        public int GetOptionInput()
        {
            const string k_InvalidOptionSelected = "Invalid Option entered, please try again:";
            string inputStr = GetStringInput();
            int inputNum;
            bool isNumber = int.TryParse(inputStr, out inputNum);

            if (!isNumber)
            {
                PrintMessage(k_InvalidOptionSelected + Environment.NewLine);
                return GetOptionInput();
            }
            else
            {
                return inputNum;
            }
        }

        public int GetNumberInRange(int i_Min, int i_Max)
        {
            const string k_InvalidOptionSelected = "Invalid Option entered, please try again:";
            int selectedNumber = GetIntInput();
            bool inputIOnRange = selectedNumber >= i_Min && selectedNumber <= i_Max;

            while (!inputIOnRange)
            {
                PrintMessage(k_InvalidOptionSelected + Environment.NewLine);
                selectedNumber = GetIntInput();
                inputIOnRange = selectedNumber >= i_Min && selectedNumber <= i_Max;
            }

            return selectedNumber;
        }

        public bool GetBoolInput()
        {
            //string inputStr;
            //bool inputBool = true;
            //bool isBoolean = false;
            string[] options = {"True", "False" };
            int selectedNumber = GetNumberFromOptions(options, " ");

            return selectedNumber == 1;

            //while (!isBoolean)
            //{
            //    try
            //    {
            //        inputStr = GetStringInput();
            //        inputBool = bool.Parse(inputStr);
            //        isBoolean = true;
            //    }
            //    catch (FormatException ex)
            //    {
            //        PrintMessage("Invalid Boolean Value, please try again...");
            //    }
            //}

            //return inputBool;
            
            //int boolNumber = GetIntInput();
            //bool retVal = false;
            //if (boolNumber == 0)
            //{
            //    retVal = false;
            //}
            //else if (boolNumber == 1)
            //{
            //    retVal = true;
            //}
            //else
            //{
            //    return GetBool();
            //}

            //return retVal;
        }

        public int GetIntInput()
        {
            const string k_InputIsNotANumberError = "Input is not a Number, please try again..";
            string inputStr;
            int inputNumber = 0;
            bool isNumber = false;

            while(!isNumber)
            {
                try
                {
                    inputStr = GetStringInput();
                    inputNumber = int.Parse(inputStr);
                    isNumber = true;
                }
                catch (FormatException ex)
                {
                    PrintMessage(k_InputIsNotANumberError + Environment.NewLine);
                }
            }

            return inputNumber;
        }

        public float GetFloatInput()
        {
            const string k_InvalidNumberEntered = "Invalid Option selected, please try again";
            string inputStr;
            float inputFloat = 0;
            bool isFloat = false;

            while (!isFloat)
            {
                try
                {
                    inputStr = GetStringInput();
                    inputFloat = int.Parse(inputStr);
                    isFloat = true;
                }
                catch (FormatException ex)
                {
                    PrintMessage(k_InvalidNumberEntered);
                }
            }

            return inputFloat;

            //string inputStr = GetStringInput();
            //float inputNum;
            //bool isNumber = float.TryParse(inputStr, out inputNum);
            //if (!isNumber)
            //{
            //    PrintMessage(Messages.InvalidNumberEntered);
            //    return GetFloatInput();
            //}
            //else
            //{
            //    return inputNum;
            //}

        }
        // Print output to user

        public void PrintMenu()
        {
            Console.WriteLine(k_GarageMenu);
        }

        public void PrintMessage(string i_MessageToPrint)
        {
            Console.Write(i_MessageToPrint);
        }

        public void ShowStringOptions(string[] i_Options)
        {
            for (int i = 0; i < i_Options.Length; i++)
            {
                string option = string.Format("{2}{0} - {1}", i + 1, i_Options[i], Environment.NewLine);
                PrintMessage(option);
            }
            PrintMessage(Environment.NewLine);
        }

        public void ShowOptionFromArray(string i_Message, System.Array i_Options)
        {
            PrintMessage(i_Message);
            for (int i = 0; i < i_Options.Length; i++)
            {
                string option = string.Format("{0} - {1}{2}", (int)i_Options.GetValue(i), i_Options.GetValue(i), Environment.NewLine);
                PrintMessage(option);
            }
        }


        // TODO GRAY METHODS, CHECK IF SOMEONE USES THEM AT ALL --> IF NOT (AND IF THEY ARE REALLY NOT NEEDED), WE CAN DELETE THEM

        public void ShowOptions<T>(string i_Message, string[] i_Options)
        {
            PrintMessage(i_Message);
            for (int i = 0; i < i_Options.Length; i++)
            {
                string option = string.Format("{0} - {1}{2}", i + 1, i_Options[i], Environment.NewLine);
                PrintMessage(option);
            }
        }

        private readonly string r_AskingTypeOfFuel = string.Format(
@"Please Choose the Type of fuel.
1 - Octan95
2 - Octan96
3 - Octan98
4 - Soler");
        public string AskingTypeOfFuel()
        {
            PrintMessage(r_AskingTypeOfFuel + Environment.NewLine);

            return GetStringInput();
        }

        public string AskingAmountOfFuel()
        {
            const string k_AskingAmountOfFuel = "Please enter the Amount Of Fuel you want to fill";

            PrintMessage(k_AskingAmountOfFuel + Environment.NewLine);

            return GetStringInput();
        }

        public string AskingAmountOfMinutes()
        {
            const string k_AskingAmountOfMinutes = "PLease enter the Amount Of Minutes you want to load";

            PrintMessage(k_AskingAmountOfMinutes + Environment.NewLine);

            return GetStringInput();
        }

        public void CarAlreadyInGarage()
        {
            const string k_CarAlreadyInGarage = "Your car is Already in the garage";

            PrintMessage(k_CarAlreadyInGarage + Environment.NewLine);
        }

        public string GetNewStatusOfVehicle()
        {
            const string k_GetNewStatusOfVehicle = "Please enter the New Status you want for your vehicle";

            PrintMessage(k_GetNewStatusOfVehicle + Environment.NewLine);

            return GetStringInput();
        }

        public void WrongNumberOfTypeOfFuel()
        {
            const string k_WrongNumberOfTypeOfFuel = "Please enter Number in range of 1-4";

            PrintMessage(k_WrongNumberOfTypeOfFuel + Environment.NewLine);
        }

        public void WrongNumberOfOptionOfStatus()
        {
            const string k_WrongNumberOfOptionOfStatus = "Please enter Number in Range of 1-3";

            PrintMessage(k_WrongNumberOfOptionOfStatus + Environment.NewLine);
        }

        public void ShowFormatMessages()
        {
            const string k_FormatMessages = "You Entered not in context details, please enter again";

            PrintMessage(k_FormatMessages + Environment.NewLine);
        }

        public void ShowWrongFuel()
        {
            const string k_WrongFuel = "The Fuel you entered is not sutibale to your vehicle,therefore we didnt fill your engine";

            PrintMessage(k_WrongFuel + Environment.NewLine);
        }

        public void ShowTooMuchFuel()
        {
            const string k_TooMuchFuel = "You entered Too Much fuel, therefore we didnt fill your engine";

            PrintMessage(k_TooMuchFuel + Environment.NewLine);
        }

        public void ShowTooMuchMinutes()
        {
            const string k_TooMuchMinutes = "You entered Too Much Minutes, therefore we didnt fill your engine";

            PrintMessage(k_TooMuchMinutes + Environment.NewLine);
        }
    }
}