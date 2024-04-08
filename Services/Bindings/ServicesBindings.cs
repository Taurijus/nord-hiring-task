using Services.ServerList;
using Services.ServerListOutput;
using Unity;

namespace Services.Bindings
{
    public class ServicesBindings
    {
        public static void Add(UnityContainer container)
        {
            container.RegisterType<IServerList, NordVpnServerList>();
            container.RegisterType<IServerListOutput, MonoChromeConsoleDisplay>();
        }
    }
}