using PersistentData.SettingsStore;
using Unity;

namespace PersistentData.Bindings
{
    public class PersistentDataBindings
    {
        public static void Add(UnityContainer container)
        {
            container.RegisterType<IDataStorage, SettingStore>();
        }
    }
}