using AzureDevOps_ChangeWorkItemType.Rest.BusinessObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            return result;

        }
        public void WriteToFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(filePath, json, Encoding.UTF8);
        }
    }
}
