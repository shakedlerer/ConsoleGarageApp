using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    class InputValidator
    {
        private const int k_NumberOfNewStatus = 3;
        private const int k_NumberOfFuelType = 4;

        //public void CheckIfStringIsValidOwnerName(string i_NameString)
        //{
        //    foreach (char ch in i_NameString)
        //    {
        //        if (!char.IsLetter(ch))
        //        {
        //            string errorMsg = string.Format("Error: invalid Owner Name: {0}", i_NameString);
        //            throw new ArgumentException(errorMsg);
        //        }
        //    }
        //}

        //public bool CheckIfInputIsNumber(string i_NumberString, out int o_Number)
        //{
        //    return int.TryParse(i_NumberString, out o_Number);
        //}

        //private bool allCharsAreLetterOrDigit(string I_Str)
        //{
        //    bool isValid = true;
        //    foreach (char ch in I_Str)
        //    {
        //        if (!char.IsLetterOrDigit(ch))
        //        {
        //            isValid = false;
        //        }
        //    }

        //    return isValid;
        //}
        //public void ValidateLicenseNumber(string i_LicenseNumberString)
        //{
        //    if (i_LicenseNumberString.Length == 0 || !allCharsAreLetterOrDigit(i_LicenseNumberString))
        //    {
        //        string errorMsg = string.Format("Error: Invalid License ID: {0}", i_LicenseNumberString);
        //        throw new ArgumentException(errorMsg);
        //    }
        //}
    }
}