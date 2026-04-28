using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthScanAPI.Models
{
    public class PersonalInformationModel
    {
        public string employeeId { get; set; }
        public string name { get; set; }
        public string age { get; set; }
        public string gender { get; set; }
        public string companyName { get; set; }
        public string department { get; set; }
        public string designation { get; set; }
        public string descent { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
    }
}