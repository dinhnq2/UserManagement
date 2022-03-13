using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using UserManagement;
namespace UserManagement.Models
{
    public class Users : object
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "ID:")]
        public string ID { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First name:")]
        public string FirstName { get; set; }


        [Required]
        [DataType(DataType.Text )]
        [Display(Name = "Last name:")]
        public string LastName { get; set; }



        public static void AppendUser_2_File(Models.Users user)
        {
            //List<clsSystem_Users> listUser = new List<clsSystem_Users>();
            //clsSystem_Users user = new clsSystem_Users();
            //listUser = user.GetList("", "", ref errMsg);
            //return Json(listUser, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Insert user to file in Json when click Create in form
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="errMsg"></param>
        public static  void InsertToFile(Models.Users user, ref string errMsg)
        {
            try
            {
                errMsg = string.Empty;
                string userJson = Common.JsonUtil.ConvertUserToJson(user);
                Common.FileUtil.AppendTextToFile(userJson);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

        }


        /// <summary>
        /// Update user to file in Json when click Save in form
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="errMsg"></param>
        public static  void UpdateToFile(Models.Users updateUser, ref string errMsg)
        {
            try
            {
                errMsg = string.Empty;
                 
                // get all user in file
                List<Models.Users> lstUsers = GetList(ref errMsg);              
               
                
                // update for selected user 
                for (int index = 0; index < lstUsers.Count; index++)
                {
                    if (lstUsers != null && lstUsers[index].ID == updateUser.ID)
                    {
                        lstUsers[index].FirstName = updateUser.FirstName;
                        lstUsers[index].LastName = updateUser.LastName;
                    }                    
                    
                }

                // Clear file
                Common.FileUtil.EmptyUserDataFile();

               
                string userLstJson = Common.JsonUtil.ConvertListUserToJson(lstUsers);
                // Update all to file
                Common.FileUtil.AppendTextToFile(userLstJson);


            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

        }



        /// <summary>
        /// Insert user to file in Json when click Create in form
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="errMsg"></param>
        public static void DeleteUserFromFile(string id, ref string errMsg)
        {
            try
            {
                errMsg = string.Empty;

                // get all user in file
                List<Models.Users> lstUsers = GetList(ref errMsg);

                var itemToRemove = lstUsers.Single(r => r.ID  == id);
                lstUsers.Remove(itemToRemove);

                // Clear file
                Common.FileUtil.EmptyUserDataFile();

                //========= Convert list to string Json  
                string userLstJson = Common.JsonUtil.ConvertListUserToJson(lstUsers);
                // Update all to file
                Common.FileUtil.AppendTextToFile(userLstJson);


            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

        }


        /// <summary>
        /// Get ID max in file user Json
        /// </summary>
        /// <returns></returns>
        public int  GetMaxID( )
        {
            string errMsg = string.Empty;
            List<Models.Users> lstUsers = GetList(ref errMsg);
            int idMax = 0;
            for (int index = 0; index < lstUsers.Count; index++)
            {
                 if (idMax <   Common .Common . ConvertStringToInt(lstUsers[index].ID ))
                {
                    idMax = Common.Common.ConvertStringToInt(lstUsers[index].ID);
                }
                 
            }

            return idMax;


        }

        /// <summary>
        /// Get list users in file Json
        /// Create by DINHNQ.2022.03.12        
        /// </summary>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public static  List<Models.Users> GetList(  ref string errMsg)
        {
            try
            {
                errMsg = String.Empty;              
              
                List<string> lstUserJson = Common.FileUtil.ReadAllTextInDataFile();

                List<Models.Users> lstUsers = new List<Models.Users>();

                for( int index =0; index < lstUserJson.Count; index ++ )
                {
                   Models.Users userTemp = Common.JsonUtil.ConvertStringJsonToUser(lstUserJson[index ]);
                    if (userTemp != null )
                    {
                        lstUsers.Add(userTemp);
                    }
                    else
                    {
                        errMsg = "Can not convert [" + lstUserJson[index] + "] to user object";
                    }

                }
                
                return lstUsers;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return null;
            }

        }


        /// <summary>
        /// Get user from File
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public static  Models.Users GetUser(string idUser)
        {
            try
            {

                List<string> lstUserJson = Common.FileUtil.ReadAllTextInDataFile();

                List<Models.Users> lstUsers = new List<Models.Users>();
               

                for (int index = 0; index < lstUserJson.Count; index++)
                {
                     
                    Models.Users userTemp = Common.JsonUtil.ConvertStringJsonToUser(lstUserJson[index]);
                  
                    if (userTemp != null  && userTemp.ID == idUser)
                    {
                        return userTemp;
                    }
                   
                }

                return null ;
            }
            catch (Exception ex)
            {                
                return null;
            }

        }



    }
}