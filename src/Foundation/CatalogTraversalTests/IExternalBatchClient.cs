public interface IExternalBatchClient
{
    void ExportBatch(List<ICatalogTraversalItem> batch);

    void ExportSingle(ICatalogTraversalItem item);

}

public class ExternalBatchClient : IExternalBatchClient
{
    public void ExportBatch(List<ICatalogTraversalItem> batch)
    {
       // throw new NotImplementedException();
    }


    public void ExportSingle(ICatalogTraversalItem item)
    {
       // throw new NotImplementedException();
    }
}