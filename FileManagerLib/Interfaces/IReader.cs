using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerLib.Interfaces
{
    /// <summary>
    /// Interface to read Text files
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Read a plain TXT file
        /// </summary>
        /// <param name="filePath">path to the file</param>
        /// <returns>the content of the file</returns>
        string Read(string filePath);
    }
}
