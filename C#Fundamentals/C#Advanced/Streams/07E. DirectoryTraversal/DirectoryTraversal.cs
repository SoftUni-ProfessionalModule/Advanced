namespace _07E.DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    public class DirectoryTraversal
    {
        public static void Main()
        {
            var reportDict = new Dictionary<string, Dictionary<string, double>>();
            var reportLines = new List<string>();

            Console.WriteLine("Enter path to directory");
            var inputDirectory = Console.ReadLine();

            while (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Directory does not exist");
                Console.WriteLine("Enter path to directory");

                inputDirectory = Console.ReadLine();
            }

            var filesInDirectory = Directory.GetFiles(inputDirectory);

            foreach (var file in filesInDirectory)
            {
                var fileInfo = new FileInfo(file);
                var currentFileExtension = fileInfo.Extension;
                var currentFileName = fileInfo.Name;
                var currentFileSizeInkb = (fileInfo.Length) / 1024.0;

                if (!reportDict.ContainsKey(currentFileExtension))
                {
                    reportDict.Add(currentFileExtension, new Dictionary<string, double>());
                }

                reportDict[currentFileExtension].Add(currentFileName, currentFileSizeInkb);
            }

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            foreach (var extension in reportDict.OrderByDescending(e => e.Value.Values.Count).ThenBy(e => e.Key))
            {
                reportLines.Add(extension.Key);
                foreach (var file in extension.Value.OrderBy(s => s.Value))
                {
                    reportLines.Add($"--{file.Key} - {file.Value:f2}kb");
                }
            }

            File.WriteAllLines(desktopPath + "\\" + "report.txt", reportLines);
        }
    }
}