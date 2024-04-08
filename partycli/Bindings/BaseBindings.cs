using PersistentData;
using PersistentData.Bindings;
using Services.Bindings;
using Unity;

namespace partycli.Bindings
{
    public class BaseBindings
    {
        public static UnityContainer GetUnityContainer()
        {
            var container = new UnityContainer();

            PersistentDataBindings.Add(container);
            ServicesBindings.Add(container);

            return container;
        }
    }
}