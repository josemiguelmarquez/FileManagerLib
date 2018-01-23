using FileManagerLib.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FileManagerLib.Instances
{
    /// <summary>
    /// Instance of the reader to read XML files
    /// </summary
    public class XMLReader : IReader
    {
        /// <summary>
        /// Read XML file
        /// </summary>
        /// <param name="filePath">path to the xml file</param>
        /// <returns>XML file content as a string</returns>
        public string Read(string filePath)
        {
            string result = string.Empty;

            // Check correct path
            if (File.Exists(filePath) && (filePath.EndsWith(".xml")))
            {
                using (XmlTextReader reader = new XmlTextReader(filePath))
                {
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element: // The node is an element.
                                result += ("<" + reader.Name);
                                result += (">");
                                break;
                            case XmlNodeType.Text: //Display the text in each element.
                                result += (reader.Value);
                                break;
                            case XmlNodeType.EndElement: //Display the end of the element.
                                result += ("</" + reader.Name);
                                result += (">");
                                break;
                        }
                    }
                }       
            }

            return result;
        }
    }
}
