﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using AvScan.Core;
using AvScan.WindowsDefender;

namespace Esource.Utilities
{
    public static class Auth
    {
        public static string encrypt(string plaintext, byte[] IV)
        {
            byte[] cipherText = null;
            try
            {
                RijndaelManaged cipher = new RijndaelManaged();
                cipher.IV = IV;
                string rootPath = HttpContext.Current.Server.MapPath("~");
                string keyPath = Path.GetFullPath(Path.Combine(rootPath + "../../encryptKey.txt"));

                if (!File.Exists(keyPath))
                {
                    cipher.GenerateKey();
                    File.WriteAllText(keyPath, Convert.ToBase64String(cipher.Key));
                }
                string key = File.ReadAllText(keyPath);
                cipher.Key = Convert.FromBase64String(key);
                
                ICryptoTransform encryptTransform = cipher.CreateEncryptor();
                byte[] plainText = Encoding.UTF8.GetBytes(plaintext);
                cipherText = encryptTransform.TransformFinalBlock(plainText, 0, plainText.Length);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { }
            return Convert.ToBase64String(cipherText);
        }

        public static string decrypt(byte[] ciphertext, byte[] IV)
        {
            string plainText = null;

            try
            {
                RijndaelManaged cipher = new RijndaelManaged();
                cipher.IV = IV;
                string rootPath = HttpContext.Current.Server.MapPath("~");
                string keyPath = Path.GetFullPath(Path.Combine(rootPath + "../../encryptKey.txt"));

                string key = File.ReadAllText(keyPath);
                cipher.Key = Convert.FromBase64String(key);
                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptTransform = cipher.CreateDecryptor();

                using (MemoryStream msDecrypt = new MemoryStream(ciphertext))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptTransform, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plainText = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { }
            return plainText;
        }

        public static Tuple<string, string> hash(string password, string salt = "")
        {
            string finalHash;
            byte[] Key;
            byte[] IV;
            //Generate random "salt"
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] saltByte = new byte[8];

            //Fills array of bytes with a cryptographically strong sequence of random values.
            rng.GetBytes(saltByte);
            if (string.IsNullOrEmpty(salt))
            {
                salt = Convert.ToBase64String(saltByte);
            }
            
            SHA512Managed hashing = new SHA512Managed();

            string pwdWithSalt = password + salt;
            byte[] plainHash = hashing.ComputeHash(Encoding.UTF8.GetBytes(password));
            byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));

            finalHash = Convert.ToBase64String(hashWithSalt);

            RijndaelManaged cipher = new RijndaelManaged();
            cipher.GenerateKey();
            Key = cipher.Key;
            IV = cipher.IV;
            password = finalHash;

            return Tuple.Create(password, salt);
        }

        public static string generateToken()
        {
            Random random = new Random();
            byte[] buffer = new byte[20 / 2];
            random.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            return result;
        }

        public static bool scanFile(string filePath)
        {
            bool malware = true;
            string scannerLocation = @"C:\Program Files\Windows Defender\MpCmdRun.exe";
            var scanner = new WindowsDefenderScanner(scannerLocation);
            ScanResult result = scanner.Scan(filePath);
            if (result.ToString() == "ThreatFound")
            {
                malware = false;
            }

            return malware;
        }
    }
}