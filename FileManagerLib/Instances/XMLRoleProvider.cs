using FileManagerLib.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerLib.Instances
{
    public class XMLRoleProvider : IRoleProvider
    {
        /// <summary>
        /// Instance of the Role Provider interface to add role based logic to the XML file
        /// </summary>
        /// <param name="filePath">path to the file</param>
        /// <returns>true if the user is auth, false in other case</returns>
        public bool CanReadXMLFile(string filePath)
        {
            // Check correct path
            if (File.Exists(filePath) && (filePath.EndsWith(".xml")))
            {
                // Simple validation checking if the user is Authenticated in windows
                return System.Security.Principal.WindowsIdentity.GetCurrent().IsAuthenticated;
            }

            return false;
        }
    }
}
