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
        var f = @"D:\_Test\sunamo\SunamoCsv\contacts.csv";

        GoogleContactExportRow c = new GoogleContactExportRow();
        var g = c.GetType().GetProperties().Select(d => d.Name);

        var c2 =
#if ASYNC
await
#endif
TF.ReadAllText(f);

        CsvFile csv = new CsvFile();
        //CsvReader csvReader = new CsvReader();
        csv.Populate(true, c2);

        var gCount = g.Count();

        List<List<string>> ls = new List<List<string>>(gCount);
        int i = 0;
        foreach (var item in g)
        {
            var ls2 = LinearHelper.GetStringListFromTo(0, gCount - 1);
            //var li = ls2.ConvertAll(d => int.Parse( CAG.ToList<int>(ls2);

            var entries = csv.Strings(0);
            ls.Add(entries);
        }

        int d2 = 0;
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
        var f = @"D:\_Test\sunamo\SunamoCsv\contacts_Outlook.csv";

        GoogleContactExportRow c = new GoogleContactExportRow();
        var g = c.GetType().GetProperties().Select(d2 => d2.Name);

        var c2 =
#if ASYNC
await
#endif
TF.ReadAllText(f);

        CsvFile csv = new CsvFile();
        //CsvReader csvReader = new CsvReader();
        csv.Populate(true, c2);

        var gCount = g.Count();

        List<List<string>> ls = new List<List<string>>(gCount);
        int i = 0;
        foreach (var item in g)
        {
            var ls2 = LinearHelper.GetStringListFromTo(0, gCount - 1);
            var li = ls2.ConvertAll(d => int.Parse(d)); //CAG.ToList<int>();

            var entries = csv.Strings(0);
            ls.Add(entries);
        }

        int d = 0;
    }
}
