using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace childmanagementsystem.Models
{
    public class getstatemastermodel
    {
        public int stateid { get; set; }
        public string statename { get; set; }
        public int statecode { get; set; }
        public string createddate { get; set; }
        public string createdby { get; set; }
        public string modifieddate { get; set; }
        public string modifiedby { get; set; }
        public int isactive { get; set; }
        public int isdelelted { get; set; }
    }
}