using Client.DataModels.C_Models;
using Client.Services.Api;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Client.Services.Impl
{
    public class RequetesExecutionService : IRequetesExecutionService
    {

        private static RequetesExecutionService Instance;
        private RequetesExecutionService()
        {
        }

        public static IRequetesExecutionService GetInstance()
        {
            if (Instance == null)
                Instance = new RequetesExecutionService();
            return Instance;
        }
        public IEnumerable<IDictionary<string, object>> ExecuteRequete(Requete requete) {
            SqlDataAdapter adapter = new SqlDataAdapter();
            using (var cn = new System.Data.SqlClient.SqlConnection(requete.ConnectionString))
            {
                IEnumerable<IDictionary<string, object>> queryResult = (IEnumerable<IDictionary<string, object>>)cn.Query(requete.Script, null, null, true, null, requete.IsScript ? System.Data.CommandType.Text : System.Data.CommandType.StoredProcedure);
                return queryResult;
            }

        }
    }
}
