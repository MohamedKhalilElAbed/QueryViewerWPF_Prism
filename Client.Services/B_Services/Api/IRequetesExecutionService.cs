using Client.DataModels.C_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Services.Api
{
    public interface IRequetesExecutionService
    {
        IEnumerable<IDictionary<string, object>> ExecuteRequete(Requete requete);
    }
}
