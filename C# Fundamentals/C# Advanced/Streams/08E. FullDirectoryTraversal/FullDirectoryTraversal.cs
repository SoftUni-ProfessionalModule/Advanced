namespace _08E.FullDirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    public class FileDetails
    {
        public string Name { get; set; }

        public double Size { get; set; }
    }
    public class FullDirectoryTraversal
    {
        public static void Main()
        {
            var reportDict = new Dictionary<string, List<FileDetails>>();
            var reportLines = new List<string>();

            Console.WriteLine("Enter path to Main directory");
            var inputDirectory = Console.ReadLine();

            while (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine($"Directory path \"{inputDirectory}\" does not exist");
                Console.WriteLine("Enter path to Main directory");
                Console.WriteLine(@"Example: C:\Users\Venci\Desktop\Software University");
                inputDirectory = Console.ReadLine();
            }

            GetFilesFromMainDirectory(reportDict, inputDirectory);
            GetFilesFromInnerDirectories(reportDict, inputDirectory);

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            foreach (var extension in reportDict.OrderByDescending(e => e.Value.Count).ThenBy(e => e.Key))
            {
                reportLines.Add(extension.Key);
                foreach (var file in extension.Value.OrderBy(s => s.Size))
                {
                    reportLines.Add($"--{file.Name} - {file.Size:f2}kb");
                }
            }

            reportLines.Add("-----Total files number: " + (reportDict.Values.Sum(x => x.Count)).ToString()+ "-----");
            File.WriteAllLines(desktopPath + "\\" + "report.txt", reportLines);
        }

        private static void GetFilesFromInnerDirectories(Dictionary<string, List<FileDetails>> reportDict, string inputDirectory)
        {
            var innerDirectories = Directory.GetDirectories(inputDirectory, "*", SearchOption.AllDirectories);

            foreach (var directory in innerDirectories)
            {
                var filesInInnerDirectories = Directory.GetFiles(directory);

                GetFiles(reportDict, filesInInnerDirectories);
            }
        }

        private static void GetFiles(Dictionary<string, List<FileDetails>> reportDict, string[] filesInInnerDirectories)
        {
            foreach (var file in filesInInnerDirectories)
            {
                var fileInfo = new FileInfo(file);
                var currentFileExtension = fileInfo.Extension;
                var currentFileName = fileInfo.Name;
                var currentFileSizeInkb = (fileInfo.Length) / 1024.0;

                if (!reportDict.ContainsKey(currentFileExtension))
                {
                    reportDict.Add(currentFileExtension, new List<FileDetails>());
                }

                reportDict[currentFileExtension].Add(new FileDetails { Name = currentFileName, Size = currentFileSizeInkb });
            }
        }

        private static void GetFilesFromMainDirectory(Dictionary<string, List<FileDetails>> reportDict, string inputDirectory)
        {
            var filesInMainDirectory = Directory.GetFiles(inputDirectory);

            GetFiles(reportDict, filesInMainDirectory);
        }
    }
}