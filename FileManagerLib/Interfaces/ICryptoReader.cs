using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerLib.Interfaces
{
    /// <summary>
    /// Interface to read encrypted TEXT files
    /// </summary>
    public interface ICryptoReader
    {
        /// <summary>
        /// Read an encrypted TEXT file
        /// </summary>
        /// <param name="filePath">file to be read</param>
        /// <returns>the decrypted TEXT file</returns>
        string Read(string filePath, bool encryptedText);
    }
}
