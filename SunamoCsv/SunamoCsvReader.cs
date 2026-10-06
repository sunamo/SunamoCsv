namespace SunamoCsv;

// Používat CsvFile místo toho
// Downloaded from http://www.codeproject.com/Articles/86973/C-CSV-Reader-and-Writer
public sealed partial class SunamoCsvReader : IDisposable
{
    // Use CsvFile.DateTimes instead
    public static List<DateTime?> DateTime(CsvFile file, int columnIndex)
    {
        return file.DateTimes(columnIndex);
    }

    // Returns string values from specified column (use CsvFile.Strings instead)
    public static List<string> Strings(CsvFile file, int columnIndex)
    {
        return file.Strings(columnIndex);
    }

    private enum TypeSource
    {
        File,
        Stream,
        String
    }

    private FileStream? _fileStream;
    private Stream? _stream;
    private StreamReader? _streamReader;
    private StreamWriter? _streamWriter;
    private Stream? _memoryStream;
    private Encoding? _encoding;
    private readonly StringBuilder _columnBuilder = new(100);
    private readonly TypeSource _type = TypeSource.File;
    public bool TrimColumns { get; set; }
    public bool HasHeaderRow { get; set; }
    public List<string>? Fields { get; private set; }
    /// <summary>
    ///     Gets the field count or returns null if no fields have been read
    /// </summary>
    /// <summary>
    ///     Initialises the reader to work from a file
    /// </summary>
    /// <param name = "filePath">File path</param>
    public int? FieldCount => Fields?.Count;

    public SunamoCsvReader(string filePath)
    {
        _type = TypeSource.File;
        Initialise(filePath, Encoding.UTF8);
    }

    public SunamoCsvReader(string filePath, Encoding? encoding)
    {
        _type = TypeSource.File;
        Initialise(filePath, encoding ?? Encoding.UTF8);
    }

    public SunamoCsvReader(Stream stream)
    {
        _type = TypeSource.Stream;
        Initialise(stream, Encoding.UTF8);
    }

    public SunamoCsvReader(Stream stream, Encoding? encoding)
    {
        _type = TypeSource.Stream;
        Initialise(stream, encoding ?? Encoding.UTF8);
    }

    public SunamoCsvReader(Encoding? encoding, string csvContent)
    {
        _type = TypeSource.String;
        Initialise(encoding, csvContent);
    }

    private void Initialise(string filePath, Encoding encoding)
    {
        if (!File.Exists(filePath))
            throw new Exception(string.Format("The file '{0}' does not exist.", filePath));
        _fileStream = File.OpenRead(filePath);
        Initialise(_fileStream, encoding);
    }

    private void Initialise(Stream stream, Encoding encoding)
    {
        if (stream == null)
            throw new Exception("The supplied stream is null.");
        _stream = stream;
        _stream.Position = 0;
        _encoding = encoding ?? Encoding.UTF8;
        _streamReader = new StreamReader(_stream, _encoding);
    }

    private void Initialise(Encoding? encoding, string csvContent)
    {
        if (csvContent == null)
            throw new Exception("The supplied csvContent is null.");
        _encoding = encoding ?? Encoding.UTF8;
        _memoryStream = new MemoryStream(csvContent.Length);
        _streamWriter = new StreamWriter(_memoryStream);
        _streamWriter.Write(csvContent);
        _streamWriter.Flush();
        Initialise(_memoryStream, _encoding);
    }

    public bool ReadNextRecord()
    {
        Fields = null;
        var line = _streamReader?.ReadLine();
        if (line == null)
            return false;
        ParseLine(line);
        return true;
    }

    public DataTable ReadIntoDataTable()
    {
        return ReadIntoDataTable(new Type[] { });
    }

    public DataTable ReadIntoDataTable(Type[] columnTypes)
    {
        var dataTable = new DataTable();
        var isHeaderAdded = false;
        if (_stream != null)
            _stream.Position = 0;
        while (ReadNextRecord())
        {
            if (!isHeaderAdded && Fields != null)
            {
                for (var i = 0; i < Fields.Count; i++)
                    dataTable.Columns.Add(Fields[i], columnTypes.Length > 0 ? columnTypes[i] : typeof(string));
                isHeaderAdded = true;
                continue;
            }

            if (Fields != null)
            {
                var row = dataTable.NewRow();
                for (var i = 0; i < Fields.Count; i++)
                    row[i] = Fields[i];
                dataTable.Rows.Add(row);
            }
        }

        return dataTable;
    }

    public static char Delimiter { get; set; } = ',';
}
