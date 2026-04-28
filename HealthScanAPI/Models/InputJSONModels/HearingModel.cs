using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthScanAPI.Models
{
    public class HearingModel
    {
        public string rightEar {  get; set; }
        public string leftEar {  get; set; }
    }
}