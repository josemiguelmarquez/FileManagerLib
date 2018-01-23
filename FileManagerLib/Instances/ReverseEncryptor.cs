using FileManagerLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerLib.Instances
{
    public class ReverseEncryptor : IEncryptor
    {
        /// <summary>
        /// Reverse the input
        /// </summary>
        /// <param name="input">data to encrypt</param>
        /// <returns>encrypted data</returns>
        public string Encrypt(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// Reverse of the input
        /// </summary>
        /// <param name="input">data to decrypt</param>
        /// <returns>decrypted data</returns>
        public string Decrypt(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
