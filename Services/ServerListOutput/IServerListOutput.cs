using Models.Models;
using System.Collections.Generic;

namespace Services.ServerListOutput
{
    public interface IServerListOutput
    {
        void DisplayServerList(IEnumerable<ServerModel> servers);
    }
}