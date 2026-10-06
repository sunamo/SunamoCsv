namespace SunamoCsv;

public sealed class CsvRecord
{
    #region Properties

    public readonly List<string> Fields = new();

    public int FieldCount => Fields.Count;

    #endregion Properties
}
