using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace childmanagementsystem.Models
{
    public class UserData_Model
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string gender { get; set; }
        public string date { get; set; }
        public string mobilenumber { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string confirmpassword { get; set; }
        public string createddate { get; set; }
        public string createdby { get; set; }
        public string modifieddate { get; set; }
        public string modifiedby { get; set; }
        public string isactive { get; set; }
        public string isdeleted { get; set; }
    }
}