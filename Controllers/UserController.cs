using childmanagementsystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace childmanagementsystem.Controllers
{
    public class UserController : Controller
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["my_con"].ConnectionString;
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        //Get
        public ActionResult Login()
        {
            return View();
        }

        //Post
        public ActionResult UserLogin(UserData_Model udm)
        {
            string query;
            UserData_Model user = new UserData_Model();
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                query = "select * from users where Email='" + udm.email + "' and Password='" + udm.password + "' ";
                SqlCommand cmd = new SqlCommand(query,sqlcon);
                sqlcon.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    user.firstname = rdr["FirstName"].ToString();
                    user.lastname = rdr["LastName"].ToString();
                    user.email = rdr["Email"].ToString();
                    Session["UserData"] =user;
                    //Session.Timeout = 1;

                   
                    return Json(new { success = true, message = "Login Successfull", data = user }, JsonRequestBehavior.AllowGet);
                }
                
            }
                    return Json(new { success = false, message = "Invalid username or password", data = "" }, JsonRequestBehavior.AllowGet);

        }
        
        //Logout
        public ActionResult LogOut()
        {
            Session["UserData"] = null;
            return View("Login");
        }

        //Get
        public ActionResult SignUp(UserData_Model udm)
        {
            return View();
        }

        //Post
        public ActionResult InsertUserDetails(UserData_Model udm)
        {
            string query;
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    query = "insert into users(FirstName,LastName,Gender," +
                        "Date,MobileNumber,Email,Password,ConfirmPassword" +
                        ",CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsActive,IsDeleted)" +
                        " values('" + udm.firstname + "','" + udm.lastname + "'," +
                        "'" + udm.gender + "','" + udm.date + "'," +
                        "'" + udm.mobilenumber + "','" + udm.email + "'," +
                        "'" + udm.password + "','" + udm.confirmpassword + "'," +
                        "'" + DateTime.Now + "','" + udm.createdby + "','" + udm.modifieddate + "'," +
                        "'" + udm.modifiedby + "','1','0')";
                    SqlCommand cmd = new SqlCommand(query, sqlcon);
                    sqlcon.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        return Json(new { success = true, message = "Data saved Successfully" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, message = "Unable to save data" }, JsonRequestBehavior.AllowGet);
                    }
                }

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Internal server error" }, JsonRequestBehavior.AllowGet);
            }

        }
    }


        
    
}