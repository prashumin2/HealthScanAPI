using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthScanAPI.Models.DatabaseModels
{
    public class Corporate
    {
        public int Cid { get; set; }

        [Key]
        public string CorporateName { get; set; }
        public string CorporateId { get; set; }
        public string CorporateAddress { get; set; }
        public string CorporateCity { get; set; }
        public string CorporateState { get; set; }
        public string CorporatePin { get; set; }
        public string CorporateCountry { get; set; }
        public string CorporateContactPerson { get; set; }
        public string CorporatePhone { get; set; }
        public string CorporateMobile { get; set; }
        public string CorporateEmail { get; set; }
        public string CorporateWebsite { get; set; }
        public string CorporateScanType { get; set; }
        public int CorporateDays { get; set; }
        public bool? CorporateStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Remarks { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
    }
}