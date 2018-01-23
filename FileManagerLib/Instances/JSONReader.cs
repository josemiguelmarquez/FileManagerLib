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
    /// Instance of the reader to read JSON files
    /// </summary>
    public class JSONReader : IReader
    {
        /// <summary>
        /// For the Read method of the JSON files we will implement the same logic as the 
        /// TEXT file since the scope does not say anything regarding the json objects itself.
        /// If we want to parse and use the JSON object in the .NET environment I suggest
        /// to include the NewtonSoft library
        /// </summary>
        /// <param name="filePath">path to the file</param>
        /// <returns>content of the json file</returns>
        public string Read(string filePath)
        {
            // Check correct path
            if (File.Exists(filePath) && (filePath.EndsWith(".json")))
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
