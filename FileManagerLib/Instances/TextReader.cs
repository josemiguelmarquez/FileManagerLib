using FileManagerLib.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerLib.Instances
{
    /// <summary>
    /// Instance of the reader to read TEXT files
    /// </summary>
    public class TextReader : IReader
    {
        public string Read(string filePath)
        {
            // Check correct path
            if (File.Exists(filePath) && (filePath.EndsWith(".txt")))
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader streanReader = new StreamReader(fileStream))
                    {
                        return streanReader.ReadToEnd();
                    }
                }
            }

            return string.Empty;
        }
    }
}
