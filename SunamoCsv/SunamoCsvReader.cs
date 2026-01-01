namespace SunamoCsv;

/// <summary>
///     Používat CsvFile místo toho
///     Class to read csv content from various sources
///     Downloaded from http://www.codeproject.com/Articles/86973/C-CSV-Reader-and-Writer
/// </summary>
public sealed partial class SunamoCsvReader : IDisposable
{
    /// <summary>
    ///     Use CsvFile.DateTimes instead
    /// </summary>
    /// <param name = "columnIndex">Zero-based column index</param>
    /// <param name = "file">CsvFile instance</param>
    public static List<DateTime?> DateTime(CsvFile file, int columnIndex)
    {
        return file.DateTimes(columnIndex);
    }

    /// <summary>
    ///     Returns string values from specified column (use CsvFile.Strings instead)
    /// </summary>
    /// <param name = "file">CsvFile instance</param>
    /// <param name = "columnIndex">Zero-based column index</param>
    /// <returns>List of string values from the column</returns>
    public static List<string> Strings(CsvFile file, int columnIndex)
    {
        return file.Strings(columnIndex);
    }

    /// <summary>
    ///     Type enum
    /// </summary>
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
    ///     Gets or sets whether column values should be trimmed
    /// </summary>
    public bool TrimColumns { get; set; }
    /// <summary>
    ///     Gets or sets whether the csv file has a header row
    /// </summary>
    public bool HasHeaderRow { get; set; }
    /// <summary>
    ///     Returns a collection of fields or null if no record has been read
    /// </summary>
    public List<string>? Fields { get; private set; }
    /// <summary>
    ///     Gets the field count or returns null if no fields have been read
    /// </summary>
    public int? FieldCount => Fields != null ? Fields.Count : null;

    /// <summary>
    ///     Initialises the reader to work from a file
    /// </summary>
    /// <param name = "filePath">File path</param>
    public SunamoCsvReader(string filePath)
    {
        _type = TypeSource.File;
        Initialise(filePath, Encoding.UTF8);
    }

    /// <summary>
    ///     Initialises the reader to work from a file
    /// </summary>
    /// <param name = "filePath">File path</param>
    /// <param name = "encoding">Encoding (null for UTF8)</param>
    public SunamoCsvReader(string filePath, Encoding? encoding)
    {
        _type = TypeSource.File;
        Initialise(filePath, encoding ?? Encoding.UTF8);
    }

    /// <summary>
    ///     Initialises the reader to work from an existing stream
    /// </summary>
    /// <param name = "stream">Stream</param>
    public SunamoCsvReader(Stream stream)
    {
        _type = TypeSource.Stream;
        Initialise(stream, Encoding.UTF8);
    }

    /// <summary>
    ///     Initialises the reader to work from an existing stream
    /// </summary>
    /// <param name = "stream">Stream</param>
    /// <param name = "encoding">Encoding (null for UTF8)</param>
    public SunamoCsvReader(Stream stream, Encoding? encoding)
    {
        _type = TypeSource.Stream;
        Initialise(stream, encoding ?? Encoding.UTF8);
    }

    /// <summary>
    ///     Initialises the reader to work from a csv string
    /// </summary>
    /// <param name = "encoding">Text encoding to use</param>
    /// <param name = "csvContent">CSV content as string</param>
    public SunamoCsvReader(Encoding? encoding, string csvContent)
    {
        _type = TypeSource.String;
        Initialise(encoding, csvContent);
    }

    /// <summary>
    ///     Initialises the public class to use a file
    /// </summary>
    /// <param name = "filePath"></param>
    /// <param name = "encoding"></param>
    private void Initialise(string filePath, Encoding encoding)
    {
        if (!File.Exists(filePath))
            throw new Exception( /*string.Format*/string.Format("The file '{0}' does not exist.", filePath));
        _fileStream = File.OpenRead(filePath);
        Initialise(_fileStream, encoding);
    }

    /// <summary>
    ///     Initialises the public class to use a stream
    /// </summary>
    /// <param name = "stream"></param>
    /// <param name = "encoding"></param>
    private void Initialise(Stream stream, Encoding encoding)
    {
        if (stream == null)
            throw new Exception("The supplied stream is null" + ".");
        _stream = stream;
        _stream.Position = 0;
        _encoding = encoding ?? Encoding.UTF8;
        _streamReader = new StreamReader(_stream, _encoding);
    }

    /// <summary>
    ///     Initialies the public class to use a string
    /// </summary>
    /// <param name = "encoding"></param>
    /// <param name = "csvContent"></param>
    private void Initialise(Encoding? encoding, string csvContent)
    {
        if (csvContent == null)
            throw new Exception("The supplied csvContent is null" + ".");
        _encoding = encoding ?? Encoding.UTF8;
        _memoryStream = new MemoryStream(csvContent.Length);
        _streamWriter = new StreamWriter(_memoryStream);
        _streamWriter.Write(csvContent);
        _streamWriter.Flush();
        Initialise(_memoryStream, _encoding);
    }

    /// <summary>
    ///     Reads the next record
    /// </summary>
    /// <returns>True if a record was successfuly read, otherwise false</returns>
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
    ///     Reads a csv file format into a data table.  This method
    ///     will always assume that the table has a header row as this will be used
    ///     to determine the columns.
    /// </summary>
    public DataTable ReadIntoDataTable()
    {
        return ReadIntoDataTable(new Type[] { });
    }

    /// <summary>
    ///     Reads a csv file format into a data table.  This method
    ///     will always assume that the table has a header row as this will be used
    ///     to determine the columns.
    /// </summary>
    /// <param name = "columnTypes">Array of column types</param>
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
    ///     Gets or sets the delimiter character used to separate fields in CSV files (default: comma)
    /// </summary>
    public static char Delimiter { get; set; } = ',';
}