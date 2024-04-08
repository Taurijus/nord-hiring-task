namespace PersistentData
{
    public interface IDataStorage
    {
        void Add(string id, string value);
        void StoreServerList(string value);
        string GetServerList();
    }
}