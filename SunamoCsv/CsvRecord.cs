namespace SunamoCsv;

/// <summary>
///     Csv record class
/// </summary>
[Serializable]
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