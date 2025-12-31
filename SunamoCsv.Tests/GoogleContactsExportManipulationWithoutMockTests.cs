// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

using SunamoCsv.Data;
using SunamoFileIO;
using SunamoShared.Helpers.Number;
using System.Threading.Tasks;

namespace SunamoCsv.Tests;

public class GoogleContactsExportManipulationWithoutMockTests
{
    //[Fact]
    public
#if ASYNC
async Task
#else
    void
#endif
ParseGoogleFormatGoogleContactsTest()
    {
        var filePath = @"D:\_Test\sunamo\SunamoCsv\contacts.csv";

        GoogleContactExportRow row = new GoogleContactExportRow();
        var propertyNames = row.GetType().GetProperties().Select(property => property.Name);

        var fileContent =
#if ASYNC
await
#endif
TF.ReadAllText(filePath);

        CsvFile csv = new CsvFile();
        //CsvReader csvReader = new CsvReader();
        csv.Populate(true, fileContent);

        var propertyCount = propertyNames.Count();

        List<List<string>> columnData = new List<List<string>>(propertyCount);
        foreach (var item in propertyNames)
        {
            var stringList = LinearHelper.GetStringListFromTo(0, propertyCount - 1);
            //var intList = stringList.ConvertAll(text => int.Parse( CAG.ToList<int>(stringList);

            var entries = csv.Strings(0);
            columnData.Add(entries);
        }
    }

    //[Fact]
    public
#if ASYNC
async Task
#else
    void
#endif
ParseOutlookFormatGoogleContactsTest()
    {
        var filePath = @"D:\_Test\sunamo\SunamoCsv\contacts_Outlook.csv";

        GoogleContactExportRow row = new GoogleContactExportRow();
        var propertyNames = row.GetType().GetProperties().Select(property => property.Name);

        var fileContent =
#if ASYNC
await
#endif
TF.ReadAllText(filePath);

        CsvFile csv = new CsvFile();
        //CsvReader csvReader = new CsvReader();
        csv.Populate(true, fileContent);

        var propertyCount = propertyNames.Count();

        List<List<string>> columnData = new List<List<string>>(propertyCount);
        foreach (var item in propertyNames)
        {
            var stringList = LinearHelper.GetStringListFromTo(0, propertyCount - 1);
            var intList = stringList.ConvertAll(text => int.Parse(text)); //CAG.ToList<int>();

            var entries = csv.Strings(0);
            columnData.Add(entries);
        }
    }
}
