using Models.Enums;
using Models.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.IO;

namespace PersistentData.ParameterDefinitionsConfiguration
{
    public class HtmlParametersDefinitions
    {
        public static HtmlParametersDefinitions Instance => new HtmlParametersDefinitions();

        private Dictionary<string, string> htmlParameterDedinitions;

        public string this[string key] => htmlParameterDedinitions.FirstOrDefault(x => x.Key == key).Value;

        public IReadOnlyDictionary<string, string> HtmlParameterDefinitionList => htmlParameterDedinitions;
        private HtmlParametersDefinitions()
        {
            LoadParameters();
        }

        private void LoadParameters()
        {
            var reader = new StreamReader("htmlParameterDefinitions.json");
            htmlParameterDedinitions = JsonConvert.DeserializeObject<Dictionary<string, string>>(reader.ReadToEnd());
            reader.Close();
        }
    }
}