using System;
using System.Collections.Generic;
using System.Net.Configuration;

//using System.Linq;

namespace Ex03.GarageLogic
{
    public static class eNumUtils
    {
        public static string[] GetValues<T>()
        {
            return Enum.GetNames(typeof(T)); //Enum.GetValues(typeof(T)).Cast<T>();
        }

        //public static List<T> GetValues<T>()       // what the fuck this method do
        //{
        //    Array values = Enum.GetValues(typeof(T));
        //    return ArrayToList(values);             //need to write this method ourselves
        //}

        public static bool TryParseEnum<T>(string value, out T o_Result)
        {
            bool ignoreCase = true;
            bool retVal = true;
            o_Result = default(T);

            try
            {
                o_Result = (T)Enum.Parse(typeof(T), value, ignoreCase);
            }
            catch (Exception ex)
            {
                retVal = false;
            }

            return retVal;
        }
    }
}