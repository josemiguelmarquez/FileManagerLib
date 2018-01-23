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
    public class TextReader : IReader, ICryptoReader
    {
        private IEncryptor _encryptor;

        /// <summary>
        /// Constructor to provide DI to the class
        /// </summary>
        /// <param name="encryptor">The encryptor selected</param>
        public TextReader(IEncryptor encryptor)
        {
            _encryptor = encryptor;
        }

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

        public string Read(string filePath, bool encryptedText)
        {
            // Check correct path
            if (File.Exists(filePath) && (filePath.EndsWith(".txt")))
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

            return string.Empty;
        }
    }
}
