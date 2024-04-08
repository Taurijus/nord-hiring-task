using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Models.Models;
using Newtonsoft.Json;
using Serilog;

namespace PersistentData.ParameterDefinitionsConfiguration
{
    public class ParametersDefinitions
    {
        public static ParametersDefinitions Instance => new ParametersDefinitions();

        private List<VpnServerParameter> parameters;

        public VpnServerParameter this[string key] => parameters.FirstOrDefault(x => x.CmdLineParameter == key);

        public IReadOnlyList<VpnServerParameter> ParameterDefinitionList => parameters;

        private ParametersDefinitions()
        {
            LoadParameters();
        }

        private void LoadParameters()
        {
            StreamReader reader = null;
            try
            {
                // this could be file per parameter type to be fair. 
                reader = new StreamReader("parameterDefinitions.json");
                parameters = JsonConvert.DeserializeObject<List<VpnServerParameter>>(reader.ReadToEnd());
                Log.Information("Parameter definitions loaded");
            }
            catch (Exception ex)
            {
                Log.Error($"Error loading parameters {ex}");
            }
            finally
            {
                reader?.Close();
            }
        }
    }
}