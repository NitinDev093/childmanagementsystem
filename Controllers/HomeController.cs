using childmanagementsystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace childmanagementsystem.Controllers
{
    public class HomeController : Controller
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["my_con"].ConnectionString;
        public ActionResult Index()
        {
            if (Session["UserData"] == null)
                return Redirect("/User/Login");
            else 
            return View();
        }

        public ActionResult About()
        {
                return View();

        }

        public ActionResult Contact()
        {
                return View();
        }

        //Get Method
        public ActionResult AddChildren()
        {
                return View();
        }
        //Post method
        public ActionResult InsertChildrenData(ChildData_1_modal cm)
        {
            string query;
            try
            {
                using(SqlConnection sqlcon=new SqlConnection(connectionstring))
                {
                    query = "INSERT INTO childdata_1 (Name,Age,Gender,Class," +
                          "FatherName,MotherName,MobileNumber,Address,Country,State,Department,Desigination)" + "VALUES('" + cm.Name + "','"+cm.Age+"','"+cm.Gender+"','"+cm.Classs+"','"+
                          cm.FatherName+"','"+cm.MotherName+"','"+cm.MobileNumber+"','"+cm.Address+"'," +
                          "'"+cm.Country+"','"+cm.State+"','"+cm.Department+"','"+cm.Desigination+"')";
                    SqlCommand cmd = new SqlCommand(query,sqlcon);
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

        //using strongly typed view we get children data list...........
        public ActionResult ShowChildrenList()
        {
            int Sr_No = 0;
            string query;
            List<ChildData_1_modal> list = new List<ChildData_1_modal>();
            ChildData_1_modal cm = new ChildData_1_modal();
            using(SqlConnection sqlcon=new SqlConnection(connectionstring))
            {
                
                SqlCommand cmd = new SqlCommand("usp_getchilddata", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                sqlcon.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Sr_No = Sr_No + 1;
                    cm = new ChildData_1_modal();
                    cm.Sr_No = Sr_No;
                    cm.Id = Convert.ToInt32(rdr["Id"]);
                    cm.Name = rdr["Name"].ToString();//jo right side me Name variable hai wo mere databse ka variable hai.
                    cm.Age = Convert.ToInt32(rdr["Age"]);//aur left side me modal wala variable hai
                    cm.Gender = rdr["Gender"].ToString();
                    cm.Classs = rdr["Class"].ToString();
                    cm.FatherName = rdr["FatherName"].ToString();
                    cm.MotherName = rdr["MotherName"].ToString();
                    cm.MobileNumber = rdr["MobileNumber"].ToString();
                    cm.Address = rdr["Address"].ToString();
                    cm.Country = rdr["Country"].ToString();
                    cm.CountryId = rdr["CountryId"].ToString();
                    cm.State = rdr["State"].ToString();
                    cm.StateId = rdr["StateId"].ToString();
                    cm.Department = rdr["Department"].ToString();
                    cm.DepartmentId = rdr["DepartmentId"].ToString();
                    cm.Desigination = rdr["Desigination"].ToString();
                    cm.DesiginationId = rdr["DesiginationId"].ToString();
                    list.Add(cm);
                }
            }
           return View(list);
        }

        //using json we get children data list....
        public ActionResult ShowChildrenListt()
        {

            int Sr_No = 0;
            string query;
            List<ChildData_1_modal> list = new List<ChildData_1_modal>();
            ChildData_1_modal cm = new ChildData_1_modal();
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                query = "select * from ChildData_1";
                SqlCommand cmd = new SqlCommand(query, sqlcon);
                sqlcon.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                
                while (rdr.Read())
                {
                    Sr_No = Sr_No + 1;
                    cm = new ChildData_1_modal();
                    cm.Sr_No = Sr_No;
                    cm.Id = Convert.ToInt32(rdr["Id"]);
                    cm.Name = rdr["Name"].ToString();//jo right side me Name variable hai wo mere databse ka variable hai.
                    cm.Age = Convert.ToInt32(rdr["Age"]);//aur left side me modal wala variable hai
                    cm.Gender = rdr["Gender"].ToString();
                    cm.Classs = rdr["Class"].ToString();
                    cm.FatherName = rdr["FatherName"].ToString();
                    cm.MotherName = rdr["MotherName"].ToString();
                    cm.MobileNumber = rdr["MobileNumber"].ToString();
                    cm.Address = rdr["Address"].ToString();
                    list.Add(cm);
                }
            }
            return Json(new { Status = true, Data = list }, JsonRequestBehavior.AllowGet);
        }

        //delete children data........
        public ActionResult DeleteChildrenData(int Id)
        {
            try
            {
                string query;
                using (SqlConnection sqlcon=new SqlConnection(connectionstring))
                {
                    query = "delete from ChildData_1 where Id='"+Id+"'";
                    SqlCommand cmd = new SqlCommand(query,sqlcon);
                    sqlcon.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        return Json(new { success = true, message = "Data deleted Successfully" }, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        return Json(new { success = false, message = "Unable to delete data" }, JsonRequestBehavior.AllowGet);

                    }
                }
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = "Internal server error" }, JsonRequestBehavior.AllowGet);

            }
        }


        //update children data...
        public ActionResult UpdateChildrenData(string Id,string Name,string Age,string Gender,string Classs,string FatherName,string MotherName,string MobileNumber,string Address,String Country,string State,string Department,string Desigination)
        {
            try
            {
                string query;
                using (SqlConnection sqlcon=new SqlConnection(connectionstring))
                {
                    query = "update ChildData_1 set Name='" + Name + "',Age='" + Age + "',Gender='" + Gender + "',Class='" + Classs + "',FatherName='" + FatherName + "',MotherName='" + MotherName + "',MobileNumber='" + MobileNumber + "',Address='" + Address + "',Country='"+Country+"',State='"+State+"',Department='"+Department+"',Desigination='"+Desigination+"' where Id='" + Id + "'";
                    SqlCommand cmd = new SqlCommand(query,sqlcon);
                    sqlcon.Open();
                    int isRowAffected = cmd.ExecuteNonQuery();
                    if (isRowAffected > 0)
                    {
                        return Json(new { success = true, message = "Data Updated Successfully" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, message = "Unable to Update data" }, JsonRequestBehavior.AllowGet);
                    }

                }
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = "Internal server error" }, JsonRequestBehavior.AllowGet);

            }
        }

        public ActionResult GetCountryMaster()
        {
            List<getcountrmastermodel> list=new List<getcountrmastermodel>();
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("usp_CountryMaster",sqlcon);
                cmd.CommandType= CommandType.StoredProcedure;
                sqlcon.Open();
                SqlDataReader rdr= cmd.ExecuteReader();
                while (rdr.Read())
                {
                   getcountrmastermodel gcm=new getcountrmastermodel();
                    gcm.countryid = Convert.ToInt32(rdr["CountryId"]);
                    gcm.countryname = rdr["CountryName"].ToString();
                    gcm.countrycode = Convert.ToInt32(rdr["CountryCode"]);
                    list.Add(gcm);
                }
            }
            return Json(new { Status = true, Data = list }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetStateMaster(int CountryId)
        {
            List<getstatemastermodel> list = new List<getstatemastermodel>();
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("usp_StateMaster", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CountryId", CountryId);
                sqlcon.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    getstatemastermodel gcm = new getstatemastermodel();
                    gcm.stateid = Convert.ToInt32(rdr["StateId"]);
                    gcm.statename = rdr["StateName"].ToString();
                    gcm.statecode = Convert.ToInt32(rdr["StateCode"]);
                    list.Add(gcm);
                }
            }
            return Json(new { Status = true, Data = list }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetDepartment()
        {
            List<departmentmodel> list = new List<departmentmodel>();
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("usp_Department", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                sqlcon.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    departmentmodel dm = new departmentmodel();
                    dm.deptid = Convert.ToInt32(rdr["DeptId"]);
                    dm.deptname = rdr["DeptName"].ToString();
                    dm.deptcode = Convert.ToInt32(rdr["DeptCode"]);
                    list.Add(dm);
                }
            }
            return Json(new { Status = true, Data = list }, JsonRequestBehavior.AllowGet);

        }

        //get desigination
        public ActionResult GetDesigination()
        {
            List<desiginationmodel> list = new List<desiginationmodel>();
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("usp_Desigination", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                sqlcon.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    desiginationmodel dm = new desiginationmodel();
                    dm.degid = Convert.ToInt32(rdr["DegId"]);
                    dm.degname = rdr["DegName"].ToString();
                    dm.degcode = Convert.ToInt32(rdr["DegCode"]);
                    list.Add(dm);
                }
            }
            return Json(new { Status = true, Data = list }, JsonRequestBehavior.AllowGet);

        }
    }
}