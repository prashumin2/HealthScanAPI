using HealthScanAPI.Models.DatabaseModels;
using HealthScanAPI.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;
using System.Web.Http.Results;

namespace HealthScanAPI.Controllers
{
    [RoutePrefix("api/HealthScan")]

    public class HealthScanController : ApiController
    {
        private readonly HealthScanApiService _service = new HealthScanApiService();

        [HttpPost]
        [Route("registerUser")]
        public IHttpActionResult RegisterUser([FromBody] JObject data)
        {
            if (data == null)
                return BadRequest("Invalid JSON");

            int age = data.SelectToken("personalInformation.age")?.Value<int>() ?? 0;
            DateTime DobSample = new DateTime(DateTime.Now.Year - age, 1, 1);

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@cid", data.SelectToken("personalInformation.cid")?.Value<string>() ?? "8B3V4BVUS5"),
                new SqlParameter("@bid", data.SelectToken("personalInformation.bid")?.Value<string>() ?? "BRA0002"),
                new SqlParameter("@fname", data.SelectToken("personalInformation.name")?.Value<string>() ?? ""),
                new SqlParameter("@lname", data.SelectToken("personalInformation.name")?.Value<string>() ?? ""),
                new SqlParameter("@rmobile", data.SelectToken("personalInformation.mobile")?.Value<string>() ?? ""),
                new SqlParameter("@rDOB", DobSample),
                new SqlParameter("@remail", data.SelectToken("personalInformation.email")?.Value<string>() ?? ""),
                new SqlParameter("@rextmobile", data.SelectToken("personalInformation.extmobile")?.Value<string>() ?? ""),
                new SqlParameter("@gender", data.SelectToken("personalInformation.gender")?.Value<string>() ?? ""),
                new SqlParameter("@empid", data.SelectToken("personalInformation.employeeId")?.Value<string>() ?? ""),
                new SqlParameter("@empidtype", data.SelectToken("personalInformation.empidtype")?.Value<string>() ?? ""),
                new SqlParameter("@usertype", data.SelectToken("personalInformation.usertype")?.Value<string>() ?? ""),
                new SqlParameter("@passw", data.SelectToken("personalInformation.passw")?.Value<string>() ?? "")
            };


            var result = _service.CommonStoredProcedureMethod("usp_registeruser", parameters.ToArray());

            return Ok(result);
        }

        [HttpPost]
        [Route("registerUserAPI")]
        public IHttpActionResult RegisterUserAPI([FromBody] JObject data)
        {
            if (data == null)
                return BadRequest("Invalid JSON");

            int age = data.SelectToken("personalInformation.age")?.Value<int>() ?? 0;
            DateTime DobSample = new DateTime(DateTime.Now.Year - age, 1, 1);

            string corporateId = data.SelectToken("personalInformation.cid")?.Value<string>() ?? "";
            if (corporateId != "")
            {
                var corporateIds = _service.CheckCorporateIdPresent(corporateId);
                if (corporateIds.Count == 0)
                {
                    CreateCorporate(data);
                }
            }
            else return BadRequest("Corporate ID is required");

            string branchId = data.SelectToken("personalInformation.bid")?.Value<string>() ?? "";
            if (branchId != "")
            {
                var branchIds = _service.CheckBranchIdPresent(branchId);
                if (branchIds.Count == 0)
                {
                    CreateBranch(data);
                }
            }
            else return BadRequest("Branch ID is required");

            var result = RegisterUser(data, corporateId, branchId, DobSample);

            return Ok(result);
        }

        [HttpPost]
        [Route("registerScan")]
        public IHttpActionResult RegisterScan([FromBody] JObject data)
        {
            if (data == null)
                return BadRequest("Invalid JSON");

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@regid", data.SelectToken("personalInformation.regid")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@deptid", data.SelectToken("personalInformation.deptid")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@desgid", data.SelectToken("personalInformation.desgid")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@descent", data.SelectToken("personalInformation.descent")?.Value<string>() ?? ""),
                new SqlParameter("@httype", data.SelectToken("physicalTests.httype")?.Value<string>() ?? ""),
                new SqlParameter("@htFt", data.SelectToken("physicalTests.height")?.Value<string>() ?? ""),
                new SqlParameter("@htIn", data.SelectToken("physicalTests.height")?.Value<string>() ?? ""),
                new SqlParameter("@wttype", data.SelectToken("physicalTest.weight")?.Value<string>() ?? ""),
                new SqlParameter("@wt", data.SelectToken("physicalTest.weight")?.Value<string>() ?? ""),
                new SqlParameter("@pulse", data.SelectToken("physicalTest.pulse")?.Value<string>() ?? ""),
                new SqlParameter("@peak", data.SelectToken("physicalTest.peakFlow")?.Value<string>() ?? ""),
                new SqlParameter("@waist", data.SelectToken("physicalTest.waist")?.Value<string>() ?? ""),
                new SqlParameter("@breath", data.SelectToken("physicalTest.breathRetention")?.Value<string>() ?? ""),
                new SqlParameter("@temp", data.SelectToken("physicalTest.temp")?.Value<string>() ?? ""),
                new SqlParameter("@spo", data.SelectToken("physicalTest.spo")?.Value<string>() ?? ""),

            };


            var result = _service.CommonStoredProcedureMethod("usp_registerScan", parameters.ToArray());

            return Ok(result);
        }

        [HttpPost]
        [Route("insertPO")]
        public IHttpActionResult InsertPO([FromBody] JObject data)
        {
            if (data == null)
                return BadRequest("Invalid JSON");

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@regid", data.SelectToken("po.regid")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q1", data.SelectToken("lifestyle.insuranceProvided")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q2", data.SelectToken("lifestyle.annualHealthScreening")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q3", data.SelectToken("lifestyle.healthyCanteen")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q4", data.SelectToken("lifestyle.sportsFacility")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q5", data.SelectToken("lifestyle.healthEducation")?.Value<string>() ?? "SAUDI")
            };


            var result = _service.CommonStoredProcedureMethod("usp_InsertPO", parameters.ToArray());

            return Ok(result);
        }

        [HttpPost]
        [Route("insertPLS")]
        public IHttpActionResult InsertPLS([FromBody] JObject data)
        {
            if (data == null)
                return BadRequest("Invalid JSON");

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@regid", data.SelectToken("po.regid")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q1", data.SelectToken("lifestyle.dailyFruitsOrVegetables")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q2", data.SelectToken("lifestyle.milkCurdEggsWeekly")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q3", data.SelectToken("lifestyle.waterIntakeGlassesPerDay")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q4", data.SelectToken("lifestyle.frequentJunkFood")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q5", data.SelectToken("lifestyle.dailyExercise")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q6", data.SelectToken("lifestyle.toeTouch")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q7", data.SelectToken("lifestyle.pushUpsSitUps")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q8", data.SelectToken("lifestyle.jobSatisfaction")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q9", data.SelectToken("lifestyle.goodHomeSituation")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q10", data.SelectToken("lifestyle.majorProblems")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q11", data.SelectToken("lifestyle.sufficientSleep")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q12", data.SelectToken("lifestyle.alcoholConsumption")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q13", data.SelectToken("lifestyle.smoking")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q14", data.SelectToken("lifestyle.oralTobacco")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q15", data.SelectToken("lifestyle.safetyConsciousness")?.Value<string>() ?? "SAUDI")
            };


            var result = _service.CommonStoredProcedureMethod("usp_InsertPLS", parameters.ToArray());

            return Ok(result);
        }

        [HttpPost]
        [Route("insertPPS")]
        public IHttpActionResult InsertPPS([FromBody] JObject data)
        {
            if (data == null)
                return BadRequest("Invalid JSON");

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@regid", data.SelectToken("po.regid")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q1", data.SelectToken("po.Q1")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q2", data.SelectToken("po.Q2")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q3", data.SelectToken("po.Q3")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q4", data.SelectToken("po.Q4")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q5", data.SelectToken("po.Q5")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q6", data.SelectToken("po.Q6")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q1R", data.SelectToken("po.Q1R")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q2R", data.SelectToken("po.Q2R")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q3R", data.SelectToken("po.Q3R")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q4R", data.SelectToken("po.Q4R")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q5R", data.SelectToken("po.Q5R")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q6R", data.SelectToken("po.Q6R")?.Value<string>() ?? "SAUDI")
            };


            var result = _service.CommonStoredProcedureMethod("usp_InsertPPS", parameters.ToArray());

            return Ok(result);
        }

        [HttpPost]
        [Route("insertMT")]
        public IHttpActionResult InsertMT([FromBody] JObject data)
        {
            if (data == null)
                return BadRequest("Invalid JSON");

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@regid", data.SelectToken("po.regid")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q1", data.SelectToken("familyMedicalHistory.parentsOrGrandparentsBP_Sugar_Cardiac")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@QTC", data.SelectToken("familyMedicalHistory.totalCholesterol")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@QBP1", data.SelectToken("medicalDetails.bloodPressureSystolic")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@QBP2", data.SelectToken("medicalDetails.bloodPressureDiastolic")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@QBS1", data.SelectToken("medicalDetails.bloodSugarFasting")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@QBS2", data.SelectToken("medicalDetails.bloodSugarRandom")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q2", data.SelectToken("medicalDetails.currentMedication")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q2R", data.SelectToken("medicalDetails.medicationReason")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q1R", data.SelectToken("medicalDetails.familyMedicalReason")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q2Rs", data.SelectToken("medicalDetails.familyMedicalReason")?.Value<string>() ?? "SAUDI"),
            };


            var result = _service.CommonStoredProcedureMethod("usp_InsertMT", parameters.ToArray());

            return Ok(result);
        }

        private void CreateCorporate(JObject data)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@cname", data.SelectToken("personalInformation.corporateName")?.Value<string>() ?? ""),
                new SqlParameter("@cid", data.SelectToken("personalInformation.cid")?.Value<string>() ?? ""),
                new SqlParameter("@caddress", data.SelectToken("personalInformation.corporateAddress")?.Value<string>() ?? ""),
                new SqlParameter("@ccity", data.SelectToken("personalInformation.corporateCity")?.Value<string>() ?? ""),
                new SqlParameter("@cstate", data.SelectToken("personalInformation.corporateState")?.Value<string>() ?? ""),
                new SqlParameter("@cpin", data.SelectToken("personalInformation.corporatePin")?.Value<string>() ?? ""),
                new SqlParameter("@ccountry", data.SelectToken("personalInformation.corporateCountry")?.Value<string>() ?? ""),
                new SqlParameter("@cperson", data.SelectToken("personalInformation.corporateContactPerson")?.Value<string>() ?? ""),
                new SqlParameter("@cphone", data.SelectToken("personalInformation.corporatePhone")?.Value<string>() ?? ""),
                new SqlParameter("@cmobile", data.SelectToken("personalInformation.corporateMobile")?.Value<string>() ?? ""),
                new SqlParameter("@cemail", data.SelectToken("personalInformation.corporateEmail")?.Value<string>() ?? ""),
                new SqlParameter("@curl", data.SelectToken("personalInformation.corporateWebsite")?.Value<string>() ?? ""),
                new SqlParameter("@cscantype", data.SelectToken("personalInformation.corporateScanType")?.Value<string>() ?? ""),
                new SqlParameter("@cvaliddays", data.SelectToken("personalInformation.corporateDays")?.Value<int>() ?? 0),
                new SqlParameter("@cstatus", data.SelectToken("personalInformation.corporateStatus")?.Value<bool>() ?? false)
            };
            _service.CommonStoredProcedureMethod("usp_createCorporate", parameters.ToArray());
        }
        private void CreateBranch(JObject data)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@cid", data.SelectToken("personalInformation.cid")?.Value<string>() ?? ""),
                new SqlParameter("@bname", data.SelectToken("personalInformation.branchName")?.Value<string>() ?? ""),
                new SqlParameter("@baddress", data.SelectToken("personalInformation.branchAddress")?.Value<string>() ?? ""),
                new SqlParameter("@bcity", data.SelectToken("personalInformation.branchCity")?.Value<string>() ?? ""),
                new SqlParameter("@bstate", data.SelectToken("personalInformation.branchState")?.Value<string>() ?? ""),
                new SqlParameter("@bpin", data.SelectToken("personalInformation.branchPin")?.Value<string>() ?? ""),
                new SqlParameter("@bcountry", data.SelectToken("personalInformation.branchCountry")?.Value<string>() ?? ""),
                new SqlParameter("@bperson", data.SelectToken("personalInformation.branchPerson")?.Value<string>() ?? ""),
                new SqlParameter("@bphone", data.SelectToken("personalInformation.branchPhone")?.Value<string>() ?? ""),
                new SqlParameter("@bmobile", data.SelectToken("personalInformation.branchMobile")?.Value<string>() ?? ""),
                new SqlParameter("@bemail", data.SelectToken("personalInformation.branchEmail")?.Value<string>() ?? ""),
                new SqlParameter("@bscantype", data.SelectToken("personalInformation.branchScanType")?.Value<string>() ?? ""),
                new SqlParameter("@bvaliddays", data.SelectToken("personalInformation.branchDays")?.Value<int>() ?? 0),
                new SqlParameter("@bstatus", data.SelectToken("personalInformation.branchStatus")?.Value<bool>() ?? true),
                new SqlParameter("@bevent", data.SelectToken("personalInformation.branchEventType")?.Value<string>() ?? ""),
                new SqlParameter("@beventdate", data.SelectToken("personalInformation.branchEventDate")?.Value<string>() ?? "")
            };
            _service.CommonStoredProcedureMethod("usp_createBranch", parameters.ToArray());
        }
        private IHttpActionResult RegisterUser(JObject data, string corporateId, string branchId, DateTime DobSample)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@cid", corporateId),
                //new SqlParameter("@bid", branchId),
                new SqlParameter("@bid", data.SelectToken("personalInformation.bid")?.Value<string>() ?? "BRA0002"),
                new SqlParameter("@fname", data.SelectToken("personalInformation.name")?.Value<string>() ?? ""),
                new SqlParameter("@lname", data.SelectToken("personalInformation.name")?.Value<string>() ?? ""),
                new SqlParameter("@rmobile", data.SelectToken("personalInformation.mobile")?.Value<string>() ?? ""),
                new SqlParameter("@rDOB", DobSample),
                new SqlParameter("@remail", data.SelectToken("personalInformation.email")?.Value<string>() ?? ""),
                new SqlParameter("@rextmobile", data.SelectToken("personalInformation.extmobile")?.Value<string>() ?? "+91"),
                new SqlParameter("@gender", data.SelectToken("personalInformation.gender")?.Value<bool>() ?? false),
                new SqlParameter("@empid", data.SelectToken("personalInformation.employeeId")?.Value<string>() ?? ""),
                new SqlParameter("@empidtype", data.SelectToken("personalInformation.empidtype")?.Value<int>() ?? 0),
                new SqlParameter("@usertype", data.SelectToken("personalInformation.usertype")?.Value<int>() ?? 0),
                new SqlParameter("@passw", data.SelectToken("personalInformation.passw")?.Value<string>() ?? ""),
                new SqlParameter("@deptid", data.SelectToken("personalInformation.deptid")?.Value<string>() ?? "DEP0010"),
                new SqlParameter("@desgid", data.SelectToken("personalInformation.desgid")?.Value<string>() ?? "DEG001000"),
                new SqlParameter("@descent", data.SelectToken("personalInformation.descent")?.Value<string>() ?? "INDIAN"),
                new SqlParameter("@httype", data.SelectToken("physicalTest.httype")?.Value<string>() ?? "C"),
                new SqlParameter("@htFt", data.SelectToken("physicalTest.height")?.Value<float>() ?? 0),
                new SqlParameter("@htIn", "0"),
                new SqlParameter("@wttype", data.SelectToken("physicalTest.weightType")?.Value<string>() ?? "K"),
                new SqlParameter("@wt", data.SelectToken("physicalTest.weight")?.Value<int>() ?? 0),
                new SqlParameter("@pulse", data.SelectToken("physicalTest.pulse")?.Value<int>() ?? 0),
                new SqlParameter("@peak", "0"),
                new SqlParameter("@waist", data.SelectToken("physicalTest.waist")?.Value<int>() ?? 0),
                new SqlParameter("@breath", data.SelectToken("physicalTest.breathRetention")?.Value<int>() ?? 0),
                new SqlParameter("@temp", "0"),
                new SqlParameter("@spo", "0"),
                new SqlParameter("@lq1", data.SelectToken("lifestyle.dailyFruitsOrVegetables")?.Value<int>() ?? 0),
                new SqlParameter("@lq2", data.SelectToken("lifestyle.milkCurdEggsWeekly")?.Value<int>() ?? 0),
                new SqlParameter("@lq3", data.SelectToken("lifestyle.waterIntakeGlassesPerDay")?.Value<int>() ?? 0),
                new SqlParameter("@lq4", data.SelectToken("lifestyle.frequentJunkFood")?.Value<int>() ?? 0),
                new SqlParameter("@lq5", data.SelectToken("lifestyle.dailyExercise")?.Value<int>() ?? 0),
                new SqlParameter("@lq6", data.SelectToken("lifestyle.toeTouch")?.Value<int>() ?? 0),
                new SqlParameter("@lq7", data.SelectToken("lifestyle.pushUpsSitUps")?.Value<int>() ?? 0),
                new SqlParameter("@lq8", data.SelectToken("lifestyle.jobSatisfaction")?.Value<int>() ?? 0),
                new SqlParameter("@lq9", data.SelectToken("lifestyle.goodHomeSituation")?.Value<int>() ?? 0),
                new SqlParameter("@lq10", data.SelectToken("lifestyle.majorProblems")?.Value<int>() ?? 0),
                new SqlParameter("@lq11", data.SelectToken("lifestyle.sufficientSleep")?.Value<int>() ?? 0),
                new SqlParameter("@lq12", "0"),
                new SqlParameter("@lq13", data.SelectToken("lifestyle.smoking")?.Value<int>() ?? 0),
                new SqlParameter("@lq14", data.SelectToken("lifestyle.oralTobacco")?.Value<int>() ?? 0),
                new SqlParameter("@lq15", "0"),
                new SqlParameter("@llq1", data.SelectToken("lifestyle.meatChickenFishWeekly")?.Value<int>() ?? 0),
                new SqlParameter("@llq2", data.SelectToken("lifestyle.cerealsWeekly")?.Value<int>() ?? 0),
                new SqlParameter("@llq3", data.SelectToken("lifestyle.mineralVitaminSupplements")?.Value<int>() ?? 0),
                new SqlParameter("@llq4", data.SelectToken("mental.nervous")?.Value<int>() ?? 0),
                new SqlParameter("@llq5", data.SelectToken("mental.worrying")?.Value<int>() ?? 0),
                new SqlParameter("@llq6", data.SelectToken("mental.intrest")?.Value<int>() ?? 0),
                new SqlParameter("@llq7", data.SelectToken("mental.feeling")?.Value<int>() ?? 0),
                new SqlParameter("@mq1", data.SelectToken("familyMedicalHistory.parentsOrGrandparentsBP_Sugar_Cardiac")?.Value<int>() ?? 0),
                new SqlParameter("@mq2", data.SelectToken("medicalDetails.currentMedication")?.Value<int>() ?? 0),
                new SqlParameter("@mq1r", data.SelectToken("familyMedicalHistory.familyMedicalReason")?.Value<string>() ?? ""),
                new SqlParameter("@mq2r", data.SelectToken("medicalDetails.medicationReason")?.Value<int>() ?? 0),
                new SqlParameter("@mq2rs", data.SelectToken("medicalDetails.medicationReason2")?.Value<string>() ?? ""),
                new SqlParameter("@mqbp1", data.SelectToken("medicalDetails.bloodPressureSystolic")?.Value<int>() ?? 0),
                new SqlParameter("@mqbp2", data.SelectToken("medicalDetails.bloodPressureDiastolic")?.Value<int>() ?? 0),
                new SqlParameter("@mqbs1", data.SelectToken("medicalDetails.bloodSugarFasting")?.Value<int>() ?? 0),
                new SqlParameter("@mqbs2", data.SelectToken("medicalDetails.bloodSugarRandom")?.Value<int>() ?? 0),
                new SqlParameter("@mqtc", data.SelectToken("medicalDetails.totalCholesterol")?.Value<int>() ?? 0),
                new SqlParameter("@q1", data.SelectToken("medicalDetails.headache")?.Value<int>() ?? 0),
                new SqlParameter("@q2", data.SelectToken("medicalDetails.respiratoryAilments")?.Value<int>() ?? 0),
                new SqlParameter("@q3", "0"),
                new SqlParameter("@q4", data.SelectToken("medicalDetails.musculoskeletalProblems")?.Value<int>() ?? 0),
                new SqlParameter("@q5", "0"),
                new SqlParameter("@q6", "0"),
                new SqlParameter("@q1r", data.SelectToken("medicalDetails.headacheReason")?.Value<string>() ?? ""),
                new SqlParameter("@q2r", data.SelectToken("medicalDetails.respiratoryAilmentsReason")?.Value<string>() ?? ""),
                new SqlParameter("@q3r", ""),
                new SqlParameter("@q4r", data.SelectToken("medicalDetails.musculoskeletalProblemsReason")?.Value<string>() ?? ""),
                new SqlParameter("@q5r", ""),
                new SqlParameter("@q6r", ""),
                new SqlParameter("@cq1", data.SelectToken("organization.insuranceProvided")?.Value<int>() ?? 0),
                new SqlParameter("@cq2", data.SelectToken("organization.annualHealthScreening")?.Value<int>() ?? 0),
                new SqlParameter("@cq3", data.SelectToken("organization.healthyCanteen")?.Value<int>() ?? 0),
                new SqlParameter("@cq4", data.SelectToken("organization.sportsFacility")?.Value<int>() ?? 0),
                new SqlParameter("@cq5", data.SelectToken("organization.healthEducation")?.Value<int>() ?? 0)
            };

            var result = _service.CommonStoredProcedureMethod("usp_registeruserAPITemp", parameters.ToArray());
            return Ok(result);
        }
    }
}