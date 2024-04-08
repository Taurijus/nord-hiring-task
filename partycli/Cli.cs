using Models.Models;
using Models.Queries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Services.ServerList;
using Services.ServerListOutput;
using PersistentData;
using PersistentData.ParameterDefinitionsConfiguration;
using Serilog;

namespace partycli
{
    public class Cli
    {
        private readonly IServerList serverList;
        private readonly IServerListOutput output;
        private readonly IDataStorage storage;

        public Cli(IServerList serverList, IServerListOutput serverListOutput, IDataStorage dataStorage)
        {
            this.serverList = serverList;
            output = serverListOutput;
            storage = dataStorage;
        }

        public void Run(string[] args)
        {
            if (args.Length == 0)
            {
                DisplayHelp();
                return;
            }
            switch (args[0].ToLower())
            {
                case "config":
                    Config(args);
                    break;
                case "server_list":
                    ListServersByParams(args); 
                    break;
                default:
                    DisplayHelp();
                    break;
            }
        }

        private void ListServersByParams(string[] args)
        {
            if (args.Length > 1 && args[1].ToLower() == "--local")
            {
                DisplayList(storage.GetServerList());
                return;
            }
            var query = new VpnServerQuery();

            // Supports multiple arguments, but server does not. Need documentation to finish this.
            // Might need refactoring depending on server capabilities. 
            foreach (var cmdLineParam in args.Skip(1))
            {
                var param = ParametersDefinitions.Instance[cmdLineParam.ToLower()];
                if (param == null)
                {
                    Log.Warning($"Unknown parameter: {cmdLineParam}. Skipping");
                    continue;
                }
                query.AddParameter(param);
            } 

            var servers = serverList.Get(query).Result;
            storage.StoreServerList(servers);
            
            DisplayList(servers);
        }

        private void Config(string[] args)
        {
            if (args.Length != 3)
            {
                DisplayHelp();
                return;
            }
            var id = args[1].ToLower().Replace("-", string.Empty);
            storage.Add(id, args[2]);
        }

        private void DisplayHelp()
        {
            Console.WriteLine("To get and save all servers, use command: partycli.exe server_list");
            Console.WriteLine("To get and save France servers, use command: partycli.exe server_list --france");
            Console.WriteLine("To get and save servers that support TCP protocol, use command: partycli.exe server_list --TCP");
            Console.WriteLine("To see saved list of servers, use command: partycli.exe server_list --local ");
        }

        private void DisplayList(string serverListString) => 
            output.DisplayServerList(JsonConvert.DeserializeObject<List<ServerModel>>(serverListString));
    }
}