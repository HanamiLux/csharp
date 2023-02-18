using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Documents;

namespace Diary
{
    public static class MyJSON
    {
        static string variable = "DiaryData";
        static string path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\{variable}";

        public static void Serialization<T>(List<T> serializableList)
        {
            string json = JsonConvert.SerializeObject(serializableList);
            File.WriteAllText(path, json);
        }

        public static List<T> Deserialization<T>(List<T> list )
        {
            if (!File.Exists(path))
                Serialization(list);
            string json = File.ReadAllText(path);
            List<T> serializedList = JsonConvert.DeserializeObject<List<T>>(json);
            return serializedList;
        }
    }
}
