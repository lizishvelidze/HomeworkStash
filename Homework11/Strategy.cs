using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework11
{
    internal class Strategy
    {
        public interface IFileHandler
        {
            void HandleFile(string filePath);
        }

        public class ZipFileHandler : IFileHandler
        {
            public void HandleFile(string filePath)
            {
                string backupDir = Path.Combine(Directory.GetCurrentDirectory(), "Backup");

                if (!Directory.Exists(backupDir))
                {
                    Directory.CreateDirectory(backupDir);
                }

                string destinationPath = Path.Combine(backupDir, Path.GetFileNameWithoutExtension(filePath));

                if (Directory.Exists(destinationPath))
                {
                    ZipFile.ExtractToDirectory(filePath, destinationPath);
                }
             
            }
        }


        public class JsonFileHandler : IFileHandler
        {
            public void HandleFile(string FilePath)
            {
                string filePath = "C:\\Users\\User\\source\\repos\\Homework11\\Homework11\\random.json";
                string jsonContent = File.ReadAllText(filePath);
                JObject parsedJson = JObject.Parse(jsonContent);
                Console.WriteLine($"Contents of '{filePath}':\n{parsedJson}");
            }
        }

        public class TextFileHandler : IFileHandler
        {
            public void HandleFile(string filePath)
            {
                filePath = "C:\\Users\\User\\source\\repos\\Homework11\\Homework11\\some.txt";
                File.Delete(filePath);
                Console.WriteLine($"Deleted '{filePath}'.");
            }
        }
        public static class FileHandlerFactory
        {
            public static IFileHandler GetFileHandler(string fileExtension)
            {
                if (fileExtension == ".zip")
                {
                    return new ZipFileHandler();
                }
                else if (fileExtension == ".json")
                {
                    return new JsonFileHandler();
                }
                else if (fileExtension == ".txt")
                {
                    return new TextFileHandler();
                }

                return null;
            }
        }
    }
}
