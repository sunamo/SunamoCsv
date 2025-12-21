namespace SunamoCsv;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
/// <summary>
///     Používat CsvFile místo toho
///     Class to read csv content from various sources
///     Downloaded from http://www.codeproject.com/Articles/86973/C-CSV-Reader-and-Writer
/// </summary>
public sealed partial class SunamoCsvReader : IDisposable
{
    /// <summary>
    ///     Parses a csv line
    /// </summary>
    /// <param name = "line">Line</param>
    private void ParseLine(string line)
    {
        Fields = new List<string>();
        var inColumn = false;
        var inQuotes = false;
        _columnBuilder.Remove(0, _columnBuilder.Length);
        // Iterate through every character in the line
        for (var i = 0; i < line.Length; i++)
        {
            var character = line[i];
            // If we are not currently inside a column
            if (!inColumn)
            {
                if (character == '"')
                    inQuotes = true;
                else
                    _columnBuilder.Append(character);
                inColumn = true;
                continue;
            }

            // If we are in between double quotes
            if (inQuotes)
            {
                if (character == '"' && ((line.Length > i + 1 && line[i + 1] == delimiter) || i + 1 == line.Length))
                {
                    inQuotes = false;
                    inColumn = false;
                    i++;
                }
                else if (character == '"' && line.Length > i + 1 && line[i + 1] == '"')
                {
                    i++;
                }
            }
            else if (character == delimiter)
            {
                inColumn = false;
            }

            // If we are no longer in the column clear the builder and add the columns to the list
            if (!inColumn)
            {
                Fields.Add(TrimColumns ? _columnBuilder.ToString().Trim() : _columnBuilder.ToString());
                _columnBuilder.Remove(0, _columnBuilder.Length);
            }
            else // append the current column
            {
                _columnBuilder.Append(character);
            }
        }

        // If we are still inside a column add a new one
        if (inColumn)
            Fields.Add(TrimColumns ? _columnBuilder.ToString().Trim() : _columnBuilder.ToString());
    }

    /// <summary>
    ///     Disposes of all unmanaged resources
    /// </summary>
    public void Dispose()
    {
        if (_streamReader != null)
        {
            _streamReader.Close();
            _streamReader.Dispose();
        }

        if (_streamWriter != null)
        {
            _streamWriter.Close();
            _streamWriter.Dispose();
        }

        if (_memoryStream != null)
        {
            _memoryStream.Close();
            _memoryStream.Dispose();
        }

        if (_fileStream != null)
        {
            _fileStream.Close();
            _fileStream.Dispose();
        }

        if ((_type == TypeSource.String || _type == TypeSource.File) && _stream != null)
        {
            _stream.Close();
            _stream.Dispose();
        }
    }
}