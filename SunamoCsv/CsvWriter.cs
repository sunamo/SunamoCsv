namespace SunamoCsv;

// Downloaded from http://www.codeproject.com/Articles/86973/C-CSV-Reader-and-Writer
/// <summary>
/// Represents the csv writer type.
/// </summary>
public sealed class CsvWriter : IDisposable
{
    #region Members

    private StreamWriter? _streamWriter;

    #endregion Members

    #region Properties

    /// <summary>
    /// Gets or sets the replace carriage returns and line feeds from field values.
    /// </summary>
    public bool ReplaceCarriageReturnsAndLineFeedsFromFieldValues { get; set; } = true;

    /// <summary>
    /// Gets or sets the carriage return and line feed replacement.
    /// </summary>
    public string CarriageReturnAndLineFeedReplacement { get; set; } = ",";

    #endregion Properties

    #region Methods

    #region CsvFile write methods

    /// <summary>
    /// Write csv.
    /// </summary>
    /// <param name="csvFile">The csv file.</param>
    /// <param name="filePath">The file path.</param>
    /// <returns>The write csv result.</returns>
    public void WriteCsv(CsvFile csvFile, string filePath)
    {
        WriteCsv(csvFile, filePath, (Encoding?)null);
    }

    /// <summary>
    /// Write csv.
    /// </summary>
    /// <param name="csvFile">The csv file.</param>
    /// <param name="filePath">The file path.</param>
    public void WriteCsv(CsvFile csvFile, string filePath, Encoding? encoding)
    {
        if (File.Exists(filePath))
            File.Delete(filePath);

        using (var writer = new StreamWriter(filePath, false, encoding ?? Encoding.UTF8))
        {
            WriteToStream(csvFile, writer);
            writer.Flush();
            writer.Close();
        }
    }

    /// <summary>
    /// Initializes a new instance of the write csv class.
    /// </summary>
    /// <param name="csvFile">The csv file.</param>
    /// <param name="writer">The writer.</param>
    public void WriteCsv(CsvFile csvFile, Stream stream)
    {
        WriteCsv(csvFile, stream, (Encoding?)null);
    }

    /// <summary>
    /// Write csv.
    /// </summary>
    /// <param name="csvFile">The csv file.</param>
    /// <param name="stream">The stream.</param>
    public void WriteCsv(CsvFile csvFile, Stream stream, Encoding? encoding)
    {
        stream.Position = 0;
        _streamWriter = new StreamWriter(stream, encoding ?? Encoding.UTF8);
        WriteToStream(csvFile, _streamWriter);
        _streamWriter.Flush();
        stream.Position = 0;
    }

    /// <summary>
    /// Write csv.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <param name="Encoding.UTF8">The encoding UTF 8.</param>
    /// <returns>The write csv result.</returns>
    public string WriteCsv(CsvFile csvFile, Encoding? encoding)
    {
        var content = string.Empty;

        using (var memoryStream = new MemoryStream())
        {
            using (var writer = new StreamWriter(memoryStream, encoding ?? Encoding.UTF8))
            {
                WriteToStream(csvFile, writer);
                writer.Flush();
                memoryStream.Position = 0;

                using (var reader = new StreamReader(memoryStream, encoding ?? Encoding.UTF8))
                {
                    content = reader.ReadToEnd();
                    writer.Close();
                    reader.Close();
                    memoryStream.Close();
                }
            }
        }

        return content;
    }

    #endregion CsvFile write methods

    #region DataTable write methods

    /// <summary>
    /// Write csv.
    /// </summary>
    /// <param name="dataTable">The data table.</param>
    /// <param name="filePath">The file path.</param>
    /// <returns>The write csv result.</returns>
    public void WriteCsv(DataTable dataTable, string filePath)
    {
        WriteCsv(dataTable, filePath, (Encoding?)null);
    }

    /// <summary>
    /// Write csv.
    /// </summary>
    /// <param name="dataTable">The data table.</param>
    /// <param name="filePath">The file path.</param>
    public void WriteCsv(DataTable dataTable, string filePath, Encoding? encoding)
    {
        if (File.Exists(filePath))
            File.Delete(filePath);

        using (var writer = new StreamWriter(filePath, false, encoding ?? Encoding.UTF8))
        {
            WriteToStream(dataTable, writer);
            writer.Flush();
            writer.Close();
        }
    }

    /// <summary>
    /// Initializes a new instance of the write csv class.
    /// </summary>
    /// <param name="dataTable">The data table.</param>
    /// <param name="writer">The writer.</param>
    public void WriteCsv(DataTable dataTable, Stream stream)
    {
        WriteCsv(dataTable, stream, (Encoding?)null);
    }

    /// <summary>
    /// Write csv.
    /// </summary>
    /// <param name="dataTable">The data table.</param>
    /// <param name="stream">The stream.</param>
    public void WriteCsv(DataTable dataTable, Stream stream, Encoding? encoding)
    {
        stream.Position = 0;
        _streamWriter = new StreamWriter(stream, encoding ?? Encoding.UTF8);
        WriteToStream(dataTable, _streamWriter);
        _streamWriter.Flush();
        stream.Position = 0;
    }

    /// <summary>
    /// Write csv.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <param name="Encoding.UTF8">The encoding UTF 8.</param>
    /// <returns>The write csv result.</returns>
    public string WriteCsv(DataTable dataTable, Encoding? encoding)
    {
        var content = string.Empty;

        using (var memoryStream = new MemoryStream())
        {
            using (var writer = new StreamWriter(memoryStream, encoding ?? Encoding.UTF8))
            {
                WriteToStream(dataTable, writer);
                writer.Flush();
                memoryStream.Position = 0;

                using (var reader = new StreamReader(memoryStream, encoding ?? Encoding.UTF8))
                {
                    content = reader.ReadToEnd();
                    writer.Close();
                    reader.Close();
                    memoryStream.Close();
                }
            }
        }

        return content;
    }

    #endregion DataTable write methods

    private void WriteToStream(CsvFile csvFile, TextWriter writer)
    {
        if (csvFile.Headers.Count > 0)
            WriteRecord(csvFile.Headers, writer);

        csvFile.Records.ForEach(record => WriteRecord(record.Fields, writer));
    }

    private void WriteToStream(DataTable dataTable, TextWriter writer)
    {
        var fields = (from DataColumn column in dataTable.Columns select column.ColumnName).ToList();
        WriteRecord(fields, writer);

        foreach (DataRow row in dataTable.Rows)
        {
            fields.Clear();
            fields.AddRange(row.ItemArray.Select(value => value?.ToString() ?? string.Empty));
            WriteRecord(fields, writer);
        }
    }

    private void WriteRecord(IList<string> fields, TextWriter writer)
    {
        for (var i = 0; i < fields.Count; i++)
        {
            var areQuotesRequired = fields[i].Contains(",");
            var shouldEscapeQuotes = fields[i].Contains("\"");
            var fieldValue = shouldEscapeQuotes ? fields[i].Replace("\"", "\"") : fields[i];

            if (ReplaceCarriageReturnsAndLineFeedsFromFieldValues &&
                (fieldValue.Contains("\r") || fieldValue.Contains("\n")))
            {
                areQuotesRequired = true;
                fieldValue = fieldValue.Replace("\r\n", CarriageReturnAndLineFeedReplacement);
                fieldValue = fieldValue.Replace("\r", CarriageReturnAndLineFeedReplacement);
                fieldValue = fieldValue.Replace("\n", CarriageReturnAndLineFeedReplacement);
            }

            writer.Write(
                "{0}{1}{0}{2}", areQuotesRequired || shouldEscapeQuotes ? "\"" : string.Empty, fieldValue,
                i < fields.Count - 1 ? "," : string.Empty);
        }

        writer.WriteLine();
    }

    /// <summary>
    /// Dispose.
    /// </summary>
    /// <returns>The dispose result.</returns>
    public void Dispose()
    {
        if (_streamWriter == null)
            return;

        _streamWriter.Close();
        _streamWriter.Dispose();
    }

    #endregion Methods
}
