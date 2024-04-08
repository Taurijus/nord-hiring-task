using System.Threading.Tasks;
using Models.Queries;

namespace Services.ServerList
{
    public interface IServerList
    {
        Task<string> Get(VpnServerQuery query);
    }
}