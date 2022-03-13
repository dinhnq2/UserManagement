using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Converters;
using System.Web.Mvc;
using System.IO;
namespace UserManagement.Common
{
    public class JsonUtil
    {

        /// <summary>
        /// Convert user to json
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string  ConvertUserToJson(Models.Users user)
        {

            string userNameJson = Newtonsoft.Json.JsonConvert.SerializeObject(user);//
            return userNameJson;

        }


        public static string ConvertListUserToJson(List<Models.Users>  lstUser)
        {
            string result = string.Empty;
            for (int index = 0; index < lstUser.Count; index++)
            {
                if (index == 0)
                {
                    result = ConvertUserToJson(lstUser[index]);
                }
                else
                {
                    result = result + "\n" + ConvertUserToJson(lstUser[index]);
                }

            }

            //string lstUsersJson = Newtonsoft.Json.JsonConvert.SerializeObject(lstUser);//
            //return lstUsersJson;
            return result;
        }

        /// <summary>
        /// Convert String Json to Object
        /// </summary>
        /// <param name="userJson"></param>
        /// <returns></returns>
        public static Models.Users ConvertStringJsonToUser(string  userJson)
        {
            try
            {
                Models.Users user = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Users>(userJson);
                               
                return user;
            }
            catch ( Exception ex)
            {
                return null;
            }
          

        }
    }
}