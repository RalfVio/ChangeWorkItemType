using AzureDevOps_ChangeWorkItemType.Rest.BusinessObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AzureDevOps_ChangeWorkItemType.Configuration
{
    public class LocalConfig: ConnectionData
    {
        public string Query { get; set; }

        public static LocalConfig ReadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                return null;

            using StreamReader file = File.OpenText(filePath);
            JsonSerializer serializer = new JsonSerializer();
            var result = (LocalConfig)serializer.Deserialize(file, typeof(LocalConfig));

            // Decrypt PAT
            try
            {
                var decryptedPAT = DecryptString(result.PersonalAccessToken);
                result.PersonalAccessToken = decryptedPAT;
            }
            catch { result.PersonalAccessToken = string.Empty; }

            return result;

        }
        public void WriteToFile(string filePath)
        {
            // Encrypt PAT
            var encryptedPAT = EncryptString(PersonalAccessToken);
            PersonalAccessToken = encryptedPAT;

            var json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(filePath, json, Encoding.UTF8);
        }

        private static readonly byte[] _pbOptEnt = { 0xC1, 0x48, 0x9B, 0xAA };

        public static string EncryptString(string plainText)
        {
            if (string.IsNullOrEmpty(plainText)) return string.Empty;

            byte[] plainBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedBytes = ProtectedData.Protect(plainBytes, _pbOptEnt,
                DataProtectionScope.CurrentUser);

            return BitConverter.ToString(encryptedBytes).Replace("-", "");
        }
        public static string DecryptString(string encryptedText)
        {
            if (string.IsNullOrEmpty(encryptedText)) return string.Empty;
            byte[] encryptedBytes = new byte[encryptedText.Length/2];
            for (int i = 0; i < encryptedBytes.GetLength(0); i++)
                encryptedBytes[i]=Convert.ToByte(encryptedText.Substring(2*i,2),16);
            byte[] plainBytes = ProtectedData.Unprotect(encryptedBytes, _pbOptEnt,
                DataProtectionScope.CurrentUser);
            
            return System.Text.Encoding.UTF8.GetString(plainBytes);
        }
    }
}
