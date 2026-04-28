using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthScanAPI.Models
{
    public class PhysicalTestsModel
    {
        public string height { get; set; }
        public string weight { get; set; }
        public string pulse { get; set; }
        public string waist { get; set; }
        public string breathRetention { get; set; }
        public string peakFlow { get; set; }
    }
}