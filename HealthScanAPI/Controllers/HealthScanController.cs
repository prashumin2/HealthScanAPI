using Newtonsoft.Json.Linq;
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

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@cid", data.SelectToken("personalInformation.cid")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@bid", data.SelectToken("personalInformation.bid")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@fname", data.SelectToken("personalInformation.name")?.Value<string>() ?? ""),
                new SqlParameter("@lname", data.SelectToken("personalInformation.lname")?.Value<string>() ?? ""),
                new SqlParameter("@rmobile", data.SelectToken("personalInformation.mobile")?.Value<string>() ?? ""),
                new SqlParameter("@rDOB", data.SelectToken("personalInformation.DOB")?.Value<string>() ?? ""),
                new SqlParameter("@remail", data.SelectToken("personalInformation.email")?.Value<string>() ?? ""),
                new SqlParameter("@rextmobile", data.SelectToken("personalInformation.mobile")?.Value<string>() ?? ""),
                new SqlParameter("@gender", data.SelectToken("personalInformation.gender")?.Value<string>() ?? ""),
                new SqlParameter("@empid", data.SelectToken("personalInformation.employeeId")?.Value<string>() ?? ""),
                new SqlParameter("@empidtype", data.SelectToken("personalInformation.empidtype")?.Value<string>() ?? ""),
                new SqlParameter("@usertype", data.SelectToken("personalInformation.usertype")?.Value<string>() ?? "")
            };


            var result = CommonStoredProcedureMethod("usp_registeruser", parameters.ToArray());

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
                new SqlParameter("@Q1", data.SelectToken("po.Q1")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q2", data.SelectToken("po.Q2")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q3", data.SelectToken("po.Q3")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q4", data.SelectToken("po.Q4")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q5", data.SelectToken("po.Q5")?.Value<string>() ?? "SAUDI")
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
                new SqlParameter("@Q1", data.SelectToken("po.Q1")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q2", data.SelectToken("po.Q2")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q3", data.SelectToken("po.Q3")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q4", data.SelectToken("po.Q4")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q5", data.SelectToken("po.Q5")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q6", data.SelectToken("po.Q6")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q7", data.SelectToken("po.Q7")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q8", data.SelectToken("po.Q8")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q9", data.SelectToken("po.Q9")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q10", data.SelectToken("po.Q10")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q11", data.SelectToken("po.Q11")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q12", data.SelectToken("po.Q12")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q13", data.SelectToken("po.Q13")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q14", data.SelectToken("po.Q14")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q15", data.SelectToken("po.Q15")?.Value<string>() ?? "SAUDI")
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
                new SqlParameter("@Q1", data.SelectToken("po.Q1")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@QTC", data.SelectToken("po.QTC")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@QBP1", data.SelectToken("po.QBP1")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@QBP2", data.SelectToken("po.QBP2")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@QBS1", data.SelectToken("po.QBS1")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@QBS2", data.SelectToken("po.QBS2")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q2", data.SelectToken("po.Q2")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q2R", data.SelectToken("po.Q2R")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q1R", data.SelectToken("po.Q1R")?.Value<string>() ?? "SAUDI"),
                new SqlParameter("@Q2Rs", data.SelectToken("po.Q2Rs")?.Value<string>() ?? "SAUDI"),
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