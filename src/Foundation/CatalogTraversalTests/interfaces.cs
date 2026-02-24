using System.Threading;


/// <summary>
/// Marker interface for items returned during catalog traversal.
/// Products and variants from your catalog should implement this interface.
/// </summary>
public interface ICatalogTraversalItem
{
    DateTime? LastUpdated { get; set; }
}

/// <summary>
/// Options for controlling catalog traversal behavior.
/// </summary>
public class CatalogTraversalOptions
{
    /// <summary>
    /// Optional: Name of the catalog to traverse. If null, all catalogs are processed.
    /// </summary>
    public string? CatalogName { get; set; }

    /// <summary>
    /// Optional: Specific catalog content reference to traverse. Takes priority over CatalogName.
    /// </summary>
    public ContentReference? CatalogLink { get; set; }

    /// <summary>
    /// Optional: Only return items updated after this date. Useful for incremental syncs.
    /// </summary>
    public DateTime? LastUpdated { get; set; }
}

/// <summary>
/// Service for traversing Optimizely Commerce catalog hierarchies.
/// </summary>
public interface ICatalogTraversalService
{
    /// <summary>
    /// Traverses the catalog hierarchy and returns matching products and variants as a stream.
    /// Items are yielded one at a time for memory-efficient processing.
    /// </summary>
    IEnumerable<ICatalogTraversalItem> GetAllProducts(
        CatalogTraversalOptions options,
        CancellationToken cancellationToken = default);
}