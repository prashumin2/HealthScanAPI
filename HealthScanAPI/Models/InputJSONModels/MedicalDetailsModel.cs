using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthScanAPI.Models
{
    public class MedicalDetailsModel
    {
        public string bloodPressureSystolic {  get; set; }
        public string bloodPressureDiastolic {  get; set; }
        public string bloodSugarFasting {  get; set; }
        public string bloodSugarRandom {  get; set; }
        public string currentMedication {  get; set; }
        public string medicationReason {  get; set; }
        public string totalCholesterol {  get; set; }
    }
}