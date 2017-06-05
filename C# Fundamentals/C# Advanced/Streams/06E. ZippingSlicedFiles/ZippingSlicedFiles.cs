namespace _06E.ZippingSlicedFiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.IO.Compression;

    public class ZippingSlicedFiles
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

            ArchivingSlices(sourceFile, targetDirectory, partsToSlice);

            var filesToJoin = Directory.GetFiles(targetDirectory).Where(f => f.EndsWith(".gz")).ToList();

            AssambleDirectory(filesToJoin, assambleDirectory);
        }

        public static void AssambleDirectory(List<string> filesToJoin, string assambleDirectory)
        {
            using (var writer = new FileStream(assambleDirectory + "\\" + "assembledPic.jpg", FileMode.Create))
            {
                foreach (var file in filesToJoin)
                {
                    using (var inputStream = new FileStream(file, FileMode.Open))
                    using (var decompressorStream = new GZipStream(inputStream, CompressionMode.Decompress))
                    {
                        var buffer = new byte[inputStream.Length];
                        var readCurrentBytes = decompressorStream.Read(buffer, 0, buffer.Length);

                        while (readCurrentBytes != 0)
                        {
                            writer.Write(buffer, 0, readCurrentBytes);

                            readCurrentBytes = decompressorStream.Read(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }

        public static void ArchivingSlices(string sourceFile, string targetDirectory, int partsToSlice)
        {
            using (var reader = new FileStream(sourceFile, FileMode.Open))
            {
                var partNumber = 1;
                
                var fileLength = (double)reader.Length;
                var length = (int)Math.Ceiling(fileLength / partsToSlice);

                var buffer = new byte[length];

                var readCurrentBytes = reader.Read(buffer, 0, buffer.Length);

                while (readCurrentBytes != 0)
                {
                    var path = targetDirectory + "\\" + "part" + partNumber.ToString() + ".gz";

                    using (var writer = new FileStream(path, FileMode.Create))
                    using (var compression = new GZipStream(writer, CompressionMode.Compress, false))
                    {
                        compression.Write(buffer, 0, buffer.Length);
                    }

                    readCurrentBytes = reader.Read(buffer, 0, buffer.Length);
                    partNumber++;
                }
            }
        }
    }
}