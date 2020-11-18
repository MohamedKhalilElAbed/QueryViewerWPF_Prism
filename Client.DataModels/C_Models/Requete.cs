using System;
using System.Collections.Generic;
using System.Text;

namespace Client.DataModels.C_Models
{
    public class Requete
    {
        public Requete(string name, string connectionString, bool isScript, string[] colNames, string script)
        {
            Name = name;
            ConnectionString = connectionString;
            IsScript = isScript;
            ColNames = colNames;
            Script = script;
        }

        public string Name { get; set; }

        public string ConnectionString { get; set; }

        public bool IsScript { get; set; }

        public string[] ColNames { get; set; }

        public string Script { get; set; }
        public string Description { get { return "Schema : " + ConnectionString + "\nScript : " + Script; } }

    }
}
