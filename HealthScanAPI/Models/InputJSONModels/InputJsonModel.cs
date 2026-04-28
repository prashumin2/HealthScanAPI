namespace HealthScanAPI.Models
{
    public class InputJsonModel
    {
        public PersonalInformationModel personalInformation { get; set; }
        public FamilyMedicalHistory familyMedicalHistory { get; set; }
        public MedicalDetailsModel medicalDetails { get; set; }
        public PhysicalTestsModel physicalTests { get; set; }
        public VisionModel vision { get; set; }
        public HearingModel hearing { get; set; }
        public LifestyleModel lifestyle { get; set; }
    }
}