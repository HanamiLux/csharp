namespace Piano
{
    internal class Program
    {
        static int[] firstOctave = { 65, 69, 73, 77, 82, 87, 92, 98, 103, 110, 116, 123 };
        static int[] secondOctave = { 130, 138, 146, 155, 164, 174, 185, 196, 207, 220, 233, 246 };
        static int[] thirdOctave = { 261, 277, 293, 311, 329, 349, 370, 392, 415, 440, 466, 493 };
        static int[] fourthOctave = { 523, 554, 587, 622, 659, 698, 740, 784, 830, 880, 932, 987 };
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите октаву: double tap \"F1\"/\"F2\"/\"F3\"/\"F4 \n" +
                    "Клавиши: D-R-F-T-G-H-U-J-I-K-L ");
                int[] rezult = Octave();
            while (true)
            {
                    if (rezult == firstOctave)
                    {
                        Console.WriteLine("Выбрана первая октава:");
                        rezult = mySound(rezult);
                    }
                    else if (rezult == secondOctave)
                    {
                        Console.WriteLine("Выбрана вторая октава:");
                        rezult = mySound(rezult);
                    }
                    else if (rezult == thirdOctave)
                    {
                        Console.WriteLine("Выбрана третья октава:");
                        rezult = mySound(rezult);
                    }
                    else if (rezult == fourthOctave)
                    {
                        Console.WriteLine("Выбрана четвёртая октава:");
                        rezult = mySound(rezult);
                    }
                    else if (rezult == null)
                    {
                        rezult = Octave();
                    }
            }
            static int[] Octave()
            {
                int[] argument = new int[12];
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.F1)
                {
                    Console.WriteLine("Первая октава:");
                    argument = firstOctave;
                    return argument;
                }
                else if (key.Key == ConsoleKey.F2)
                {
                    Console.WriteLine("Вторая октава:");
                    argument = secondOctave;
                    return argument;
                }
                else if (key.Key == ConsoleKey.F3)
                {
                    Console.WriteLine("Третья октава:");
                    argument = thirdOctave;
                    return argument;
                }
                else if (key.Key == ConsoleKey.F4)
                {
                    Console.WriteLine("Четвёртая октава:");
                    argument = fourthOctave;
                    return argument;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Выберите октаву: \"F1\"/\"F2\"/\"F3\"/\"F4 \n" +
                    "Клавиши: D-R-F-T-G-H-U-J-I-K-L ");
                    return null;
                }
            }
            static int[] mySound(int[] argument)
            {
                while (true)
                {
                    ConsoleKey soundKey = Console.ReadKey().Key;
                    switch (soundKey)
                    {
                        case ConsoleKey.D:
                            Console.Beep(argument[0], 400);
                            Console.Clear();
                            continue;
                            break;
                        case ConsoleKey.R:
                            Console.Beep(argument[1], 400);
                            Console.Clear();
                            continue;
                            break;
                        case ConsoleKey.F:
                            Console.Beep(argument[2], 400);
                            Console.Clear();
                            continue;
                            break;
                        case ConsoleKey.T:
                            Console.Beep(argument[3], 400);
                            Console.Clear();
                            continue;
                            break;
                        case ConsoleKey.G:
                            Console.Beep(argument[4], 400);
                            Console.Clear();
                            continue;
                            break;
                        case ConsoleKey.H:
                            Console.Beep(argument[5], 400);
                            Console.Clear();
                            continue;
                            break;
                        case ConsoleKey.U:
                            Console.Beep(argument[6], 400);
                            Console.Clear();
                            continue;
                            break;
                        case ConsoleKey.J:
                            Console.Beep(argument[7], 400);
                            Console.Clear();
                            continue;
                            break;
                        case ConsoleKey.I:
                            Console.Beep(argument[8], 400);
                            Console.Clear();
                            continue;
                            break;
                        case ConsoleKey.K:
                            Console.Beep(argument[9], 400);
                            Console.Clear();
                            continue;
                            break;
                        case ConsoleKey.O:
                            Console.Beep(argument[10], 400);
                            Console.Clear();
                            continue;
                            break;
                        case ConsoleKey.L:
                            Console.Beep(argument[11], 400);
                            Console.Clear();
                            continue;
                            break;
                        case ConsoleKey.F1:
                            argument = firstOctave;
                            
                            return argument;
                            break;
                        case ConsoleKey.F2:
                            argument = secondOctave;
                            
                            return argument;
                            break;
                        case ConsoleKey.F3:
                            argument = thirdOctave;
                            
                            return argument;
                            break;
                        case ConsoleKey.F4:
                            argument = fourthOctave;
                            
                            return argument;
                            break;
                        default:
                            Console.Clear();
                            continue;
                            break;
                    }
                }
            }
        }
    }
}