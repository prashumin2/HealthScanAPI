using HealthScanAPI.Models.DatabaseModels;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace HealthScanAPI.Services
{
    public class HealthScanApiService
    {
        public object CommonStoredProcedureMethod(string spName, params SqlParameter[] parameters)
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

        public List<string> CheckCorporateIdPresent(string corporateId)
        {
            using (var context = new HealthScanDBContext())
            {
                return context.Corporates.Where(x => x.CorporateId == corporateId).Select(x => x.CorporateId).ToList();
            }
        }
        public List<string> CheckBranchIdPresent(string branchId)
        {
            using (var context = new HealthScanDBContext())
            {
                return context.Branches.Where(x => x.BranchId == branchId).Select(x => x.BranchId).ToList();
            }
        }
    }
}