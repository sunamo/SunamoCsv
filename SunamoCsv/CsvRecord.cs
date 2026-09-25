namespace SunamoCsv;

/// <summary>
///     Represents a single record (row) in a CSV file
/// </summary>
public sealed class CsvRecord
{
    #region Properties

    /// <summary>
    ///     Gets the Fields in the record
    /// </summary>
    public readonly List<string> Fields = new();

    /// <summary>
    ///     Gets the number of fields in the record
    /// </summary>
    public int FieldCount => Fields.Count;

    #endregion Properties
}