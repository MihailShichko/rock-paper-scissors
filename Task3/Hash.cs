using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Task3
{
    class Hash
    {
        public string Key { get; private set; }

        public string HMAC { get; private set;} 

        byte[] CreateKey()
        {
            byte[] key = new byte[32];
            var a = RandomNumberGenerator.Create();
            a.GetBytes(key);
            string keyString = string.Empty;
            foreach (byte x in key)
            {
                keyString += String.Format("{0:x2}", x);
            }

            this.Key = keyString;
            return key;
        }

        public void CalculateHMAC(string text)
        {

            HMACSHA256 hashObject = new HMACSHA256(this.CreateKey());
            var signature = hashObject.ComputeHash(Encoding.UTF8.GetBytes(text));
            var encodedSignature = Convert.ToBase64String(signature);
            this.HMAC = encodedSignature;
        }
    }
}
