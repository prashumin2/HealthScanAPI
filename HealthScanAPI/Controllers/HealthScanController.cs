using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace HealthScanAPI.Controllers
{
    [RoutePrefix("api/HealthScan")]

    public class HealthScanController : ApiController
    {
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


            var result = CommonStoredProcedureMethod("usp_registeruserAPI", parameters.ToArray());

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
                new SqlParameter("@spo", data.SelectToken("physicalTest.spo")?.Value<string>() ?? "")
            };


            var result = CommonStoredProcedureMethod("usp_registerScan", parameters.ToArray());

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


            var result = CommonStoredProcedureMethod("usp_InsertPO", parameters.ToArray());

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


            var result = CommonStoredProcedureMethod("usp_InsertPLS", parameters.ToArray());

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


            var result = CommonStoredProcedureMethod("usp_InsertPPS", parameters.ToArray());

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


            var result = CommonStoredProcedureMethod("usp_InsertMT", parameters.ToArray());

            return Ok(result);
        }

        private object CommonStoredProcedureMethod(string spName, params SqlParameter[] parameters)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["HealthScanDB"].ConnectionString;
            var dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(spName, con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                con.Open();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }
    }
}