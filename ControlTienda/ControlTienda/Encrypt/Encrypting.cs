

namespace ControlTienda.Encrypt
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class Encrypting
    {
        public string GetSHA256(string pass)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream;
            StringBuilder builder = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(pass));
            for (int i = 0; i < stream.Length; i++)
                builder.AppendFormat("{0:x2}", stream[i]);
            return builder.ToString();

        }
    }
}
