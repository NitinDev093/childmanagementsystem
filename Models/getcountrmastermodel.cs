using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace childmanagementsystem.Models
{
    public class getcountrmastermodel
    {
        public int countryid { get; set; }
        public string countryname{ get; set; }
        public int countrycode { get; set; }
        public string createddate { get; set; }
        public string createdby { get; set; }
        public string modifieddate { get; set; }
        public string modifiedby { get; set; }
        public int isactive { get; set; }
        public int isdelelted { get; set; }
    }
}