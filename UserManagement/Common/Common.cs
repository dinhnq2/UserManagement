using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagement.Common
{
    public class Common
    {

        /// <summary>
        /// Check string is integer
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsInt( string  txt)
        {
            try
            {
                int a = Convert.ToInt32(txt);
                return true;
            }
            catch ( Exception ex)
            {
                return false;
            }

        }


        public static int  ConvertStringToInt(string txt)
        {
            try
            {
                int a = Convert.ToInt32(txt);
                return a;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}