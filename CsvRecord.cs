namespace SunamoCsv;

/// <summary>
/// Csv record class
/// </summary>
[Serializable]
public sealed class CsvRecord
{
    #region Properties

    /// <summary>
    /// Gets the Fields in the record
    /// </summary>
    public readonly List<string> Fields = new List<string>();

    /// <summary>
    /// Gets the number of fields in the record
    /// </summary>
    public int FieldCount
    {
        get
        {
            return Fields.Count;
        }
    }

    #endregion Properties
}
