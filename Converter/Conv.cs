using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Converter
{
    internal class Conv
    {
            static Figure rectangle = new Figure();
            static Figure quadrate = new Figure();
            static Figure rectangle2 = new Figure();
        public static void Converting()
        {
            point1:
            Console.Clear();
            Console.WriteLine("Открыть существующий файл - 1\nСоздать новый файл со своим названием - 2");
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.D1:
                    Reading();
                    break;
                case ConsoleKey.D2:
                    Creating();
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    goto point1;
                    break;
            }
            Console.WriteLine("НАЖМИТЕ ЛЮБУЮ КНОПКУ, ЧТОБЫ ПРОДОЛЖИТЬ\n ESCAPE, ЧТОБЫ ВЫЙТИ");
        }
        private static void Reading()
        {
            List<Figure> figuresListXml = new List<Figure>() { rectangle, quadrate, rectangle2 };
            Console.Clear();
            Console.WriteLine("Введите путь до файла, который хотите открыть (.txt/.xml/.json)");
            Console.WriteLine("<===========================================================>");
            string path = Console.ReadLine();
            if (path.Contains(".txt"))
            {
                string text = File.ReadAllText(path);
                Console.WriteLine(text);
            }
            if (path.Contains(".xml"))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Figure>));
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    figuresListXml = (List<Figure>)xml.Deserialize(fs);
                }
                foreach (var figure in figuresListXml)
                {
                    Console.WriteLine($"{figure.name}\n{figure.height}\n{figure.width}\n");
                }
            }
            if (path.Contains(".json"))
            {
                string jsonText = File.ReadAllText(path);
                List<Figure> figuresListJson = JsonConvert.DeserializeObject<List<Figure>>(jsonText);
                foreach (var figure in figuresListJson)
                {
                    Console.WriteLine($"{figure.name}\n{figure.height}\n{figure.width}\n");
                }
            }
        }
        private static void Creating()
        {
            rectangle.name = "Rectangle";
            rectangle.height = 10;
            rectangle.width = 5;
            quadrate.name = "Quadrate";
            quadrate.height = 10;
            quadrate.width = 10;
            rectangle2.name = "Rectangle2";
            rectangle2.height = 8;
            rectangle2.width = 4;
            List<Figure> figuresList = new List<Figure>() { rectangle, quadrate, rectangle2 };
            Console.Clear();
            Console.WriteLine("Введите путь до файла, который хотите создать (.txt/.xml/.json)");
            Console.WriteLine("<===========================================================>");
            string path = Console.ReadLine();
            string text = $"{rectangle.name}\n{rectangle.height}\n{rectangle.width}\n" +
                    $"{rectangle2.name}\n{rectangle2.height}\n{rectangle2.width}\n" +
                    $"{quadrate.name}\n{quadrate.height}\n{quadrate.width}";
            if (path.Contains(".txt"))
            {
                File.Create(path).Close();
                File.WriteAllText(path, text);
            }
            if (path.Contains(".xml"))
            {
                
                XmlSerializer xml = new XmlSerializer(typeof(List<Figure>));
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                xml.Serialize(fs, figuresList);
                }
            }
            if (path.Contains(".json"))
            {
                File.Create(path).Close();
                string json = JsonConvert.SerializeObject(figuresList);
                File.WriteAllText(path, json);
            }
        }
    }
}
