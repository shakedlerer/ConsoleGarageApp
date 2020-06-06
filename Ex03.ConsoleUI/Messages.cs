using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public static class Messages
    {
        public static string
             AskingLicenseNumber = "Please Enter your License Number",
             ShowVehiclesLicenseNumbers = "Please choose which vehicle's license numbers to show (by status or all)",
             AskingOptionOfMenu = "Please choose one of the option below",
             AskingTypeOfFuel = string.Format("Please Choose the Type of fuel.{0}1-Octan95{0}2-Octan96{0}3-Octan98{0}4-Soler", Environment.NewLine),
             AskingAmountOfFuel = "Please enter the amount of fuel you want to fill",
             AskingAmountOfMinutes = "PLease enter the amount of minutes you want to load",
             CarAlreadyInGarage = "Your car is Already in the garage",
             GetNewStatusOfVehicle = string.Format("Please enter the new status you want for your vehicle", Environment.NewLine),
             WrongNumberOfTypeOfFuel = "Please enter Number in range of 1-4",
             WrongNumberOfOptionOfStatus = "Plase enter Number in Range of 1-3",
             FormatMessages = "You Entered not in context details,please enter again",
             WrongFuel = "The Fuel you entered is not sutibale to your vehicle,therefore we didnt fill your engine",
             TooMuchFuel = "You entered Too Much fuel,therefore we didnt fill your engine",
             TooMuchMinutes = "You entered Too Much Minutes,therefore we didnt fill your engine",
            SelectVehicleType = string.Format("Select vehicle type:{0}", Environment.NewLine),
            EnterOwnerName = string.Format("Enter Owner Name:{0}", Environment.NewLine),
            EnterPhoneNumber = string.Format("Enter Phone Number:{0}", Environment.NewLine),
            InvalidOptionSelected = string.Format("Invalid Option entered, try again:{0}", Environment.NewLine),
            InvalidNumberEntered = string.Format("Invalid Option selected, please try again..{0}", Environment.NewLine),
            InputIsNotANumberError = string.Format("Input is not a number, please try again..{0}", Environment.NewLine),
            InvalidPhoneNumberError = "Invalid phone number entered, please try again..",
             InvalidLicenseNumberError = "Invalid license number entered, please try again..",
             VehicleDoesntExistError = "Vehicle does not exist in garage, please try again",
             InvalidNameError = "Error: invalid Owner Name. please try again..",
            GarageMenu = string.Format(@"
Welcome to our Garage:{0}
1.Add New Car{0}
2.See all license Number Vehicle in garage{0}
3.Change status of car{0}
4.fill air pressure in wheels of vehicle to Maximum{0}
5.fill fuel vehicle{0}
6.fill electric vehicle{0}
7.show all details of vehicle{0}
8.exit"
, Environment.NewLine);
    }
}