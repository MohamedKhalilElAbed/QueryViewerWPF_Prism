using Client.Services.Api;
using Client.DataModels.C_Models;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using Prism.Ioc;

namespace Client.Services.Impl
{
    public class ConfigurationService : IConfigurationService
    {
        private static Dictionary<string, Requete> Requetes;
        private static IContainerProvider _containerProvider;
        private static ConfigurationService Instance;
        private ConfigurationService _configurationService;

        public ConfigurationService()
        {
            LoadConfiguration();
        }

        public static IConfigurationService GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ConfigurationService();
            }
            return Instance;
        } 
        public Dictionary<string, Requete> GetRequetes()
        {
            return Requetes;
        }

        private static void LoadConfiguration()
        {

            using (StreamReader r = new StreamReader(ConfigurationManager.AppSettings.Get("RequestConfigFile")))
            {
                string jsonContent = r.ReadToEnd();
                JsonSerializerOptions option = new JsonSerializerOptions();
                //option.
                Requetes = new Dictionary<string, Requete>();
                dynamic jsonConfig = JValue.Parse(jsonContent);// JsonSerializer.Deserialize<Dictionary<string, dynamic>>(jsonContent, JsonSerializerOptions)["Requetes"];
                //dynamic jsonConfig = System.Web.Helpers.Json.Decode(jsonContent);
                for (int i = 0; i < jsonConfig.Requetes.Count; ++i)
                {
                    var query = jsonConfig.Requetes[i];
                    //Console.WriteLine(query["Description"]);
                    Requetes.Add(query.Description.Value, 
                        new Requete(query.Description.Value, 
                                    query.ConnectionString.Value,
                                    query.IsScript.Value,
                                    null, 
                                    query.Script.Value)); ;
                }
                // For that you will need to add reference to System.Xml and System.Xml.Linq

            }
        }
        private static void LoadConfigurationV0()
        {
            var connectionStrings = ConfigurationManager.ConnectionStrings;

            Requetes = new Dictionary<string, Requete>();

            using (TextFieldParser parser = new TextFieldParser(ConfigurationManager.AppSettings.Get("RequestConfigFile")))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters("|");
                //parser.
                parser.ReadFields();
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] query = parser.ReadFields();
                    Requetes.Add(query[0], new Requete(query[0],
                    connectionStrings[query[1]].ConnectionString,
                    query[2] == "0",
                    query[3] == "" ? null : query[3].Split(','),
                    query[4]));
                }
            }
        }
    }
}
