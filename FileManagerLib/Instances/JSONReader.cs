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
    public class JSONReader : IReader, ICryptoReader
    {
        private IEncryptor _encryptor;
        private IRoleProvider _roleProvider;

        /// <summary>
        /// Constructor to enable DI
        /// </summary>
        /// <param name="encryptor">cryptographer selected</param>
        public JSONReader(IEncryptor encryptor, IRoleProvider roleProvider)
        {
            this._encryptor = encryptor;
            this._roleProvider = roleProvider;
        }

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
                // Check if the user can read json files
                if (_roleProvider.CanReadJSONFile(filePath))
                {

                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        using (StreamReader streanReader = new StreamReader(fileStream))
                        {
                            return streanReader.ReadToEnd();
                        }
                    }
                }   
            }

            return string.Empty;
        }

        /// <summary>
        /// For the Read method of the encrypted JSON files we will implement the same logic as the 
        /// TEXT file since the scope does not say anything regarding the json objects itself.
        /// If we want to parse and use the JSON object in the .NET environment I suggest
        /// to include the NewtonSoft library
        /// </summary>
        /// <param name="filePath">path to the file</param>
        /// <param name="encryptedText">flag that indicates if the file is encrypted</param>
        /// <returns>the decrypted JSON file</returns>
        public string Read(string filePath, bool encryptedText)
        {
            // Check correct path
            if (File.Exists(filePath) && (filePath.EndsWith(".json")))
            {
                // Check if the user can read json files
                if (_roleProvider.CanReadJSONFile(filePath))
                {
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        using (StreamReader streanReader = new StreamReader(fileStream))
                        {
                            // if not encrypted, just read the file
                            // in other case, use the decryptor
                            return (!encryptedText ? streanReader.ReadToEnd() : _encryptor.Decrypt(streanReader.ReadToEnd()));
                        }
                    }
                }
            }

            return string.Empty;
        }
    }
}
