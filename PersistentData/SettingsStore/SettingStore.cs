using System;
using System.Xml.Linq;
using Serilog;

namespace PersistentData.SettingsStore
{
    public class SettingStore : IDataStorage
    {
        private const string SERVER_LIST = "serverlist";

        public void StoreServerList(string value) => Add(SERVER_LIST, value);

        public string GetServerList() => Properties.Settings.Default.serverlist;

        public void Add(string id, string value)
        {
            try
            {
                var settings = Properties.Settings.Default;
                settings[id] = value;
                settings.Save();
                Log.Information($"Saved new data to {id}");
                Log.Debug($"Save {value} to {id} field");
            }
            catch
            {
                Log.Error("Error: Couldn't save " + id + ". Check if command was input correctly.");
            }
        }
    }
}