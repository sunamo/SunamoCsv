namespace SunamoCsv;

/// <summary>
/// Represents the csv record type.
/// </summary>
public sealed class CsvRecord
{
    #region Properties

    /// <summary>
    /// The fields.
    /// </summary>
    public readonly List<string> Fields = new();

    /// <summary>
    /// Gets the field count.
    /// </summary>
    public int FieldCount => Fields.Count;

    #endregion Properties
}
