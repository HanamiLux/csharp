using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace IS5
{
    public static class MyJSON
    {

        public static T Deserialization<T>()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog() == true)
            {
                string json = File.ReadAllText(dialog.FileName);
                T deserialized = JsonConvert.DeserializeObject<T>(json);
                return deserialized;
            }
            else
                return default;

        }
    }
}
