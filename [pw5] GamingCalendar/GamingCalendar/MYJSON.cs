using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace GamingCalendar
{
    public static class MyJSON
    {
        static string variable = "dayInfos.json";
        static string path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\days selection\{variable}";

        public static void Serialization<T>(List<T> serializableList)
        {
            string json = JsonConvert.SerializeObject(serializableList);
            if(!File.Exists(path))
                Directory.CreateDirectory(@$"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\days selection");
            File.WriteAllText(path, json);
        }

        public static List<T> Deserialization<T>()
        {
            List<T> serializedList = new List<T>();
            if (!File.Exists(path))
                return serializedList;
            string json = File.ReadAllText(path);
            serializedList = JsonConvert.DeserializeObject<List<T>>(json);
            return serializedList;
        }
    }
}
