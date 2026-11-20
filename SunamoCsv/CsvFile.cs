namespace SunamoCsv;

// Class to hold csv data
// Downloaded from http://www.codeproject.com/Articles/86973/C-CSV-Reader-and-Writer
/// <summary>
/// Represents the csv file type.
/// </summary>
public sealed partial class CsvFile
{
    /// <summary>
    /// Initializes a new instance of the csv file class.
    /// </summary>
    public CsvFile()
    {
    }

    /// <summary>
    /// Initializes a new instance of the csv file class.
    /// </summary>
    /// <param name="delimiter">The delimiter.</param>
    public CsvFile(char delimiter)
    {
        SunamoCsvReader.Delimiter = delimiter;
    }

    /// <summary>
    /// The headers.
    /// </summary>
    public readonly List<string> Headers = new();
    /// <summary>
    /// The records.
    /// </summary>
    public readonly CsvRecords Records = new();
    /// <summary>
    /// Gets the header count.
    /// </summary>
    public int HeaderCount => Headers.Count;

    /// <summary>
    /// Strings.
    /// </summary>
    /// <returns>The strings result.</returns>
    public List<string> Strings(int columnIndex)
    {
        var list = new List<string>();
        var objects = Objects(columnIndex);
        foreach (var item in objects)
            list.Add(item[0]);
        return list;
    }

    // Return null when cannot be parsed
    /// <summary>
    /// Date times.
    /// </summary>
    /// <typeparam name="string">The type string.</typeparam>
    /// <returns>The date times result.</returns>
    public List<DateTime?> DateTimes(int columnIndex)
    {
        DateTime dateTime;
        var list = new List<DateTime?>();
        var objects = Objects(columnIndex);
        foreach (var item in objects)
        {
            dateTime = DateTime.Parse(item[0]); //DTHelperCs.ParseTimeCzech(item[0]);
            if (dateTime != DateTime.MinValue)
                list.Add(new DateTime(1, 1, 1, dateTime.Hour, dateTime.Minute, dateTime.Second));
            else
                list.Add(null);
        }

        return list;
    }

    /// <summary>
    /// Initializes a new instance of the objects class.
    /// </summary>
    /// <param name="!">The !.</param>
    public List<List<string>> Objects(params int[] columns)
    {
        var result = new List<List<string>>();
        var i = 0;
        List<string>? row = null;
        foreach (var item in Records)
        {
            row = new List<string>(columns.Length);
            ////CA.InitFillWith(row, columns.Length);
            for (i = 0; i < columns.Length; i++)
                row.Add(item.Fields[columns[i]]);
            result.Add(row);
        }

        return result;
    }

    /// <summary>
    /// Gets the record count.
    /// </summary>
    public int RecordCount => Records.Count;

    /// <summary>
    /// The this int.
    /// </summary>
    public CsvRecord this[int recordIndex]
    {
        get
        {
            if (recordIndex > Records.Count - 1)
                throw new Exception($"There is no record at index {recordIndex}.");
            return Records[recordIndex];
        }
    }

    /// <summary>
    /// The this int int.
    /// </summary>
    public string this[int recordIndex, int fieldIndex]
    {
        get
        {
            if (recordIndex > Records.Count - 1)
                throw new Exception($"There is no record at index {recordIndex}.");
            var record = Records[recordIndex];
            if (fieldIndex > record.Fields.Count - 1)
                throw new Exception($"There is no field at index {fieldIndex} in record {recordIndex}.");
            return record.Fields[fieldIndex];
        }

        set
        {
            if (recordIndex > Records.Count - 1)
                throw new Exception($"There is no record at index {recordIndex}.");
            var record = Records[recordIndex];
            if (fieldIndex > record.Fields.Count - 1)
                throw new Exception($"There is no field at index {fieldIndex}.");
            record.Fields[fieldIndex] = value;
        }
    }

    /// <summary>
    /// The this int string.
    /// </summary>
    public string this[int recordIndex, string fieldName]
    {
        get
        {
            if (recordIndex > Records.Count - 1)
                throw new Exception($"There is no record at index {recordIndex}.");
            var record = Records[recordIndex];
            var fieldIndex = -1;
            for (var i = 0; i < Headers.Count; i++)
            {
                if (string.Compare(Headers[i], fieldName) != 0)
                    continue;
                fieldIndex = i;
                break;
            }

            if (fieldIndex == -1)
                throw new Exception($"There is no field header with the name '{fieldName}'");
            if (fieldIndex > record.Fields.Count - 1)
                throw new Exception($"There is no field at index {fieldIndex} in record {recordIndex}.");
            return record.Fields[fieldIndex];
        }

        set
        {
            if (recordIndex > Records.Count - 1)
                throw new Exception($"There is no record at index {recordIndex}.");
            var record = Records[recordIndex];
            var fieldIndex = -1;
            for (var i = 0; i < Headers.Count; i++)
            {
                if (string.Compare(Headers[i], fieldName) != 0)
                    continue;
                fieldIndex = i;
                break;
            }

            if (fieldIndex == -1)
                throw new Exception($"There is no field header with the name '{fieldName}'");
            if (fieldIndex > record.Fields.Count - 1)
                throw new Exception($"There is no field at index {fieldIndex} in record {recordIndex}.");
            record.Fields[fieldIndex] = value;
        }
    }

    /// <summary>
    /// Populate.
    /// </summary>
    /// <param name="1">The 1.</param>
    /// <returns>The populate result.</returns>
    public void Populate(string filePath, bool hasHeaderRow)
    {
        Populate(filePath, (Encoding?)null, hasHeaderRow, false);
    }

    /// <summary>
    /// Initializes a new instance of the populate class.
    /// </summary>
    /// <param name="i">The i.</param>
    public void Populate(string filePath, bool hasHeaderRow, bool isTrimmingColumns)
    {
        Populate(filePath, (Encoding?)null, hasHeaderRow, isTrimmingColumns);
    }

    /// <summary>
    /// Populate.
    /// </summary>
    /// <param name="fieldIndex">The field index.</param>
    /// <returns>The populate result.</returns>
    public void Populate(string filePath, Encoding? encoding, bool hasHeaderRow, bool isTrimmingColumns)
    {
        using (var reader = new SunamoCsvReader(filePath, encoding)
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
    /// Populate.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="hasHeaderRow">The has header row.</param>
    /// <param name="isTrimmingColumns">The is trimming columns.</param>
    /// <returns>The populate result.</returns>
    public void Populate(Stream stream, bool hasHeaderRow)
    {
        Populate(stream, (Encoding?)null, hasHeaderRow, false);
    }

    /// <summary>
    /// Populate.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="encoding">The encoding.</param>
    /// <param name="hasHeaderRow">The has header row.</param>
    /// <param name="isTrimmingColumns">The is trimming columns.</param>
    /// <returns>The populate result.</returns>
    public void Populate(Stream stream, bool hasHeaderRow, bool isTrimmingColumns)
    {
        Populate(stream, (Encoding?)null, hasHeaderRow, isTrimmingColumns);
    }
}
