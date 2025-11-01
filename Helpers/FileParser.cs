using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ClosedXML.Excel;

namespace DocGen.Helpers
{
    public static class FileParser
    {
        private static Dictionary<string, List<string>> _fileCache = new Dictionary<string, List<string>>();

        public static void ParseThroughDirectory(string path)
        {
            foreach (var file in Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories))
            {
                if (!file.Contains($"{Path.DirectorySeparatorChar}.git{Path.DirectorySeparatorChar}"))
                {
                    try
                    {
                        if(_fileCache.ContainsKey(Path.GetExtension(file)))
                        {
                            var existingFiles = _fileCache[Path.GetExtension(file)];
                            existingFiles.Add(Path.GetFileName(file));
                        }
                        else
                        {
                            _fileCache.Add(Path.GetExtension(file), new List<string> { Path.GetFileName(file) });

                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Could not read file: {ex.Message}");
                    }
                }
            

            }
            WriteFilesToExcel(_fileCache);
        }

        private static void WriteFilesToExcel(Dictionary<string, List<string>> files)
        {
           
            

            string outputPath = "C:\\Users\\karth\\source\\repos\\DocGen\\FileListByExtension1.xlsx";

            var extensions = files.Keys.OrderBy(ext => ext).ToList();
            int maxRows = files.Values.Any() ? files.Values.Max(list => list.Count) : 0;

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("FilesByExtension1");

                // Write header
                for (int col = 0; col < extensions.Count; col++)
                {
                    worksheet.Cell(1, col + 1).Value = extensions[col];
                }

                // Write file names row by row
                for (int row = 0; row < maxRows; row++)
                {
                    for (int col = 0; col < extensions.Count; col++)
                    {
                        var ext = extensions[col];
                        var fileList = files[ext];
                        worksheet.Cell(row + 2, col + 1).Value = fileList.Count > row ? fileList[row] : "";
                    }
                }

                workbook.SaveAs(outputPath);
                workbook.Dispose();
            }
        }


    }
}
