// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCsv;
/// <summary>
///     Class to hold csv data
///     Downloaded from http://www.codeproject.com/Articles/86973/C-CSV-Reader-and-Writer
/// </summary>
public sealed partial class CsvFile
{
    private static Type type = typeof(CsvFile);
    public CsvFile()
    {
    }

    public CsvFile(char delimiter)
    {
        SunamoCsvReader.delimiter = delimiter;
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

    public List<string> Strings(int v)
    {
        var list = new List<string>();
        var objects = Objects(v);
        foreach (var item in objects)
            list.Add(item[0]);
        return list;
    }

    /// <summary>
    ///     Return null when cannot be parsed
    /// </summary>
    /// <param name = "v"></param>
    public List<DateTime?> DateTimes(int v)
    {
        DateTime dt;
        var list = new List<DateTime?>();
        var objects = Objects(v);
        foreach (var item in objects)
        {
            dt = DateTime.Parse(item[0]); //DTHelperCs.ParseTimeCzech(item[0]);
            if (dt != DateTime.MinValue)
                list.Add(new DateTime(1, 1, 1, dt.Hour, dt.Minute, dt.Second));
            else
                list.Add(null);
        }

        return list;
    }

    public List<List<string>> Objects(params int[] columns)
    {
        var result = new List<List<string>>();
        var i = 0;
        List<string> o = null;
        foreach (var item in Records)
        {
            o = new List<string>(columns.Length);
            ////CA.InitFillWith(o, columns.Length);
            for (i = 0; i < columns.Length; i++)
                o.Add(item.Fields[columns[i]]);
            result.Add(o);
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
        Populate(filePath, null, hasHeaderRow, false);
    }

    /// <summary>
    ///     Populates the current instance from the specified file
    /// </summary>
    /// <param name = "filePath">File path</param>
    /// <param name = "hasHeaderRow">True if the file has a header row, otherwise false</param>
    /// <param name = "_trimColumns">True if column values should be trimmed, otherwise false</param>
    public void Populate(string filePath, bool hasHeaderRow, bool _trimColumns)
    {
        Populate(filePath, null, hasHeaderRow, _trimColumns);
    }

    /// <summary>
    ///     Populates the current instance from the specified file
    /// </summary>
    /// <param name = "filePath">File path</param>
    /// <param name = "encoding">Encoding</param>
    /// <param name = "hasHeaderRow">True if the file has a header row, otherwise false</param>
    /// <param name = "_trimColumns">True if column values should be trimmed, otherwise false</param>
    public void Populate(string filePath, Encoding encoding, bool hasHeaderRow, bool _trimColumns)
    {
        using (var reader = new SunamoCsvReader(filePath, encoding)
        {
            HasHeaderRow = hasHeaderRow,
            TrimColumns = _trimColumns
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
        Populate(stream, null, hasHeaderRow, false);
    }

    /// <summary>
    ///     Populates the current instance from a stream
    /// </summary>
    /// <param name = "stream">Stream</param>
    /// <param name = "hasHeaderRow">True if the file has a header row, otherwise false</param>
    /// <param name = "_trimColumns">True if column values should be trimmed, otherwise false</param>
    public void Populate(Stream stream, bool hasHeaderRow, bool _trimColumns)
    {
        Populate(stream, null, hasHeaderRow, _trimColumns);
    }
}