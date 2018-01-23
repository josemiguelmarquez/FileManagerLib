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
    public class XMLReader : IReader, ICryptoReader
    {
        private IRoleProvider _roleProvider;
        private IEncryptor _encryptor;

        /// <summary>
        /// Constructor that enables DI
        /// </summary>
        /// <param name="roleProvider">Role provider selected</param>
        /// /// <param name="encryptor">the cryptographer selected</param>
        public XMLReader(IRoleProvider roleProvider, IEncryptor encryptor)
        {
            this._roleProvider = roleProvider;
            this._encryptor = encryptor;
        }

        public string Read(string filePath)
        {
            string result = string.Empty;

            // Check correct path
            if (File.Exists(filePath) && (filePath.EndsWith(".xml")))
            {
                // Role base security for the XML reading logic
                if (_roleProvider.CanReadXMLFile(filePath))
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
            }

            return result;
        }

        public string Read(string filePath, bool encryptedText)
        {
            string result = string.Empty;

            // Check correct path
            if (File.Exists(filePath) && (filePath.EndsWith(".xml")))
            {
                // Role base security for the XML reading logic
                if (_roleProvider.CanReadXMLFile(filePath))
                {
                    using (XmlTextReader reader = new XmlTextReader(filePath))
                    {
                        while (reader.Read())
                        {
                            switch (reader.NodeType)
                            {
                                case XmlNodeType.Element: // The node is an element.
                                    result += (!encryptedText ? ("<" + reader.Name) : _encryptor.Decrypt("<" + reader.Name));
                                    result += (!encryptedText ? (">") : _encryptor.Decrypt(">")); 
                                    break;
                                case XmlNodeType.Text: //Display the text in each element.
                                    result += (!encryptedText ? (reader.Value) : _encryptor.Decrypt(reader.Value)); 
                                    break;
                                case XmlNodeType.EndElement: //Display the end of the element.
                                    result += (!encryptedText ? ("</" + reader.Name) : _encryptor.Decrypt("</" + reader.Name)); 
                                    result += (!encryptedText ? (">") : _encryptor.Decrypt(">")); 
                                    break;
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
