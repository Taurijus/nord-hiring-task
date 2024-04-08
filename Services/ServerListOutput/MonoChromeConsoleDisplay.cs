using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Models.Models;
using Services.ServerList;

namespace Services.ServerListOutput
{
    public class MonoChromeConsoleDisplay : IServerListOutput
    {
        public void DisplayServerList(IEnumerable<ServerModel> servers)
        {
            if (servers == null)
            {
                Console.WriteLine("No servers found.");
                return;
            } 
            var list = servers.ToList();

            Console.WriteLine("Server list: ");
            foreach (var server in list)
            {
                Console.WriteLine("Name: " + server.Name);
            }
            Console.WriteLine("Total servers: " + list.Count);
        }
    }
}