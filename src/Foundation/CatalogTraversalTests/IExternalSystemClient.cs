public interface IExternalSystemClient
{
    void ExportProduct(ProductContent product);
    void ExportVariant(VariationContent variant);
    void SyncProduct(ProductContent product);
    void SyncVariant(VariationContent variant);
}

public class ExternalSystemClient : IExternalSystemClient
{
    public void ExportProduct(ProductContent product)
    {
      //  throw new NotImplementedException();
    }


    public void ExportVariant(VariationContent variant)
    {
        //throw new NotImplementedException();
    }


    public void SyncProduct(ProductContent product)
    {
       //throw new NotImplementedException();
    }


    public void SyncVariant(VariationContent variant)
    {
       // throw new NotImplementedException();
    }

}