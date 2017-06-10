namespace _04E.CopyBinaryFile
{
    using System.IO;

    public class CopyBinaryFile
    {
        public static void Main()
        {
            var sourceFile = new FileStream("../../SoftUniLogo.jpg", FileMode.Open);
            var targetFile = new FileStream("../../CopiedSoftUniLogo.jpg", FileMode.Create);

            using (sourceFile)
            {
                using (targetFile)
                {                  
                    while (sourceFile.Position < sourceFile.Length)
                    {
                        targetFile.WriteByte((byte)sourceFile.ReadByte());
                    }
                }
            }
        }
    }
}