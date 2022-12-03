using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TypingTest
{
    internal class TextTyping
    {
        const string text = ("Не следует, однако, забывать о том, что социально-экономическое развитие требует от нас системного анализа" +
                " ключевых компонентов планируемого обновления. Значимость этих проблем настолько очевидна, что новая модель организационной" +
                " деятельности в значительной степени обуславливает создание всесторонне сбалансированных нововведений. Равным образом курс" +
                " на социально-ориентированный национальный проект позволяет выполнить важнейшие задания по разработке всесторонне" +
                " сбалансированных нововведений.Значимость этих проблем настолько очевидна, что новая модель организационной" +
                " деятельности позволяет выполнить важнейшие задания по разработке модели развития. Дорогие друзья," +
                " выбранный нами инновационный путь напрямую зависит от всесторонне сбалансированных нововведений. Значимость этих" +
                " проблем настолько очевидна,");
        private static char[] symbolsArray;
        private static bool isTimerStopped = false;
        

        public static void Test()
        {
            while (true)
            {

            RecordsTable.SerializeRecords(betaTest());
            }
        }
        private static user betaTest()
        {
            ConsoleKey isContinue;
            StartPoint:
            string nickname = RecordsTable.TableAddNickname();
            Thread thread1 = new Thread(new ThreadStart(IsTimerGoing));
            thread1.Start();
            double[] symbolsData = Texting();
            //Надо закрыть поток
            
            var userData = new user(nickname, symbolsData[0], symbolsData[1]);
            
                Console.SetCursorPosition(26, 15);
                Console.WriteLine("Нажмите Enter, если хотите начать заново\nНажмите F1, если хотите посмотреть таблицу лидеров/занести свой результат в неё");
            SwitchPoint:
            isContinue = Console.ReadKey(true).Key;
            switch (isContinue)
            {
                case ConsoleKey.Enter:
                    goto StartPoint;
                case ConsoleKey.F1:
                    break;
                default:
                    goto SwitchPoint;
            }
            return userData;
        }
        private static void OutputText()
        {

            //Вывод белого текста (см. поле text).

                Console.SetCursorPosition(0,0);
                Console.WriteLine(text);
        }
        private static double[] Texting()
        {
            //Пользовательский ввод зелёного текста поверх белого хардкода из OutputText(); 
            
                OutputText();
                double symbols = InputText();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(26, 10);
            Console.WriteLine($"Тест окончен!");
            Console.SetCursorPosition(26, 11);
            Console.WriteLine($"Кол-во символов в секунду:{symbols / 60}");
            Console.SetCursorPosition(26, 12);
            Console.WriteLine($"Кол-во символов в минуту: {symbols}");
            var symbolsData = new double[2] {symbols/60, symbols};
            return symbolsData;

        }
        private static double InputText()
        {
            //Пользовательский ввод зелёного текста, если он совпадает с ранее написанным белым текстом. Возвращает кол-во правильно
            // введённых символов.
            double trueSymbols = 0;
            symbolsArray = text.ToCharArray(0, text.Length);
            char keyPressed;
                int str = 0, j = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    RepeatPoint:
                    if (isTimerStopped == true)
                    {
                    Console.SetCursorPosition(26, 14);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Нажмите ENTER, чтобы продолжить");
                    ConsoleKey isEnterPressed = Console.ReadKey().Key;
                    if (isEnterPressed == ConsoleKey.Enter)
                        goto EndPoint;
                    }
                    if (isTimerStopped == false)
                    {
                            keyPressed = Console.ReadKey(true).KeyChar;
                        if (keyPressed == symbolsArray[i])
                        {

                        //Фикс ошибки выхода текста за рамки окна консоли.

                            trueSymbols += 1;
                            try
                            {
                                Console.SetCursorPosition(i, str);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(text[i]);
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                if (j == 120)
                                    j = 0;
                                if (i % 120 == 0)
                                    str++;
                                Console.SetCursorPosition(j, str);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(keyPressed);
                                j++;
                            }
                        }
                        else
                        {
                            goto RepeatPoint;
                        }
                    }
                    else
                    {
                    goto RepeatPoint;
                }
            }  
                EndPoint:
            return trueSymbols;
        }
        private static void IsTimerGoing()
        {

            // Таймер на 1 минуту и вывод его на экран.

            
            var limit = new TimeSpan(0,1,0);
                 TimeSpan sw;
            var warning = new TimeSpan(0, 0, 50);
            var swLimit = new TimeSpan(0,0,0);
            do
            {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
                isTimerStopped = false;

                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(20, 20);
                Console.Write("                                                                   ");
                Console.SetCursorPosition(20, 20);
                sw = stopWatch.Elapsed;
                swLimit += sw;

                if (swLimit >= warning)
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"Времени прошло: {swLimit}");

            stopWatch.Stop();
            } while (swLimit<limit);
            isTimerStopped = true;
        }
    }
}
