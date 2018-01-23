using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerLib.Interfaces
{
    /// <summary>
    /// Interface to add role based security to the read of XML file
    /// </summary>
    public interface IRoleProvider
    {
        /// <summary>
        /// Validate if the user can read XML files
        /// </summary>
        /// <param name="filePath">path to the file</param>
        /// <returns>true if the user can read XML file, false in other case</returns>
        bool CanReadXMLFile(string filePath);

        /// <summary>
        /// Validate if the user can read TEXT files
        /// </summary>
        /// <param name="filePath">path to the file</param>
        /// <returns>true if the user can read TEXT file, false in other case</returns>
        bool CanReadTextFile(string filePath);
    }
}
