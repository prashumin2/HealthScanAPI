using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthScanAPI.Models
{
    public class VisionModel
    {
        public string rightEyeDistance { get; set; }
        public string leftEyeDistance { get; set; }
        public string rightEyeNear { get; set; }
        public string leftEyeNear { get; set; }
        public string colorVisionRightEye { get; set; }
        public string colorVisionLeftEye { get; set; }
    }
}