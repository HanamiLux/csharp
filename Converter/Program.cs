using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Converter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey keyPressed;
            do
            {
                Conv.Converting();
                keyPressed = Console.ReadKey().Key;
            } while (keyPressed != ConsoleKey.Escape);
        }
    }
}