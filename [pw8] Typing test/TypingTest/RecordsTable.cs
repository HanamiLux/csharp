using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TypingTest
{
    internal static class RecordsTable
    {
        private static ConsoleKey isContinue;
        public static string TableAddNickname()
        {
            Console.Clear();
            Console.SetCursorPosition(2, 6);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Внимание! После ввода вашего ника сразу же начнётся тест! Вы сможете набирать текст.");
            Console.SetCursorPosition(2, 10);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("...ходили легенды о самой быстрой руке на диком западе. Его звали... (Введите ник): ");

            string nickname = Console.ReadLine();
            Console.SetCursorPosition(2, 10);
            Console.WriteLine("                                                                                                               ");
            return nickname;

        }
        public static void SerializeRecords(user userData)
        {
            List<user> recordsList = GetRecords();
            recordsList.Add(userData);

            string json = JsonConvert.SerializeObject(recordsList);
            File.WriteAllText($@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\Records.json", json);

            DeserializeRecords();
        }
        private static List<user> GetRecords()
        {
            if (!File.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\Records.json"))
            {
                var newList = new List<user>();
                string json = JsonConvert.SerializeObject(newList);
                File.Create($@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\Records.json").Close();
                File.WriteAllText($@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\Records.json", json);
            }
            string text = File.ReadAllText($@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\Records.json");
            List<user> records = JsonConvert.DeserializeObject<List<user>>(text);
            return records;
            
        }
        private static void DeserializeRecords()
        {
            List<user> records = GetRecords();
            List<user> sortedList = records.OrderByDescending(o => o.spm).ToList();
            Console.Clear();
            Console.SetCursorPosition(34, 5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ТАБЛИЦА ЛИДЕРОВ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(26, 6);
            Console.WriteLine("Nickname - symbols per second - symbols per minute ");
            foreach (var record in sortedList)
            {
                Console.WriteLine($"| {record.name} | {record.sps} | {record.spm} |");
            }
        SwitchPoint:
            Console.SetCursorPosition(26, 3);
            Console.WriteLine("Нажмите Enter, если хотите начать заново\nНажмите Escape, если хотите выйти");
            isContinue = Console.ReadKey(true).Key;
            switch (isContinue)
            {
                case ConsoleKey.Enter:
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    goto SwitchPoint;
            }
        }
    }
}
