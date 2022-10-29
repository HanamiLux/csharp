using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cakes
{
    internal class Cakes
    {
        //FORM:
        static Option smallForm = new Option("Квадрат", 0, 200);
        static Option mediumForm = new Option("Круг", 1, 300);
        static Option bigForm = new Option("Треугольник", 2, 444);
        static List<Option> forms = new List<Option>() { smallForm, mediumForm, bigForm };
        static List<string> SubMenu1 = new List<string>() { smallForm.option, mediumForm.option, bigForm.option };
        //SIZE:
        static Option smallSize = new Option("Маленький (18 см)", 0, 200);
        static Option mediumSize = new Option("Средний (24 см)", 1, 300);
        static Option bigSize = new Option("Большой (30 см)", 2, 444);
        static List<Option> size = new List<Option>() { smallSize, mediumSize, bigSize };
        static List<string> SubMenu2 = new List<string>() { smallSize.option, mediumSize.option, bigSize.option };
        //TASTEOFSHORTBREADS:
        static Option vanillaTaste = new Option("Ванильный", 0, 200);
        static Option berryTaste = new Option("Ягодный", 1, 300);
        static Option chocolateTaste = new Option("Шоколадный", 2, 444);
        static List<Option> taste = new List<Option>() { vanillaTaste, berryTaste, chocolateTaste };
        static List<string> SubMenu3 = new List<string>() { vanillaTaste.option, berryTaste.option, chocolateTaste.option };
        //AMOUNTOFSHORTBREADS:
        static Option one = new Option("1 корж", 0, 200);
        static Option two = new Option("2 коржа", 1, 300);
        static Option four = new Option("3 коржа", 2, 444);
        static List<Option> amount = new List<Option>() { one, two, four };
        static List<string> SubMenu4 = new List<string>() { one.option, two.option, four.option };
        //GLAZE:
        static Option caramelGlaze = new Option("Карамельная глазурь", 0, 200);
        static Option vanillaGlaze = new Option("Ванильная глазурь", 1, 300);
        static Option chocolateGlaze = new Option("Шоколадная глазурь", 2, 444);
        static List<Option> glaze = new List<Option>() { caramelGlaze, vanillaGlaze, chocolateGlaze };
        static List<string> SubMenu5 = new List<string>() { caramelGlaze.option, vanillaGlaze.option, chocolateGlaze.option };
        //DECORATION:
        static Option chocolateDecor = new Option("Шоколадный декор", 0, 200);
        static Option berryDecor = new Option("Ягодный декор", 1, 300);
        static Option caramelDecor = new Option("Карамельный декор", 2, 444);
        static List<Option> decor = new List<Option>() { chocolateDecor, berryDecor, caramelDecor };
        static List<string> subMenu6 = new List<string>() { chocolateDecor.option, berryDecor.option, caramelDecor.option };
        //Создание элементов главного меню:
        static MainMenu menu1 = new MainMenu("Форма какиса", forms, 0);
        static MainMenu menu2 = new MainMenu("Размер какиса", size, 1);
        static MainMenu menu3 = new MainMenu("Вкус коржиков", taste, 2);
        static MainMenu menu4 = new MainMenu("Количество коржиков", amount, 3);
        static MainMenu menu5 = new MainMenu("Глазурь", glaze, 4);
        static MainMenu menu6 = new MainMenu("Декор", decor, 5);
        static MainMenu menu7 = new MainMenu("Конец заказа", null, 6);
        static List<string> allMenus = new List<string>() { menu1.title, menu2.title, menu3.title, menu4.title, menu5.title, menu6.title, menu7.title };
        static int mainMenuId = 0;
        static string logsPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\CakesLogs.txt";
        static int sum;
        static List<string> order = new List<string>();

        public static void Menu()
        {
            var file = File.Create(logsPath);
            file.Close();
            PrintInterface();
        }

        private static void PrintInterface()
        {
            Point1:
            string mark = "e===8";
            ConsoleKey keyPressed = ConsoleKey.M;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("WELCUM TO THE KAKES MARKET!");
            Console.Write("===========");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("===========");
            Console.WriteLine("Выберите параметры своего какиса: ");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(menu1.title +"  " + mark);
            Console.WriteLine(menu2.title);
            Console.WriteLine(menu3.title);
            Console.WriteLine(menu4.title);
            Console.WriteLine(menu5.title);
            Console.WriteLine(menu6.title);
            Console.WriteLine(menu7.title);
            Console.WriteLine("<=========>");
            Console.WriteLine($"Сумма заказа: {sum} ");
            Console.Write("Ваш заказ: ");
            foreach (string item in order)
            {
                Console.Write(item + " ");
            }

        Point:
            while (keyPressed != ConsoleKey.Enter)
            {
                keyPressed = Console.ReadKey(true).Key;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("WELCUM TO THE KAKES MARKET!");
                Console.Write("===========");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("===========");
                Console.WriteLine("Выберите параметры своего какиса: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(menu1.title);
                Console.WriteLine(menu2.title);
                Console.WriteLine(menu3.title);
                Console.WriteLine(menu4.title);
                Console.WriteLine(menu5.title);
                Console.WriteLine(menu6.title);
                Console.WriteLine(menu7.title);
                Console.WriteLine("<=========>");
                Console.WriteLine($"Сумма заказа: {sum} ");
                Console.Write("Ваш заказ: ");
                foreach (string item in order)
                {
                    Console.Write(item + " ");
                }
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    mainMenuId--;
                    if (mainMenuId < 0)
                        mainMenuId = 6;
                }
                if (keyPressed == ConsoleKey.DownArrow)
                {
                    mainMenuId++;
                    if (mainMenuId > 6)
                        mainMenuId = 0;
                }
                Console.SetCursorPosition(allMenus[mainMenuId].Length+2, mainMenuId+3);
                Console.Write(mark);
            }
            if (keyPressed == ConsoleKey.Enter)
            {
                
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("WELCUM TO THE KAKES MARKET!");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("======================");
                Console.ForegroundColor = ConsoleColor.White;
                keyPressed = ConsoleKey.M;
                switch (mainMenuId)
                {
                    case 0:
                        mainMenuId = 0;
                        foreach (Option item in forms)
                        {
                            Console.WriteLine(item.option + "   " + item.cost);
                        }
                        while (keyPressed != ConsoleKey.Enter)
                        {
                            keyPressed = Console.ReadKey(true).Key;
                            Console.Clear();
                            foreach (Option item in forms)
                            {
                                Console.WriteLine(item.option + "   " + item.cost);
                            }
                            Console.SetCursorPosition(SubMenu1[mainMenuId].Length + 8, mainMenuId);
                            Console.Write(mark);

                            if (keyPressed == ConsoleKey.UpArrow)
                            {
                                mainMenuId--;
                                if (mainMenuId < 0)
                                    mainMenuId = 2;
                            }
                            if (keyPressed == ConsoleKey.DownArrow)
                            {
                                mainMenuId++;
                                if (mainMenuId > 2)
                                    mainMenuId = 0;
                            }
                            if (keyPressed == ConsoleKey.Escape)
                            {
                                goto Point;
                            }
                        }
                        if (keyPressed == ConsoleKey.Enter)
                        {
                            mainMenuId -= 1;
                            switch (mainMenuId)
                            {
                                case 0:
                                    File.AppendAllText(logsPath, smallForm.option + " - " + $"{smallForm.cost}\n");
                                    sum += smallForm.cost;
                                    order.Add(smallForm.option + " - " + $"{smallForm.cost}|");
                                    break;
                                case 1:
                                    File.AppendAllText(logsPath, $"{mediumForm.option}" + " - " + $"{mediumForm.cost}\n");
                                    sum += mediumForm.cost;
                                    order.Add(mediumForm.option + " - " + $"{mediumForm.cost}|");
                                    break;
                                case 2:
                                    File.AppendAllText(logsPath, bigForm.option + " - " + $"{bigForm.cost}\n");
                                    sum += bigForm.cost;
                                    order.Add(bigForm.option + " - " + $"{bigForm.cost}|");
                                    break;
                            }
                            goto Point1;
                        }
                        break;
                    case 1:
                        mainMenuId = 0;
                        foreach (Option item in size)
                        {
                            Console.WriteLine(item.option + " - " + item.cost);
                        }
                        while (keyPressed != ConsoleKey.Enter)
                        {
                            keyPressed = Console.ReadKey(true).Key;
                            Console.Clear();

                            foreach (Option item in size)
                            {
                                Console.WriteLine(item.option + " - " + item.cost);
                            }
                            Console.SetCursorPosition(SubMenu2[mainMenuId].Length + 8, mainMenuId);
                            Console.Write(mark);

                            if (keyPressed == ConsoleKey.UpArrow)
                            {
                                mainMenuId--;
                                if (mainMenuId < 0)
                                    mainMenuId = 2;
                            }
                            if (keyPressed == ConsoleKey.DownArrow)
                            {
                                mainMenuId++;
                                if (mainMenuId > 2)
                                    mainMenuId = 0;
                            }
                            if (keyPressed == ConsoleKey.Escape)
                            {
                                goto Point;
                            }
                        }
                        if (keyPressed == ConsoleKey.Enter)
                        {
                            mainMenuId -= 1;
                            switch (mainMenuId)
                            {
                                case 0:
                                    File.AppendAllText(logsPath, smallSize.option + " - " + $"{smallSize.cost}\n");
                                    sum += smallSize.cost;
                                    order.Add(smallSize.option + " - " + $"{smallSize.cost}|");
                                    break;
                                case 1:
                                    File.AppendAllText(logsPath, mediumSize.option + " - " + $"{mediumSize.cost}\n");
                                    sum += mediumSize.cost;
                                    order.Add(mediumSize.option + " - " + $"{mediumSize.cost}|");
                                    break;
                                case 2:
                                    File.AppendAllText(logsPath, bigSize.option + " - " + $"{bigSize.cost}\n");
                                    sum += bigSize.cost;
                                    order.Add(bigSize.option + " - " + $"{bigSize.cost}|");
                                    break;
                            }
                            goto Point1;
                        }
                        break;
                    case 2:
                        mainMenuId = 0;
                        foreach (Option item in taste)
                        {
                            Console.WriteLine(item.option + " - " + item.cost);
                        }
                        while (keyPressed != ConsoleKey.Enter)
                        {
                            keyPressed = Console.ReadKey(true).Key;
                            Console.Clear();

                            foreach (Option item in taste)
                            {
                                Console.WriteLine(item.option + " - " + item.cost);
                            }
                            Console.SetCursorPosition(SubMenu3[mainMenuId].Length + 8, mainMenuId);
                            Console.Write(mark);

                            if (keyPressed == ConsoleKey.UpArrow)
                            {
                                mainMenuId--;
                                if (mainMenuId < 0)
                                    mainMenuId = 2;
                            }
                            if (keyPressed == ConsoleKey.DownArrow)
                            {
                                mainMenuId++;
                                if (mainMenuId > 2)
                                    mainMenuId = 0;
                            }
                            if (keyPressed == ConsoleKey.Escape)
                            {
                                goto Point;
                            }
                        }
                        if (keyPressed == ConsoleKey.Enter)
                        {
                            mainMenuId -= 1;
                            switch (mainMenuId)
                            {
                                case 0:
                                    File.AppendAllText(logsPath, vanillaTaste.option + " - " + $"{vanillaTaste.cost}\n");
                                    sum += vanillaTaste.cost;
                                    order.Add(vanillaTaste.option + " - " + $"{vanillaTaste.cost}|");
                                    break;
                                case 1:
                                    File.AppendAllText(logsPath, berryTaste.option + " - " + $"{berryTaste.cost}\n");
                                    sum += berryTaste.cost;
                                    order.Add(berryTaste.option + " - " + $"{berryTaste.cost}|");
                                    break;
                                case 2:
                                    File.AppendAllText(logsPath, chocolateTaste.option + " - " + $"{chocolateTaste.cost}\n");
                                    sum += chocolateTaste.cost;
                                    order.Add(chocolateTaste.option + " - " + $"{chocolateTaste.cost}|");
                                    break;
                            }
                            goto Point1;
                        }
                        break;
                    case 3:
                        mainMenuId = 0;
                        foreach (Option item in amount)
                        {
                            Console.WriteLine(item.option + " - " + item.cost);
                        }
                        while (keyPressed != ConsoleKey.Enter)
                        {
                            keyPressed = Console.ReadKey(true).Key;
                            Console.Clear();

                            foreach (Option item in amount)
                            {
                                Console.WriteLine(item.option + " - " + item.cost);
                            }
                            Console.SetCursorPosition(SubMenu4[mainMenuId].Length + 8, mainMenuId);
                            Console.Write(mark);

                            if (keyPressed == ConsoleKey.UpArrow)
                            {
                                mainMenuId--;
                                if (mainMenuId < 0)
                                    mainMenuId = 2;
                            }
                            if (keyPressed == ConsoleKey.DownArrow)
                            {
                                mainMenuId++;
                                if (mainMenuId > 2)
                                    mainMenuId = 0;
                            }
                            if (keyPressed == ConsoleKey.Escape)
                            {
                                goto Point;
                            }
                        }
                        if (keyPressed == ConsoleKey.Enter)
                        {
                            mainMenuId -= 1;
                            switch (mainMenuId)
                            {
                                case 0:
                                    File.AppendAllText(logsPath, one.option + " - " + $"{one.cost}\n");
                                    sum += one.cost;
                                    order.Add(one.option + " - " + $"{one.cost}|");
                                    break;
                                case 1:
                                    File.AppendAllText(logsPath, two.option + " - " + $"{two.cost}\n");
                                    sum += two.cost;
                                    order.Add(two.option + " - " + $"{two.cost}|");
                                    break;
                                case 2:
                                    File.AppendAllText(logsPath, four.option + " - " + $"{four.cost}\n");
                                    sum += four.cost;
                                    order.Add(four.option + " - " + $"{four.cost}|");
                                    break;
                            }
                            goto Point1;
                        }
                        break;
                    case 4:
                        mainMenuId = 0;
                        foreach (Option item in glaze)
                        {
                            Console.WriteLine(item.option + " - " + item.cost);
                        }
                        while (keyPressed != ConsoleKey.Enter)
                        {
                            keyPressed = Console.ReadKey(true).Key;
                            Console.Clear();

                            foreach (Option item in glaze)
                            {
                                Console.WriteLine(item.option + " - " + item.cost);
                            }
                            Console.SetCursorPosition(SubMenu5[mainMenuId].Length + 8, mainMenuId);
                            Console.Write(mark);

                            if (keyPressed == ConsoleKey.UpArrow)
                            {
                                mainMenuId--;
                                if (mainMenuId < 0)
                                    mainMenuId = 2;
                            }
                            if (keyPressed == ConsoleKey.DownArrow)
                            {
                                mainMenuId++;
                                if (mainMenuId > 2)
                                    mainMenuId = 0;
                            }
                            if (keyPressed == ConsoleKey.Escape)
                            {
                                goto Point;
                            }
                        }
                        if (keyPressed == ConsoleKey.Enter)
                        {
                            mainMenuId -= 1;
                            switch (mainMenuId)
                            {
                                case 0:
                                    File.AppendAllText(logsPath, caramelGlaze.option + " - " + $"{caramelGlaze.cost}\n");
                                    sum += caramelGlaze.cost;
                                    order.Add(caramelGlaze.option + " - " + $"{caramelGlaze.cost}|");
                                    break;
                                case 1:
                                    File.AppendAllText(logsPath, vanillaGlaze.option + " - " + $"{vanillaGlaze.cost}\n");
                                    sum += vanillaGlaze.cost;
                                    order.Add(vanillaGlaze.option + " - " + $"{vanillaGlaze.cost}|");
                                    break;
                                case 2:
                                    File.AppendAllText(logsPath, chocolateGlaze.option + " - " + $"{chocolateGlaze.cost}\n");
                                    sum += chocolateGlaze.cost;
                                    order.Add(chocolateGlaze.option + " - " + $"{chocolateGlaze.cost}|");
                                    break;
                            }
                                    goto Point1;
                        }
                        break;
                    case 5:
                        mainMenuId = 0;
                        foreach (Option item in decor)
                        {
                            Console.WriteLine(item.option + " - " + item.cost);
                        }
                        while (keyPressed != ConsoleKey.Enter)
                        {
                            keyPressed = Console.ReadKey(true).Key;
                            Console.Clear();

                            foreach (Option item in decor)
                            {
                                Console.WriteLine(item.option + " - " + item.cost);
                            }
                            Console.SetCursorPosition(subMenu6[mainMenuId].Length + 8, mainMenuId);
                            Console.Write(mark);

                            if (keyPressed == ConsoleKey.UpArrow)
                            {
                                mainMenuId--;
                                if (mainMenuId < 0)
                                    mainMenuId = 2;
                            }
                            if (keyPressed == ConsoleKey.DownArrow)
                            {
                                mainMenuId++;
                                if (mainMenuId > 2)
                                    mainMenuId = 0;
                            }
                            if (keyPressed == ConsoleKey.Escape)
                            {
                                goto Point;
                            }
                        }
                        if (keyPressed == ConsoleKey.Enter)
                        {
                            mainMenuId -= 1;
                            switch (mainMenuId)
                            {
                                case 0:
                                    File.AppendAllText(logsPath, chocolateDecor.option + " - " + $"{chocolateDecor.cost}\n");
                                    sum += chocolateDecor.cost;
                                    order.Add(chocolateDecor.option + " - " + $"{chocolateDecor.cost}|");
                                    break;
                                case 1:
                                    File.AppendAllText(logsPath, berryDecor.option + " - " + $"{berryDecor.cost}\n");
                                    sum += berryDecor.cost;
                                    order.Add(berryDecor.option + " - " + $"{berryDecor.cost}|");
                                    break;
                                case 2:
                                    File.AppendAllText(logsPath, caramelDecor.option + " - " + $"{caramelDecor.cost}\n");
                                    sum += caramelDecor.cost;
                                    order.Add(caramelDecor.option + " - " + $"{caramelDecor.cost}|");
                                    break;
                            }
                            goto Point1;
                        }
                            break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine($"Итоговая сумма: {sum}\n");
                        Console.WriteLine("<===================================>");
                        Console.WriteLine("Нажмите Esc, если хотите продолжить заказывать...");
                        ConsoleKey key = Console.ReadKey().Key;
                        Console.ForegroundColor = ConsoleColor.Red;
                        if (key != ConsoleKey.Escape)
                        {
                            File.AppendAllText(logsPath,"<=============>\n" + $"Итоговая сумма: {sum}\n {DateTime.Now}\n");
                        Console.WriteLine("\n\n\n\t\t\tSAYOUNARA!");
                            Environment.Exit(0);
                        }
                        goto Point1;
                    default:
                        break;
                }
            }
        }
    }
}
