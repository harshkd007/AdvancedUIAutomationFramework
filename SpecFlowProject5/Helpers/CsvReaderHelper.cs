using System.Collections.Generic;
using System.IO;

namespace UI.Helpers
{
    public static class CsvReaderHelper
    {
        public static List<string[]> ReadCsv(string filePath)
        {
            var rows = new List<string[]>();
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    rows.Add(values);
                }
            }
            return rows;
        }
    }
}