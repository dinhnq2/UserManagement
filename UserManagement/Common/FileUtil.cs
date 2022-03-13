using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO; 

namespace UserManagement.Common
{
    public class FileUtil
    {

        private static string FileName_User = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Users.txt");




        /// <summary>
        /// Empty file contain users Json
        /// </summary>
        public static void EmptyUserDataFile( )
        {
            
            string sFileName = FileName_User;

            File.WriteAllText(sFileName, string .Empty );

        }

        /// <summary>
        /// Create file data to contains users
        /// create by DINHNQ.2022.03.12
        /// </summary>
        public static void AppendTextToFile( string txtValue )
        {
            //System.Web.HttpContext.Current.Server.MapPath(path);
            string sFileName = FileName_User;
            // if file not exists it will be created
            //File.WriteAllText(sFileName, sUsersJson);

            if (! File.Exists(sFileName))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(sFileName))
                {
                    sw.WriteLine(txtValue);
                  
                }              
            }
            else
            {
                using (StreamWriter sw = File.AppendText(sFileName))
                {
                    sw.WriteLine(txtValue);
                   
                }
            }

        }


        /// <summary>
        /// Get all text in file data
        /// Create by: DINHNQ.2022.03.12
        /// </summary>
        /// <returns></returns>
        public static List <string> ReadAllTextInDataFile()
        {
            string sFileName = FileName_User;
            List<string> result = new List<string>(); 
            // Open the file to read from.
            using (StreamReader sr = File.OpenText(sFileName))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                     
                    if ( s!= string .Empty )
                    {
                        result.Add(s);
                    }
                    
                }
            }

            return result;
        }



      


    }
}