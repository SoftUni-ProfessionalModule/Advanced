namespace _05E.SlicingFile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    public class SlicingFile
    {
        public static void Main()
        {
            Console.WriteLine("Enter number of slices");
            var partsToSlice = int.Parse(Console.ReadLine());

            var sourceFile = "Ferrari-812.jpg";
            Console.WriteLine("Enter destination folder name:");
            var targetDirectory = $@"../../{Console.ReadLine()}/";

            Console.WriteLine("Enter assamble folder name:");
            var assambleDirectory = $@"../../{Console.ReadLine()}";

            var isTargetDirectoryExist = Directory.Exists(targetDirectory);

            if (!isTargetDirectoryExist)
            {
                Directory.CreateDirectory(targetDirectory);
            }

            var isAssambleDirectoryExist = Directory.Exists(assambleDirectory);

            if (!isAssambleDirectoryExist)
            {
                Directory.CreateDirectory(assambleDirectory);
            }

            Slice(sourceFile, targetDirectory, partsToSlice);

            var filesToJoin = Directory.GetFiles(targetDirectory).ToList();


            AssambleDirectory(filesToJoin, assambleDirectory);
        }

        public static void AssambleDirectory(List<string> filesToJoin, string assambleDirectory)
        {
            var writer = new FileStream(assambleDirectory + "\\" + "assembledPic.jpg", FileMode.Create, FileAccess.Write);

            using (writer)
            {
                foreach (var file in filesToJoin)
                {
                    var reader = new FileStream(file, FileMode.Open);

                    using (reader)
                    {
                        var buffer = new byte[reader.Length];

                        var readCurrentBytes = reader.Read(buffer, 0, buffer.Length);

                        while (readCurrentBytes != 0)
                        {
                            writer.Write(buffer, 0, readCurrentBytes);

                            readCurrentBytes = reader.Read(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }

        public static void Slice(string sourceFile, string targetDirectory, int partsToSlice)
        {
            var reader = new FileStream(sourceFile, FileMode.Open);

            using (reader)
            {
                var fileLength = (double)reader.Length;
                var length = (int)Math.Ceiling(fileLength / partsToSlice);

                var buffer = new byte[length];

                var readCurrentBytes = reader.Read(buffer, 0, buffer.Length);
                var partNumber = 1;

                while (readCurrentBytes != 0)
                {
                    var writer =
                        new FileStream(targetDirectory + "\\" + "part" + partNumber.ToString() + ".jpg", FileMode.CreateNew, FileAccess.Write);

                    using (writer)
                    {
                        writer.Write(buffer, 0, readCurrentBytes);
                    }

                    readCurrentBytes = reader.Read(buffer, 0, buffer.Length);
                    partNumber++;
                }
            }
        }
    }
}