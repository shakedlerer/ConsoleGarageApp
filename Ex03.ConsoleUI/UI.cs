using System;

namespace Ex03.ConsoleUI
{
    public class UI
    {
        private readonly string k_GarageMenu = string.Format(
@" --------------------------------------------------
|              Welcome to our Garage:              |
 --------------------------------------------------
1. Add New Car
2. See all license Number Vehicle in garage
3. Change status of car
4. Fill tires to max air pressure
5. Fill fuel vehicle
6. Charge electric vehicle
7. Show all details of vehicle
8. Exit");
        private const int k_NumberOfMenuOptions = 8;

        // Get input from user METHODS

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

            PrintMessage(i_Title);
            PrintOptionsToChoose(i_Options);
            selectedNumber = GetNumberInRange(1, i_Options.Length);

            return selectedNumber;
        }

        public string GetLicenseNumber()
        {
            const string k_AskingLicenseNumber = "Please enter vehicle's license number:";
            const string k_InvalidPhoneNumberError = "Error: Invalid license number entered, please try again.";
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
            const string k_EnterPhoneNumber = "Please enter owner's phone number:";
            const string k_InvalidPhoneNumberError = "Error: Invalid phone number entered, please try again.";
            int number;
            bool validPhoneNumber = false;
            string phoneNumber;

            PrintMessage(k_EnterPhoneNumber + Environment.NewLine);
            phoneNumber = GetStringInput();
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
            const string k_EnterOwnerName = "Please enter owner's name:";
            const string k_InvalidNameError = "Error: Invalid name entered, please try again.";
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
            int selectedOption;
            selectedOption = GetNumberInRange(1, k_NumberOfMenuOptions);
            return selectedOption;
        }

        public int GetNumberInRange(int i_Min, int i_Max)
        {
            const string k_InvalidOptionSelected = "Error: Invalid option selected, please try again.";
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
            string[] options = {"True", "False" };
            int selectedNumber = GetNumberFromOptions(options, " ");

            return selectedNumber == 1;
        }

        public int GetIntInput()
        {
            const string k_InputIsNotANumberError = "Error: Input is not a number, please try again.";
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
            const string k_InputIsNotANumberError = "Error: Input is not a number, please try again.";
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
                    PrintMessage(k_InputIsNotANumberError);
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

        // Print output to user METHODS

        public void PrintMenu()
        {
            Console.WriteLine(k_GarageMenu);
        }

        public void PrintMessage(string i_MessageToPrint)
        {
            Console.Write(i_MessageToPrint);
        }

        public void PrintOptionsToChoose(string[] i_Options)
        {
            for (int i = 0; i < i_Options.Length; i++)
            {
                string option = string.Format("{2}{0} - {1}", i + 1, i_Options[i], Environment.NewLine);
                PrintMessage(option);
            }
            PrintMessage(Environment.NewLine);
        }
    }
}