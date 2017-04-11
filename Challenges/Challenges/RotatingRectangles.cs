using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Challenges.Challenges
{
    public static class RotatingRectangles
    {
        private const string FileNameConfKey = "rectanglesFilePath";

        public static void Run(string[] args)
        {
            var fileContent = ReadRectanglesFromFile();
            if (fileContent == null)
            {
                return;
            }


        }

        private static IList<string> ReadRectanglesFromFile()
        {
            string filePath = ConfigurationManager.AppSettings.Get(FileNameConfKey);
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return null;
            }

            var fs = OpenFile(filePath);
            if (fs == null)
            {
                return null;
            }

            var fileContent = new List<string>();
            using (fs)
            {
                using (var sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        string currentLine = sr.ReadLine();
#if DEBUG
                        Console.WriteLine(currentLine);
#endif
                        fileContent.Add(currentLine);
                    }
                }
            }

            return fileContent;
        }

        private static FileStream OpenFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    return File.OpenRead(filePath);
                }
                catch (IOException ioe)
                {
                    return null;
                }
                catch (UnauthorizedAccessException uae)
                {
                    return null;
                }
            }

            return null;
        }
    }
}
