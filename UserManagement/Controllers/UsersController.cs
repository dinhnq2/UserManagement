using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    public class UsersController : Controller
    {
        private string errMsg = string.Empty;


        


        [HttpGet]
        public ActionResult InsertUser()
        {
            string errMsg = string.Empty;

            UserManagement.Models.Users    objUser = new  Users ();
           
            objUser.ID =( objUser.GetMaxID() + 1).ToString (); // ID mac dinh 

            return View(objUser);

            //return View();
        }



        /// <summary>
        /// Insert User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InsertUser(Models.Users  user)
        {
            string errMsg = string.Empty;
             Users .InsertToFile(user, ref errMsg);

            if (errMsg == string.Empty)
            {                
                return RedirectToAction("ListUsers", "Users");
            }

            else

                return View();
        }



        /// <summary>
        /// Update System User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UpdateUser(string id)
        {
            string errMsg = string.Empty;            
            Users user = new Users();
            user = Users.GetUser(id);

            if (user != null )
            {
                return View(user);
              
            }
            else
            {
                ViewBag.Message = String.Format("Can not find User with ID="+ id );

                return View();
            }

              
        }


        /// <summary>
        /// Update System User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateUser(Models.Users  user)
        {
            string errMsg = string.Empty;
            Users.UpdateToFile(user, ref errMsg);

            if (errMsg == string.Empty)
            {
                return RedirectToAction("ListUsers", "Users");

            }

            else

                return View();
        }


        [HttpGet]
        public ActionResult ListUsers()
        {

            string errMsg = string.Empty;
            List<UserManagement.Models.Users     > lstUsers = new List<UserManagement.Models.Users>();
            UserManagement.Models.Users objUser = new  Models.Users ();
            lstUsers = Users.GetList(  ref errMsg);
            return View(lstUsers);
        }


        /// <summary>
        /// delete User
        /// </summary>
        /// <param name="user"></param>
        public ActionResult DeleteSystemUser(string id)
        {
            string errMsg = string.Empty;
           
            Users .DeleteUserFromFile(id, ref errMsg);

            if (errMsg == string.Empty)
            {
                return RedirectToAction("ListUsers");
            }
            else
                return null;
        }

    }
}