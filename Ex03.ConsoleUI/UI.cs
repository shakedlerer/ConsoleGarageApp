using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class UI
    {
        // Get input from user

        public string GetStringInput()
        {
            return Console.ReadLine();
        }

        public int GetNumberFromOptions(string[] i_Options, string i_Title)
        {
            int selectedNumber;

            PrintMessage(i_Title);
            ShowStringOptions(i_Options);
            selectedNumber = GetNumberInRange(1, i_Options.Length);

            return selectedNumber;
        }

        public string GetLicenseNumber()
        {
            int number;
            bool validLicenseNumber = false;

            PrintMessage(Messages.AskingLicenseNumber);
            string licenseNumber = GetStringInput();

            while (!validLicenseNumber)
            {
                validLicenseNumber = int.TryParse(licenseNumber, out number);

                if (!validLicenseNumber)
                {
                    PrintMessage(Messages.InvalidLicenseNumberError);
                    licenseNumber = GetStringInput();
                }
            }

            return licenseNumber;
        }

        public string GetPhoneNumber()
        {
            PrintMessage(Messages.EnterPhoneNumber);
            string phoneNumber = GetStringInput();
            int number;
            bool validPhoneNumber = false;

            while (!validPhoneNumber)
            {
                validPhoneNumber = int.TryParse(phoneNumber, out number);

                if (!validPhoneNumber)
                {
                    PrintMessage(Messages.InvalidPhoneNumberError);
                    phoneNumber = GetStringInput();
                }
            }
            return phoneNumber;
        }

        public string GetOwnerName()
        {
            string ownerName = " ";
            bool invalidOwnerName = false;

            PrintMessage(Messages.EnterOwnerName);

            while (!invalidOwnerName)
            {
                invalidOwnerName = true;
                ownerName = GetStringInput();

                foreach (char ch in ownerName)
                {
                    if(!char.IsLetter(ch))
                    {
                        invalidOwnerName = false;
                        PrintMessage(Messages.InvalidNameError);
                        break;
                    }
                }
            }
            return ownerName;
        }

        public int GetOptionInput()
        {
            string inputStr = GetStringInput();
            int inputNum;
            bool isNumber = int.TryParse(inputStr, out inputNum);
            if (!isNumber)
            {
                PrintMessage(Messages.InvalidOptionSelected);
                return GetOptionInput();
            }
            else
            {
                return inputNum;
            }
        }

        public int GetNumberInRange(int i_Min, int i_Max)
        {
            int selectedNumber = GetIntInput();

            bool inputIOnRange = selectedNumber >= i_Min && selectedNumber <= i_Max;

            while (!inputIOnRange)
            {
                PrintMessage(Messages.InvalidOptionSelected);
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
                    PrintMessage("Invalid Number, please try again...");
                }
            }

            return inputNumber;
        }

        public float GetFloatInput()
        {
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
                    PrintMessage("Invalid Number, please try again...");
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
            Console.WriteLine(Messages.GarageMenu);
        }

        public void PrintMessage(string i_MessageToPrint)
        {
            Console.WriteLine(i_MessageToPrint);
        }

        public void ShowStringOptions(string[] i_Options)
        {
            for (int i = 0; i < i_Options.Length; i++)
            {
                string option = string.Format("{0} - {1}{2}", i + 1, i_Options[i], Environment.NewLine);
                PrintMessage(option);
            }
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

        public string AskingTypeOfFuel()
        {
            PrintMessage(Messages.AskingTypeOfFuel);

            return GetStringInput();
        }

        public string AskingAmountOfFuel()
        {
            PrintMessage(Messages.AskingAmountOfFuel);

            return GetStringInput();
        }

        public string AskingAmountOfMinutes()
        {
            PrintMessage(Messages.AskingAmountOfMinutes);

            return GetStringInput();
        }

        public void CarAlreadyInGarage()
        {
            PrintMessage(Messages.CarAlreadyInGarage);
        }

        public string GetNewStatusOfVehicle()
        {
            PrintMessage(Messages.GetNewStatusOfVehicle);

            return GetStringInput();
        }

        public void WrongNumberOfTypeOfFuel()
        {
            PrintMessage(Messages.WrongNumberOfTypeOfFuel);
        }

        public void WrongNumberOfOptionOfStatus()
        {
            PrintMessage(Messages.WrongNumberOfOptionOfStatus);
        }

        public void ShowFormatMessages()
        {
            PrintMessage(Messages.FormatMessages);
        }

        public void ShowWrongFuel()
        {
            PrintMessage(Messages.WrongFuel);
        }

        public void ShowTooMuchFuel()
        {
            PrintMessage(Messages.TooMuchFuel);
        }

        public void ShowTooMuchMinutes()
        {
            PrintMessage(Messages.TooMuchMinutes);
        }
    }
}