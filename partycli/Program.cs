using System;
using partycli.Bindings;
using Serilog;
using Unity;

namespace partycli
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
#if DEBUG
                .MinimumLevel.Verbose()
#endif
                .WriteTo.Console()
                .WriteTo.File("logs/partycli.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            var container = BaseBindings.GetUnityContainer();
            var cli = container.Resolve<Cli>();
            cli.Run(args);
            Console.Read();
        }
    }
}
