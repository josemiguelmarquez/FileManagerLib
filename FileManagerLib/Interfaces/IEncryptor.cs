using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerLib.Interfaces
{
    /// <summary>
    /// Contract to enable encryptation in files
    /// </summary>
    public interface IEncryptor
    {
        /// <summary>
        /// Method to encrypt a given string
        /// </summary>
        /// <param name="input">the data to encrypt</param>
        /// <returns>encrypted data</returns>
        string Encrypt(string input);

        /// <summary>
        /// Method to decrypt a given string
        /// </summary>
        /// <param name="input">the data to decrypt</param>
        /// <returns>decrypted data</returns>
        string Decrypt(string input);
    }
}
