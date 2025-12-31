namespace SunamoCsv;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
/// <summary>
///     Class to hold csv data
///     Downloaded from http://www.codeproject.com/Articles/86973/C-CSV-Reader-and-Writer
/// </summary>
public sealed partial class CsvFile
{
    /// <summary>
    ///     Populates the current instance from a stream
    /// </summary>
    /// <param name = "stream">Stream</param>
    /// <param name = "encoding">Encoding</param>
    /// <param name = "hasHeaderRow">True if the file has a header row, otherwise false</param>
    /// <param name = "isTrimmingColumns">True if column values should be trimmed, otherwise false</param>
    public void Populate(Stream stream, Encoding encoding, bool hasHeaderRow, bool isTrimmingColumns)
    {
        using (var reader = new SunamoCsvReader(stream, encoding)
        {
            HasHeaderRow = hasHeaderRow,
            TrimColumns = isTrimmingColumns
        }

        )
        {
            PopulateCsvFile(reader);
        }
    }

    /// <summary>
    ///     Populates the current instance from a string
    /// </summary>
    /// <param name = "hasHeaderRow">True if the file has a header row, otherwise false</param>
    /// <param name = "csvContent">Csv text</param>
    public void Populate(bool hasHeaderRow, string csvContent)
    {
        Populate(hasHeaderRow, csvContent, null, false);
    }

    /// <summary>
    ///     Populates the current instance from a string
    /// </summary>
    /// <param name = "hasHeaderRow">True if the file has a header row, otherwise false</param>
    /// <param name = "csvContent">Csv text</param>
    /// <param name = "isTrimmingColumns">True if column values should be trimmed, otherwise false</param>
    public void Populate(bool hasHeaderRow, string csvContent, bool isTrimmingColumns)
    {
        Populate(hasHeaderRow, csvContent, null, isTrimmingColumns);
    }

    /// <summary>
    ///     Populates the current instance from a string
    /// </summary>
    /// <param name = "hasHeaderRow">True if the file has a header row, otherwise false</param>
    /// <param name = "csvContent">Csv text</param>
    /// <param name = "encoding">Encoding</param>
    /// <param name = "isTrimmingColumns">True if column values should be trimmed, otherwise false</param>
    public void Populate(bool hasHeaderRow, string csvContent, Encoding encoding, bool isTrimmingColumns)
    {
        using (var reader = new SunamoCsvReader(encoding, csvContent)
        {
            HasHeaderRow = hasHeaderRow,
            TrimColumns = isTrimmingColumns
        }

        )
        {
            PopulateCsvFile(reader);
        }
    }

    /// <summary>
    ///     Populates the current instance using the CsvReader object
    /// </summary>
    /// <param name = "reader">CsvReader</param>
    private void PopulateCsvFile(SunamoCsvReader reader)
    {
        Headers.Clear();
        Records.Clear();
        var addedHeader = false;
        while (reader.ReadNextRecord())
        {
            if (reader.HasHeaderRow && !addedHeader)
            {
                reader.Fields.ForEach(field => Headers.Add(field));
                addedHeader = true;
                continue;
            }

            var record = new CsvRecord();
            reader.Fields.ForEach(field => record.Fields.Add(field));
            Records.Add(record);
        }
    }
}