namespace SunamoCsv;

// Use CsvFile instead
// Downloaded from http://www.codeproject.com/Articles/86973/C-CSV-Reader-and-Writer
/// <summary>
/// Represents the sunamo csv reader type.
/// </summary>
public sealed partial class SunamoCsvReader : IDisposable
{
    // Use CsvFile.DateTimes instead
    /// <summary>
    /// Date time.
    /// </summary>
    /// <param name="file">The file.</param>
    /// <param name="columnIndex">The column index.</param>
    /// <returns>The date time result.</returns>
    public static List<DateTime?> DateTime(CsvFile file, int columnIndex)
    {
        return file.DateTimes(columnIndex);
    }

    // Returns string values from specified column (use CsvFile.Strings instead)
    /// <summary>
    /// Strings.
    /// </summary>
    /// <param name="file">The file.</param>
    /// <param name="columnIndex">The column index.</param>
    /// <returns>The strings result.</returns>
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
    /// <summary>
    /// Gets or sets the trim columns.
    /// </summary>
    public bool TrimColumns { get; set; }
    /// <summary>
    /// Gets or sets the has header row.
    /// </summary>
    public bool HasHeaderRow { get; set; }
    /// <summary>
    /// Gets or sets the fields.
    /// </summary>
    public List<string>? Fields { get; private set; }
    /// <summary>
    ///     Gets the field count or returns null if no fields have been read
    /// </summary>
    /// <summary>
    ///     Initialises the reader to work from a file
    /// </summary>
    /// <param name = "filePath">File path</param>
    public int? FieldCount => Fields?.Count;

    /// <summary>
    /// Sunamo csv reader.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <returns>The sunamo csv reader result.</returns>
    public SunamoCsvReader(string filePath)
    {
        _type = TypeSource.File;
        Initialise(filePath, Encoding.UTF8);
    }

    /// <summary>
    /// Sunamo csv reader.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <returns>The sunamo csv reader result.</returns>
    public SunamoCsvReader(string filePath, Encoding? encoding)
    {
        _type = TypeSource.File;
        Initialise(filePath, encoding ?? Encoding.UTF8);
    }

    /// <summary>
    /// Initializes a new instance of the sunamo csv reader class.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="Encoding.UTF8">The encoding UTF 8.</param>
    public SunamoCsvReader(Stream stream)
    {
        _type = TypeSource.Stream;
        Initialise(stream, Encoding.UTF8);
    }

    /// <summary>
    /// Initializes a new instance of the sunamo csv reader class.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="Encoding.UTF8">The encoding UTF 8.</param>
    public SunamoCsvReader(Stream stream, Encoding? encoding)
    {
        _type = TypeSource.Stream;
        Initialise(stream, encoding ?? Encoding.UTF8);
    }

    /// <summary>
    /// Initializes a new instance of the sunamo csv reader class.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <param name="Encoding.UTF8">The encoding UTF 8.</param>
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

    /// <summary>
    /// Read next record.
    /// </summary>
    /// <param name="null."">The null.</param>
    /// <returns>The read next record result.</returns>
    public bool ReadNextRecord()
    {
        Fields = null;
        var line = _streamReader?.ReadLine();
        if (line == null)
            return false;
        ParseLine(line);
        return true;
    }

    /// <summary>
    /// Read into data table.
    /// </summary>
    /// <returns>The read into data table result.</returns>
    public DataTable ReadIntoDataTable()
    {
        return ReadIntoDataTable(new Type[] { });
    }

    /// <summary>
    /// Initializes a new instance of the read into data table class.
    /// </summary>
    /// <param name="line">The line.</param>
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

    /// <summary>
    /// Gets or sets the delimiter.
    /// </summary>
    public static char Delimiter { get; set; } = ',';
}
