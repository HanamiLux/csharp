using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{

    internal class Program
    {
        static DateTime fulldate = DateTime.Now;
        static List<Notes> Notices = new List<Notes>
        {
            new Notes(){name = "День рождения собаки",description = "Пёс вылупился. Надо поздравить!", date = fulldate.AddDays(2).Day},
            new Notes(){name = "Cходить в шаражку",description = "А так неахота", date = fulldate.AddDays(1).Day},
            new Notes(){name = "Учить пайтон",description = "Слишком странный язык программирования", date = fulldate.AddDays(1).Day},
            new Notes(){name = "Учить c#",description = "Ещё 10 часов жёсткого обучения..", date = fulldate.Day},
            new Notes(){name = "Сдать практические работы",description = "Ну это на часов 27...", date = fulldate.Day}
        };
        static int paragraph = 1;
        static void Main(string[] args)
        {
            ConsoleKey key = ConsoleKey.A;
            while (true)
            {
                Console.WriteLine("НАЖМИТЕ ЛЮБУЮ КНОПКУ, ЧТОБЫ ЗАПУСТИТЬ ЕЖЕДНЕВНИК" +
                    "\nНАЖМИТЕ Z, ЕСЛИ ХОТИТЕ ВЫЙТИ");
                key = Console.ReadKey(true).Key;
                Console.Clear();
                while (key != ConsoleKey.Z)
               {
                 DateTime fulldate = DayChanging();
                 Memo(fulldate);
                    Console.WriteLine("НАЖМИТЕ Z, ЕСЛИ ХОТИТЕ ВЫЙТИ");
                 key = Console.ReadKey(true).Key;
               }
                 Environment.Exit(0);
            }
        }
        static DateTime DayChanging()
        { 
            Console.WriteLine(fulldate + "\n<=====НАЖМИТЕ ENTER, ЧТОБЫ ВЫБРАТЬ ЭТУ ДАТУ=====>");
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                Console.Clear();
                if (key !=ConsoleKey.LeftArrow && key != ConsoleKey.RightArrow)
                {
                    Console.WriteLine($"{fulldate} \n<=====НАЖМИТЕ ENTER, ЧТОБЫ ВЫБРАТЬ ЭТУ ДАТУ=====>");
                }
                if (key == ConsoleKey.LeftArrow)
                {
                    fulldate = fulldate.AddDays(-1);
                    Console.WriteLine($"{fulldate} \n<=====НАЖМИТЕ ENTER, ЧТОБЫ ВЫБРАТЬ ЭТУ ДАТУ=====>");
                }
                else if (key == ConsoleKey.RightArrow)
                {
                    fulldate = fulldate.AddDays(1);
                    Console.WriteLine($"{fulldate} \n<=====НАЖМИТЕ ENTER, ЧТОБЫ ВЫБРАТЬ ЭТУ ДАТУ=====>");
                }
            }
            while (key != ConsoleKey.Enter);
            return fulldate;
        }
        static void Memo(DateTime fulldate)
        {
            string mark = $"{paragraph}>";
            ConsoleKey keyPressed = ConsoleKey.A;
            int day = fulldate.Day;
            do
            {
                    Console.Clear();
                    Console.WriteLine(fulldate + "\n <===========================================>");
                    Console.WriteLine("Выберите событие:");
                Console.SetCursorPosition(0, paragraph + 2);
                Console.Write(mark + " ");
                int id = 3;
                    foreach (var notice in Notices)
                    {
                        Console.SetCursorPosition(0, id);
                        if (notice.date == day)
                        {
                            id++;
                            Console.WriteLine("\t" + notice.name);
                        }
                    }
                    keyPressed = Console.ReadKey().Key;
                    Console.Clear();
                    if (keyPressed == ConsoleKey.UpArrow)
                    {
                        paragraph--;
                        if (paragraph < 1)
                        {
                            paragraph = 5;
                        }
                    }
                    else if (keyPressed == ConsoleKey.DownArrow)
                    {
                        paragraph++;
                        if (paragraph > 5)
                        {
                        paragraph = 1;
                        }

                    }
                    mark = $"{paragraph}>";
                Console.SetCursorPosition(0, paragraph + 2);
                Console.Write(mark + " "); 
            }
            while (keyPressed != ConsoleKey.Enter);
            if (keyPressed == ConsoleKey.Enter)
            {
                List<Notes> thisDay = new List<Notes>();
                thisDay = Notices.Where(i => i.date == day).ToList();
                Console.WriteLine(thisDay[paragraph-1].description);
            }
        }     
    }
}