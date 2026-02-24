using EPiServer.Data;
using EPiServer.Data.Dynamic;

public interface ILastSyncRepository
{
    DateTime? GetLastSyncDate(string key);
    void SaveLastSyncDate(string key, DateTime date);
}

[EPiServerDataStore(AutomaticallyCreateStore = true, AutomaticallyRemapStore = true)]
public class SyncStateRecord : IDynamicData
{
    public Identity Id { get; set; }
    public string Key { get; set; }
    public DateTime LastSyncDate { get; set; }
}

public class LastSyncRepository : ILastSyncRepository
{
    private readonly DynamicDataStoreFactory _dataStoreFactory;

    public LastSyncRepository(DynamicDataStoreFactory dataStoreFactory)
    {
        _dataStoreFactory = dataStoreFactory;
    }

    public DateTime? GetLastSyncDate(string key)
    {
        var store = _dataStoreFactory.GetStore(typeof(SyncStateRecord));
        var record = store.Find<SyncStateRecord>("Key", key).FirstOrDefault();
        return record?.LastSyncDate;
    }

    public void SaveLastSyncDate(string key, DateTime date)
    {
        var store = _dataStoreFactory.GetStore(typeof(SyncStateRecord));
        var record = store.Find<SyncStateRecord>("Key", key).FirstOrDefault();

        if (record == null)
        {
            record = new SyncStateRecord { Key = key, LastSyncDate = date };
            store.Save(record);
        }
        else
        {
            record.LastSyncDate = date;
            store.Save(record);
        }
    }
}