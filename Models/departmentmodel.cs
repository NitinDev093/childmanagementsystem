using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace childmanagementsystem.Models
{
    public class departmentmodel
    {
        public int deptid { get; set; }
        public string deptname { get; set; }
        public int deptcode { get; set; }
        public string createddate { get; set; }
        public string createdby { get; set; }
        public string modifieddate { get; set; }
        public string modifiedby { get; set; }
        public int isactive { get; set; }
        public int isdelelted { get; set; }
    }
}