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