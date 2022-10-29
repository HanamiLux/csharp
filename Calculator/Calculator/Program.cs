namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int action;
            while (true)
            {
                double num, num2;
                Console.Clear();
                Console.WriteLine("Выберите операцию:\n" +
                   "1. Сложить 2 числа\n" +
                   "2. Вычесть первое из второго\n" +
                   "3. Перемножить два числа\n" +
                   "4. Разделить первое на второе\n" +
                   "5. Возвести в степень N первое число\n" +
                   "6. Найти квадратный корень из числа\n" +
                   "7. Найти 1 процент от числа\n" +
                   "8. Найти факториал из числа\n" +
                   "9. Выйти из программы");
                Console.WriteLine("Выберите операцию из выше указанных: ");
                try
                {
                    action = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("ВВЕДЕНО НЕ ЧИСЛО!!! \n" +
                        "Ввод, чтобы начать заново");
                    Console.ReadLine();
                    continue;
                }
                if (action > 9 || action < 1)
                {
                    Console.WriteLine("Выберите операцию из выше указанных: ");
                }
                else if (action == 9)
                {
                    Console.WriteLine("Программа завершает свою работу. Bye bye!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Введите число: ");

                    try
                    {
                        num = double.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("ВВЕДЕНО НЕ ЧИСЛО!!! \n" +
                            "Ввод, чтобы начать заново");
                        Console.ReadLine();
                        continue;
                    }
                    switch (action)
                    {
                        case 1:
                            Console.WriteLine("Введите 2ое число: ");
                            try
                            {
                                num2 = double.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("ВВЕДЕНО НЕ ЧИСЛО!!! \n" +
                                    "Ввод, чтобы начать заново");
                                Console.ReadLine();
                                continue;
                            }
                            Console.WriteLine(num + num2);
                            break;
                        case 2:
                            Console.WriteLine("Введите 2ое число: ");
                            try
                            {
                                num2 = double.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("ВВЕДЕНО НЕ ЧИСЛО!!! \n" +
                                    "Ввод, чтобы начать заново");
                                Console.ReadLine();
                                continue;
                            }
                            Console.WriteLine(num2 - num);
                            break;
                        case 3:
                            Console.WriteLine("Введите 2ое число: ");
                            try
                            {
                                num2 = double.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("ВВЕДЕНО НЕ ЧИСЛО!!! \n" +
                                    "Ввод, чтобы начать заново");
                                Console.ReadLine();
                                continue;
                            }
                            Console.WriteLine(num * num2);
                            break;
                        case 4:
                            Console.WriteLine("Введите 2ое число: ");
                            try
                            {
                                num2 = double.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("ВВЕДЕНО НЕ ЧИСЛО!!! \n" +
                                    "Ввод, чтобы начать заново");
                                Console.ReadLine();
                                continue;
                            }
                            if (num == 0)
                            {
                                Console.WriteLine("На ноль число не делится");
                            }
                            else
                            {
                                Console.WriteLine(num / num2);
                            }
                            break;
                        case 5:
                            Console.WriteLine("Введите степень N: ");
                            try
                            {
                                num2 = double.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("ВВЕДЕНО НЕ ЧИСЛО!!! \n" +
                                    "Ввод, чтобы начать заново");
                                Console.ReadLine();
                                continue;
                            }
                            Console.WriteLine(Math.Pow(num, num2));
                            break;
                        case 6:
                            Console.WriteLine(Math.Sqrt(num));
                            break;
                        case 7:
                            Console.WriteLine(num / 100);
                            break;
                        case 8:
                            if (num == 0)
                            {
                                Console.WriteLine(1);
                            }
                            else if (num<0)
                            {
                                Console.WriteLine("Факториал отрицательного числа не существует");
                            }    
                            else
                            {
                                int value = 1;
                                int value2 = 2;
                                for (int count = 1; count < num; count++)
                                {
                                    value *= value2;
                                    value2 += 1;
                                }
                                Console.WriteLine(value);
                            }
                            break;
                        default:
                            Console.WriteLine("Введите число от 1 до 9! ");
                            break;
                    }
                    Console.WriteLine("Ввод, чтобы начать заново ");
                    Console.ReadLine();
                }
            } 
        }
    }
}