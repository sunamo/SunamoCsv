namespace SunamoCsv;

// Class to hold csv data
// Downloaded from http://www.codeproject.com/Articles/86973/C-CSV-Reader-and-Writer
public sealed partial class CsvFile
{
    public CsvFile()
    {
    }

    public CsvFile(char delimiter)
    {
        SunamoCsvReader.Delimiter = delimiter;
    }

    public readonly List<string> Headers = new();
    public readonly CsvRecords Records = new();
    public int HeaderCount => Headers.Count;

    public List<string> Strings(int columnIndex)
    {
        var list = new List<string>();
        var objects = Objects(columnIndex);
        foreach (var item in objects)
            list.Add(item[0]);
        return list;
    }

    // Return null when cannot be parsed
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

    public int RecordCount => Records.Count;

    public CsvRecord this[int recordIndex]
    {
        get
        {
            if (recordIndex > Records.Count - 1)
                throw new Exception($"There is no record at index {recordIndex}.");
            return Records[recordIndex];
        }
    }

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

    public void Populate(string filePath, bool hasHeaderRow)
    {
        Populate(filePath, (Encoding?)null, hasHeaderRow, false);
    }

    public void Populate(string filePath, bool hasHeaderRow, bool isTrimmingColumns)
    {
        Populate(filePath, (Encoding?)null, hasHeaderRow, isTrimmingColumns);
    }

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

    public void Populate(Stream stream, bool hasHeaderRow)
    {
        Populate(stream, (Encoding?)null, hasHeaderRow, false);
    }

    public void Populate(Stream stream, bool hasHeaderRow, bool isTrimmingColumns)
    {
        Populate(stream, (Encoding?)null, hasHeaderRow, isTrimmingColumns);
    }
}
