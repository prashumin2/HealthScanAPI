using System;
using System.ComponentModel.DataAnnotations;

namespace HealthScanAPI.Models.DatabaseModels
{
    public class Branch
    {
        [Key]
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public string CorporateId { get; set; }
        public string BranchAddress { get; set; }
        public string BranchCity { get; set; }
        public string BranchState { get; set; }
        public string BranchPin { get; set; }
        public string BranchCountry { get; set; }
        public string BranchPerson { get; set; }
        public string BranchPhone { get; set; }
        public string BranchMobile { get; set; }
        public string BranchEmail { get; set; }
        public string BranchScanType { get; set; }
        public int BranchDays { get; set; }
        public bool? BranchStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Remarks { get; set; }
        public string EventType { get; set; }
        public string EventDate { get; set; }
        public virtual Corporate Corporate { get; set; }
    }
}