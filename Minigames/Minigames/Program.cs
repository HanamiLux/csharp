using System;

namespace Minigames
{
    internal class Program
    {
        static string res = "";
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                int Action, num;
                Console.WriteLine("Выберите программу, которую вы хотите запустить\n" +
                "1. Угадай число\n" +
                "2. Таблица умножения\n" +
                "3. Вывод делителей числа\n" +
                "4. Выход из программы");
                while (!int.TryParse(Console.ReadLine(), out Action))
                {
                    Console.WriteLine("Ошибка, попробуйте снова");
                }
                switch (Action)
                {
                    case 1:
                        Console.WriteLine("Угадай число от 0 до 100: ");
                        while (!int.TryParse(Console.ReadLine(), out num))
                        {
                            Console.WriteLine("Ошибка, попробуйте снова");
                        }
                        if (num > 100 || num < 0)
                        {
                            Console.WriteLine("Ошибка, введите число в диапозоне от 0 до 100");
                        }
                        else
                        {
                            GuessTheNumberGame(num);
                            Console.WriteLine(res);
                        }
                        break;
                    case 2:
                        MultiplicationTable();
                        break;
                    case 3:
                        Console.WriteLine("Введите число");
                        while (!int.TryParse(Console.ReadLine(), out num))
                        {
                            Console.WriteLine("Ошибка, попробуйте снова");
                        }
                          Divisor(num); 
                        break;
                    case 4:
                        Console.WriteLine("Программа завершает свою работу. Bye bye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Введите число от 1 до 4! ");
                        break;
                        

                }
                Console.ReadLine();
            }
        }
        static void GuessTheNumberGame(int num)
        {
            int random;
            Random rnd = new();
            random = rnd.Next(0, 101);
            while (num != random)
            {
                if (random > num)
                {
                    Console.WriteLine("Введите число побольше");
                    while (!int.TryParse(Console.ReadLine(), out num))
                    {
                        Console.WriteLine("Ошибка, попробуйте снова");
                    }
                }
                else if (random < num)
                {
                    Console.WriteLine("Введите число поменьше");
                    while (!int.TryParse(Console.ReadLine(), out num))
                    {
                        Console.WriteLine("Ошибка, попробуйте снова");
                    }
                }

            }
            res = "Вы угадали!";
        }
        static int[,] MultiplicationTable()
        {
            int[,] table = new int[10, 10];
            int variable = 2;
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    table[i, j] = j*i;
                }
                Console.WriteLine();
            }
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {

                    Console.Write(table[i, j] + "\t");
                }
                Console.WriteLine();
            }
            return table;
        }
        static int Divisor(int num)
        {
            Console.WriteLine("Введите число");
            int rez = 1;
            for (; rez < 50; rez++)
            {
                if (num % rez == 0)
                {
                    Console.Write(rez + "\t");
                }
            }
            Console.WriteLine(num);
            return rez;
        }
    }
}