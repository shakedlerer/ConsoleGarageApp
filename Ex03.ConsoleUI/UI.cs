using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class UI
    {
        private const string k_EnterOwnerName = "Enter Owner Name:";
        private const string k_EnterPhoneNumber = "Enter Phone Number:";
        private const string k_InvalidNameError = "Error: invalid Owner Name. please try again";
        private const string k_InvalidPhoneNumberError = "Invalid phone number entered, please try again";
        private const string k_InputIsNotANumberError = "Input is not a number, please try again..";
        private const string k_AskingLicenseNumber = "Please Enter your License Number";
        //private const string k_AskingOptionOfMenu = "Please choose one of the option below";
        private const string k_AskingAmountOfFuel = "Please enter the amount of fuel you want to fill";
        private const string k_AskingAmountOfMinutes = "PLease enter the amount of minutes you want to load";
        private const string k_CarAlreadyInGarage = "Your car is Already in the garage";
        private const string k_GetNewStatusOfVehicle = "Please enter the new status you want for your vehicle";
        private const string k_WrongNumberOfTypeOfFuel = "Please enter Number in range of 1-4";
        private const string k_WrongNumberOfOptionOfStatus = "Please enter Number in Range of 1-3";
        private const string k_FormatMessages = "You Entered not in context details,please enter again";
        private const string k_WrongFuel = "The Fuel you entered is not sutibale to your vehicle,therefore we didnt fill your engine";
        private const string k_TooMuchFuel = "You entered Too Much fuel,therefore we didnt fill your engine";
        private const string k_TooMuchMinutes = "You entered Too Much Minutes,therefore we didnt fill your engine";
        private const string k_InvalidNumberEntered = "Invalid Option selected, please try again";
        private const string k_InvalidOptionSelected = "Invalid Option entered, please try again:";
        private readonly string k_GarageMenu = string.Format(
@"
Welcome to our Garage:
1. Add New Car
2. See all license Number Vehicle in garage
3. Change status of car
4. Fill air pressure in wheels of vehicle to Maximum
5. Fill fuel vehicle
6. Fill electric vehicle
7. Show all details of vehicle
8. Exit");


        ////////////////////////////////////////////////////////
        // Get input from user
        public string GetInput()
        {
            Console.WriteLine("><><><");
            string userInput = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
            return userInput;
        }

        public int GetNumberFromOptions(string[] i_Options, string i_Title)
        {
            Console.Write(i_Title);
            ShowStringOptions(i_Options);
            int selectedNumber = GetIntInRange(1, i_Options.Length);

            return selectedNumber;
        }


        public string GetLicenseNumber()
        {
            PrintMessage(k_AskingLicenseNumber);
            string licenseNumber = GetInput();
            int number;

            bool validLicenseNumber = false;

            while (!validLicenseNumber)
            {
                validLicenseNumber = int.TryParse(licenseNumber, out number);

                if (!validLicenseNumber)
                {
                    PrintMessage(k_InvalidPhoneNumberError);
                    licenseNumber = GetInput();
                }
            }

            return licenseNumber;
        }

        public string GetPhoneNumber()
        {
            PrintMessage(k_EnterPhoneNumber);
            string phoneNumber = GetInput();
            int number;
            bool validPhoneNumber = false;

            while (!validPhoneNumber)
            {
                validPhoneNumber = int.TryParse(phoneNumber, out number);

                if (!validPhoneNumber)
                {
                    PrintMessage(k_InvalidPhoneNumberError);
                    phoneNumber = GetInput();
                }
            }
            return phoneNumber;
        }

        public string GetOwnerName()
        {
            string ownerName = " ";
            bool invalidOwnerName = false;

            PrintMessage(k_EnterOwnerName);

            while (!invalidOwnerName)
            {
                ownerName = GetInput();

                foreach (char ch in ownerName)
                {
                    if (!char.IsLetter(ch))
                    {
                        PrintMessage(k_InvalidNameError);
                        break;
                    }
                    invalidOwnerName = true;
                }
            }
            return ownerName;
        }

        public int GetOptionInput()
        {
            string inputStr = GetInput();
            int inputNum;
            bool isNumber = int.TryParse(inputStr, out inputNum);
            if (!isNumber)
            {
                PrintMessage(k_InvalidOptionSelected);
                return GetOptionInput();
            }
            else
            {
                return inputNum;
            }
        }

        public int GetIntInRange(int i_Min, int i_Max)
        {
            int selectedNumber = GetIntNumber();

            bool inputIOnRange = selectedNumber >= i_Min && selectedNumber <= i_Max;

            while (!inputIOnRange)
            {
                PrintMessage(k_InvalidOptionSelected);
                selectedNumber = GetIntNumber();
                inputIOnRange = selectedNumber >= i_Min && selectedNumber <= i_Max;
            }

            return selectedNumber;
        }

        public bool GetBool()
        {
            int boolNumber = GetIntNumber();
            bool retVal = false;
            if (boolNumber == 0)
            {
                retVal = false;
            }
            else if (boolNumber == 1)
            {
                retVal = true;
            }
            else
            {
                return GetBool();
            }

            return retVal;
        }

        public int GetIntNumber()
        {
            int inputNumber;
            try
            {
                inputNumber = getNumberFromUser();
            }
            catch (FormatException e)
            {
                PrintMessage(k_InputIsNotANumberError);
                inputNumber = GetIntNumber();
            }


            //string inputStr = GetInput();
            //int inputNum;
            //bool isNumber = int.TryParse(inputStr, out inputNum);
            //if (!isNumber)
            //{
            //    PrintMessage(Messages.InvalidNumberEntered);
            //    return GetIntNumber();
            //}
            //else
            //{
            //    return inputNum;
            //}

            return inputNumber;
        }

        private int getNumberFromUser()
        {
            string input = GetInput();

            return int.Parse(input);
        }

        public float GetFloatInput()
        {
            string inputStr = GetInput();
            float inputNum;
            bool isNumber = float.TryParse(inputStr, out inputNum);
            if (!isNumber)
            {
                PrintMessage(k_InvalidNumberEntered);
                return GetFloatInput();
            }
            else
            {
                return inputNum;
            }
        }

        ////////////////////////////////////////////////////////
        // Print output to user

        public void PrintMenu()
        {
            Console.WriteLine(k_GarageMenu);
        }

        public void PrintMessageWithoutNewLine(string i_MessageToPrint)
        {
            Console.Write(i_MessageToPrint);
        }

        public void PrintMessage(string i_MessageToPrint)
        {
            Console.WriteLine(i_MessageToPrint);
        }

        public void ShowStringOptions(string[] i_Options)
        {
            for (int i = 0; i < i_Options.Length; i++)
            {
                string option = string.Format("{2}{0} - {1}", i + 1, i_Options[i], Environment.NewLine);
                PrintMessageWithoutNewLine(option);
            }
            Console.WriteLine();
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


        ////////////////////////////////////////////////////////
        // GRAY METHODS, CHECK IF SOMEONE USES THEM AT ALL --> IF NOT (AND IF THEY ARE REALLY NOT NEEDED), WE CAN DELETE THEM

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
            PrintMessage(r_AskingTypeOfFuel);

            return GetInput();
        }

        public string AskingAmountOfFuel()
        {
            PrintMessage(k_AskingAmountOfFuel);

            return GetInput();
        }

        public string AskingAmountOfMinutes()
        {
            PrintMessage(k_AskingAmountOfMinutes);

            return GetInput();
        }

        public void CarAlreadyInGarage()
        {
            PrintMessage(k_CarAlreadyInGarage);
        }

        public string GetNewStatusOfVehicle()
        {
            PrintMessage(k_GetNewStatusOfVehicle);

            return GetInput();
        }

        public void WrongNumberOfTypeOfFuel()
        {
            PrintMessage(k_WrongNumberOfTypeOfFuel);
        }

        public void WrongNumberOfOptionOfStatus()
        {
            PrintMessage(k_WrongNumberOfOptionOfStatus);
        }

        public void ShowFormatMessages()
        {
            PrintMessage(k_FormatMessages);
        }

        public void ShowWrongFuel()
        {
            PrintMessage(k_WrongFuel);
        }

        public void ShowTooMuchFuel()
        {
            PrintMessage(k_TooMuchFuel);
        }

        public void ShowTooMuchMinutes()
        {
            PrintMessage(k_TooMuchMinutes);
        }
    }
}