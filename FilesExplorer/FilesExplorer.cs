using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesExplorer
{
    internal static class FilesExplorer
    {
        static private string DrivesMenu()
        {
            //Возвращает выбранный driver
            Console.WriteLine("\t\t\t\t\tЭтот компьютер\n============================================================================================================\n");
            DriveInfo[] allDrivesInfo = DriveInfo.GetDrives();
            int drivesNum = 0;
            foreach (DriveInfo drive in allDrivesInfo)
            {
                Console.Write("  Drive {0}", drive.Name);
                drivesNum++;
                if (drive.IsReady == true)
                {
                    Console.WriteLine("  Свободно {0} ГБ из {1} ГБ", drive.TotalFreeSpace / 1073741824, drive.TotalSize / 1073741824);
                }
            }
            ArrowMenu menu = new ArrowMenu(drivesNum+3,3);
            int chosenPosition = menu.Arrows()-3;
            return allDrivesInfo[chosenPosition].Name;
        }
        static private string FoldersMenu(string inputPath)
        {
            //Возвращает путь к папке
            Console.WriteLine("\t\t\t\t\t\t\tПапка\n==================================================================================================================");
            Console.WriteLine("  Название\t\t\t\t               Дата создания");
            string path = $"{inputPath}";
            List<string> allElements = new List <string>();
                var dirInfo = new DirectoryInfo(path);
            int filesNumber = 0;
            if (path.Contains("."))
                return path;
            string[] allDirectories = Directory.GetDirectories(path);
                string[] allFiles = Directory.GetFiles(path);
                allElements.AddRange(allDirectories);
                allElements.AddRange(allFiles);
                allElements.Sort();
                foreach (string elements in allElements)
                {
                    Console.WriteLine($"  {elements}");
                    Console.SetCursorPosition(90, filesNumber + 3);
                    Console.WriteLine($"  {dirInfo.CreationTime}");
                    filesNumber++;
                }
                Console.WriteLine($"\n\nЭлементов: {filesNumber}");
                ArrowMenu menu = new ArrowMenu(filesNumber + 3, 3);
                int chosenPosition = menu.Arrows() - 3;
            if (chosenPosition == -447)
            {
                Console.Clear();
                return string.Empty;
            }
                return FoldersMenu(allElements[chosenPosition]);
        }
        public static void MyComputer()
        {
            //Выполняет функцию проводника
            while (true)
            {
                StartPoint:
            string drive = DrivesMenu();
            string path = FoldersMenu(drive);
                Process.Start(new ProcessStartInfo { FileName = path, UseShellExecute = true });
                Console.Clear();
                goto StartPoint;
            } 
        }
    }
}
