using System.Security.Cryptography;
using System.Text;
using System;
using System.IO;
namespace EmployeeManagementSystem.Data
{
    public class Encryption
    {
        public static string Encrpt(string raw)
        {
            using (AesCryptoServiceProvider csp = new AesCryptoServiceProvider())
            {
                byte[] keyByte = new byte[] { 0x2b, 0x7e, 0x15, 0x16, 0x28, 0xae, 0xd2, 0xa6, 0xab, 0xf7, 0x15, 0x88, 0x09, 0xcf, 0x4f, 0x3c }; ;
                byte[] ivByte = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
                csp.Key = keyByte;
                csp.IV = ivByte;
                byte[] encrypted;

                ICryptoTransform encryptor = csp.CreateEncryptor(csp.Key, csp.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(raw);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }

                return Convert.ToBase64String(encrypted);
            }
        }

        public static string Decrypt(string raw, string key)
        {
            byte[] ivByte = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            byte[] keyByte = Encoding.UTF8.GetBytes(key);
            byte[] rowByte = Encoding.UTF8.GetBytes(raw);
            byte[] decryptedBytes = null;
            using (AesCryptoServiceProvider csp = new AesCryptoServiceProvider())
            {
                csp.Key = keyByte;
                csp.IV = ivByte;
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, csp.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(rowByte, 0, rowByte.Length);
                        cs.FlushFinalBlock();
                        decryptedBytes = ms.ToArray();
                    }
                }
            }
            string decryptedString = Encoding.UTF8.GetString(decryptedBytes);
            return decryptedString;
        }
    }
}
