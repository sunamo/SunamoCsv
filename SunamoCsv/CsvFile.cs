namespace SunamoCsv;

/// <summary>
///     Class to hold csv data
///     Downloaded from http://www.codeproject.com/Articles/86973/C-CSV-Reader-and-Writer
/// </summary>
public sealed partial class CsvFile
{
    /// <summary>
    ///     Initializes a new instance of the CsvFile class
    /// </summary>
    public CsvFile()
    {
    }

    /// <summary>
    ///     Initializes a new instance of the CsvFile class with specified delimiter
    /// </summary>
    /// <param name="delimiter">Character to use as field delimiter</param>
    public CsvFile(char delimiter)
    {
        SunamoCsvReader.Delimiter = delimiter;
    }

    /// <summary>
    ///     Gets the file headers
    /// </summary>
    public readonly List<string> Headers = new();
    /// <summary>
    ///     Gets the records in the file
    /// </summary>
    public readonly CsvRecords Records = new();
    /// <summary>
    ///     Gets the header count
    /// </summary>
    public int HeaderCount => Headers.Count;

    /// <summary>
    ///     Returns string values from specified column
    /// </summary>
    /// <param name="columnIndex">Zero-based column index</param>
    /// <returns>List of string values from the column</returns>
    public List<string> Strings(int columnIndex)
    {
        var list = new List<string>();
        var objects = Objects(columnIndex);
        foreach (var item in objects)
            list.Add(item[0]);
        return list;
    }

    /// <summary>
    ///     Return null when cannot be parsed
    /// </summary>
    /// <param name = "columnIndex"></param>
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
    ///     Returns values from specified columns as list of lists
    /// </summary>
    /// <param name="columns">Array of zero-based column indices</param>
    /// <returns>List of lists containing values from specified columns</returns>
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
    ///     Gets the record count
    /// </summary>
    public int RecordCount => Records.Count;

    /// <summary>
    ///     Gets a record at the specified index
    /// </summary>
    /// <param name = "recordIndex">Record index</param>
    /// <returns>CsvRecord</returns>
    public CsvRecord this[int recordIndex]
    {
        get
        {
            if (recordIndex > Records.Count - 1)
                throw new Exception(string.Format("There is no record at index {0}.", recordIndex));
            return Records[recordIndex];
        }
    }

    /// <summary>
    ///     Gets the field value at the specified record and field index
    /// </summary>
    /// <param name = "recordIndex">Record index</param>
    /// <param name = "fieldIndex">Field index</param>
    public string this[int recordIndex, int fieldIndex]
    {
        get
        {
            if (recordIndex > Records.Count - 1)
                throw new Exception(string.Format("There is no record at index {0}.", recordIndex));
            var record = Records[recordIndex];
            if (fieldIndex > record.Fields.Count - 1)
                throw new Exception(string.Format("There is no field at index {0} in record {1}.", fieldIndex, recordIndex));
            return record.Fields[fieldIndex];
        }

        set
        {
            if (recordIndex > Records.Count - 1)
                throw new Exception(string.Format("There is no record at index {0}.", recordIndex));
            var record = Records[recordIndex];
            if (fieldIndex > record.Fields.Count - 1)
                throw new Exception(string.Format("There is no field at index {0}.", fieldIndex));
            record.Fields[fieldIndex] = value;
        }
    }

    /// <summary>
    ///     Gets the field value at the specified record index for the supplied field name
    /// </summary>
    /// <param name = "recordIndex">Record index</param>
    /// <param name = "fieldName">Field name</param>
    public string this[int recordIndex, string fieldName]
    {
        get
        {
            if (recordIndex > Records.Count - 1)
                throw new Exception(string.Format("There is no record at index {0}.", recordIndex));
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
                throw new Exception(string.Format("There is no field header with the name '{0}'", fieldName));
            if (fieldIndex > record.Fields.Count - 1)
                throw new Exception(string.Format("There is no field at index {0} in record {1}.", fieldIndex, recordIndex));
            return record.Fields[fieldIndex];
        }

        set
        {
            if (recordIndex > Records.Count - 1)
                throw new Exception(string.Format("There is no record at index {0}.", recordIndex));
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
                throw new Exception(string.Format("There is no field header with the name '{0}'", fieldName));
            if (fieldIndex > record.Fields.Count - 1)
                throw new Exception(string.Format("There is no field at index {0} in record {1}.", fieldIndex, recordIndex));
            record.Fields[fieldIndex] = value;
        }
    }

    /// <summary>
    ///     Populates the current instance from the specified file
    /// </summary>
    /// <param name = "filePath">File path</param>
    /// <param name = "hasHeaderRow">True if the file has a header row, otherwise false</param>
    public void Populate(string filePath, bool hasHeaderRow)
    {
        Populate(filePath, (Encoding?)null, hasHeaderRow, false);
    }

    /// <summary>
    ///     Populates the current instance from the specified file
    /// </summary>
    /// <param name = "filePath">File path</param>
    /// <param name = "hasHeaderRow">True if the file has a header row, otherwise false</param>
    /// <param name = "isTrimmingColumns">True if column values should be trimmed, otherwise false</param>
    public void Populate(string filePath, bool hasHeaderRow, bool isTrimmingColumns)
    {
        Populate(filePath, (Encoding?)null, hasHeaderRow, isTrimmingColumns);
    }

    /// <summary>
    ///     Populates the current instance from the specified file
    /// </summary>
    /// <param name = "filePath">File path</param>
    /// <param name = "encoding">Encoding (null for UTF8)</param>
    /// <param name = "hasHeaderRow">True if the file has a header row, otherwise false</param>
    /// <param name = "isTrimmingColumns">True if column values should be trimmed, otherwise false</param>
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
    ///     Populates the current instance from a stream
    /// </summary>
    /// <param name = "stream">Stream</param>
    /// <param name = "hasHeaderRow">True if the file has a header row, otherwise false</param>
    public void Populate(Stream stream, bool hasHeaderRow)
    {
        Populate(stream, (Encoding?)null, hasHeaderRow, false);
    }

    /// <summary>
    ///     Populates the current instance from a stream
    /// </summary>
    /// <param name = "stream">Stream</param>
    /// <param name = "hasHeaderRow">True if the file has a header row, otherwise false</param>
    /// <param name = "isTrimmingColumns">True if column values should be trimmed, otherwise false</param>
    public void Populate(Stream stream, bool hasHeaderRow, bool isTrimmingColumns)
    {
        Populate(stream, (Encoding?)null, hasHeaderRow, isTrimmingColumns);
    }
}