namespace SunamoCsv;

// Class to hold csv data
// Downloaded from http://www.codeproject.com/Articles/86973/C-CSV-Reader-and-Writer
public sealed partial class CsvFile
{
    public void Populate(Stream stream, Encoding? encoding, bool hasHeaderRow, bool isTrimmingColumns)
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

    public void Populate(bool hasHeaderRow, string csvContent)
    {
        Populate(hasHeaderRow, csvContent, (Encoding?)null, false);
    }

    public void Populate(bool hasHeaderRow, string csvContent, bool isTrimmingColumns)
    {
        Populate(hasHeaderRow, csvContent, (Encoding?)null, isTrimmingColumns);
    }

    public void Populate(bool hasHeaderRow, string csvContent, Encoding? encoding, bool isTrimmingColumns)
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

    private void PopulateCsvFile(SunamoCsvReader reader)
    {
        Headers.Clear();
        Records.Clear();
        var isHeaderAdded = false;
        while (reader.ReadNextRecord())
        {
            if (reader.HasHeaderRow && !isHeaderAdded && reader.Fields != null)
            {
                reader.Fields.ForEach(field => Headers.Add(field));
                isHeaderAdded = true;
                continue;
            }

            if (reader.Fields != null)
            {
                var record = new CsvRecord();
                reader.Fields.ForEach(field => record.Fields.Add(field));
                Records.Add(record);
            }
        }
    }
}
