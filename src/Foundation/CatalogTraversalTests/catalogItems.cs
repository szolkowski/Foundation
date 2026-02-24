public class MyGenericProduct : ProductContent, ICatalogTraversalItem
{
    public virtual DateTime? LastUpdated { get; set; }
    // ... other properties
}

public class MyGenericVariant : VariationContent, ICatalogTraversalItem
{
    public virtual DateTime? LastUpdated { get; set; }
    // ... other properties
}