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

        public static string ParseThroughDirectoryAndGetFileContent(string path)
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
                            existingFiles.Add(file);
                        }
                        else
                        {
                            _fileCache.Add(Path.GetExtension(file), new List<string> {file});

                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Could not read file: {ex.Message}");
                    }
                }
            

            }
            return retreiveCodeFilesContent();
        }

        private  static string retreiveCodeFilesContent()
        {
            StringBuilder totalContents = new StringBuilder();
            HashSet<string> filesExtensions = new HashSet<string> {
                ".js", ".java", ".cs"};
            foreach (KeyValuePair<string, List<string>> entry in _fileCache)
            {
                if (filesExtensions.Contains(entry.Key))
                {
                    foreach (string fileName in entry.Value)
                    {
                        totalContents.Append($"\r\n --------------------- {Path.GetFileName(fileName)} ---------------------\r\n");

                        totalContents.Append(File.ReadAllText(fileName, Encoding.UTF8));
                        totalContents.Append("\r\n");
                    }
                }
                //File.WriteAllText("C:\\Users\\karth\\source\\repos\\DocGen\\CodeFilesContent.txt", totalContents.ToString());

            }
            return totalContents.ToString();

        }


    }
}
