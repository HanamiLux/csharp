using System.Drawing;

namespace NEGROZ
{
    internal class Program
    {
      /* ███╗░░██╗███████╗░██████╗░██████╗░░█████╗░███████╗  ███╗░░░███╗░█████╗░██████╗░██╗░░██╗███████╗████████╗
         ████╗░██║██╔════╝██╔════╝░██╔══██╗██╔══██╗╚════██║  ████╗░████║██╔══██╗██╔══██╗██║░██╔╝██╔════╝╚══██╔══╝
         ██╔██╗██║█████╗░░██║░░██╗░██████╔╝██║░░██║░░███╔═╝  ██╔████╔██║███████║██████╔╝█████═╝░█████╗░░░░░██║░░░
         ██║╚████║██╔══╝░░██║░░╚██╗██╔══██╗██║░░██║██╔══╝░░  ██║╚██╔╝██║██╔══██║██╔══██╗██╔═██╗░██╔══╝░░░░░██║░░░
         ██║░╚███║███████╗╚██████╔╝██║░░██║╚█████╔╝███████╗  ██║░╚═╝░██║██║░░██║██║░░██║██║░╚██╗███████╗░░░██║░░░
         ╚═╝░░╚══╝╚══════╝░╚═════╝░╚═╝░░╚═╝░╚════╝░╚══════╝  ╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝░░░╚═╝░░░*/
        static void Main(string[] args)
        {
            while (true)
            {
                var userInSystem = Auto();
                Console.Clear();
                if (userInSystem.role == "Administrator")
                {
                    var administrator = new Administrator();
                    administrator.ADMenu(userInSystem);
                }
                if (userInSystem.role == "HR")
                {

                }
                if (userInSystem.role == "WarehouseManager")
                {

                }
                if (userInSystem.role == "Accountant")
                {

                }
                if (userInSystem.role == "Cashier")
                {

                }
            }
        }
        /// <summary>
        /// Последовательная авторизация пользователя в системе: логин, пароль.
        /// </summary>
        static User Auto()
        {
            //100 строк while в while в wh..ААААААААЛЛЛИИИИИИИИИИИИИ.. (я хочу свалить)
            Console.SetCursorPosition(8, 0);
            Console.WriteLine("███╗░░██╗███████╗░██████╗░██████╗░░█████╗░███████╗\r\n        ████╗░██║██╔════╝██╔════╝░██╔══██╗██╔══██╗╚════██║\r\n        ██╔██╗██║█████╗░░██║░░██╗░██████╔╝██║░░██║░░███╔═╝\r\n        ██║╚████║██╔══╝░░██║░░╚██╗██╔══██╗██║░░██║██╔══╝░░\r\n        ██║░╚███║███████╗╚██████╔╝██║░░██║╚█████╔╝███████╗\r\n        ╚═╝░░╚══╝╚══════╝░╚═════╝░╚═╝░░╚═╝░╚════╝░╚══════╝");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            bool isTyped = false;
            string login, inputPassword;
            ConsoleKeyInfo keyPressed, inputKey;
            char key;
            StartPoint:
            inputPassword = "";
            do
            {
                Console.SetCursorPosition(0, 12);
                Console.WriteLine("                                        \n                                        \n                                           ");
                Console.SetCursorPosition(0, 8);
                Console.Write("                                                                                          ");
                Console.SetCursorPosition(0, 8);
                Console.Write("Login:");
                login = Console.ReadLine();
            Point:
                Console.SetCursorPosition(0, 12);
                Console.WriteLine("                                     \n                                        \n                                              ");
                Console.SetCursorPosition(0, 12);
                Console.Write("Нажмите F1, чтобы ввести заново.\nНажмите ENTER, чтобы продолжить.\nНажмите ESCAPE, чтобы начать сначала.");
                keyPressed = Console.ReadKey(true);
                if (keyPressed.Key == (ConsoleKey)KeyBinds.Enter)
                    isTyped = true;
                else if (keyPressed.Key == (ConsoleKey)KeyBinds.F1)
                    isTyped = false;
                else if (keyPressed.Key == (ConsoleKey)KeyBinds.Escape)
                    goto StartPoint;
                else
                {
                    goto Point;
                }
            } while (!isTyped);
            Console.SetCursorPosition(0, 12);
            Console.WriteLine("                                        \n                                        \n                                   ");
            do
            {
                Console.SetCursorPosition(0, 12);
                Console.WriteLine("                                        \n                                        \n                                        ");
                Console.SetCursorPosition(0, 9);
                Console.Write("                                                                                             ");
                do
                {
                    Console.SetCursorPosition(0, 9);
                    Console.Write("Password (<32sym):");
                    byte x = 18;
                    do
                    {
                        inputKey = Console.ReadKey(true);
                        if (inputKey.Key == (ConsoleKey)KeyBinds.Enter || inputKey.Key == ConsoleKey.Tab || inputKey.Key == ConsoleKey.Insert)
                            continue;
                        else if (inputKey.Key == ConsoleKey.Backspace)
                        {
                            inputPassword = inputPassword.Remove(inputPassword.Length - 1);
                            Console.SetCursorPosition(x-1,9);
                            Console.Write(" ");
                            x--;
                            Console.SetCursorPosition(x, 9);
                        }
                        else if (inputKey.Key == (ConsoleKey)KeyBinds.Escape)
                        {
                            Console.SetCursorPosition(0, 9);
                            Console.WriteLine("                                                 ");
                            goto StartPoint;
                        }
                        else
                        {
                            key = inputKey.KeyChar;
                            inputPassword +=key;
                            Console.Write("*");
                            x++;
                        }
                    } while (inputKey.Key != (ConsoleKey)KeyBinds.Enter);
                    isTyped = true; 
                } while (!isTyped);
                do
                {
                    isTyped = false;
                    Console.SetCursorPosition(0, 12);
                    Console.WriteLine("                                        \n                                        \n                                            ");
                    Console.SetCursorPosition(0, 12);
                    Console.Write("Нажмите F1, чтобы ввести заново.\nНажмите ENTER, чтобы продолжить.\nНажмите ESCAPE, чтобы начать сначала.");
                    keyPressed = Console.ReadKey(true);
                    if (keyPressed.Key == ConsoleKey.Enter)
                        isTyped = true;
                    else if (keyPressed.Key == (ConsoleKey)KeyBinds.Escape)
                    {
                        Console.SetCursorPosition(0, 9);
                        Console.WriteLine("                                                 ");
                        goto StartPoint;
                    }
                    else if (keyPressed.Key == (ConsoleKey)KeyBinds.F1)
                    {
                        isTyped = false;
                        inputPassword = "";
                    }
                } while (keyPressed.Key != (ConsoleKey)KeyBinds.Enter && keyPressed.Key != (ConsoleKey)KeyBinds.F1);
            } while (!isTyped);
            Console.SetCursorPosition(0, 12);
            Console.WriteLine("                                        \n                                        \n                                       ");
            Console.SetCursorPosition(0, 14);
            Console.WriteLine("SIGN IN?");
            Console.WriteLine("Нажмите ENTER, чтобы войти.\nНажмите ESCAPE, чтобы начать сначала.");
            while (true)
            {
                keyPressed = Console.ReadKey(true);
                Console.SetCursorPosition(0,16);
                Console.WriteLine("                                          ");
                if (keyPressed.Key == (ConsoleKey)KeyBinds.Enter)
                {
                    var usersDB = SerealizationNDeserialization.GetData();
                    foreach (var user in usersDB)
                    {
                        if (user.login == login)
                            if (user.password == inputPassword)
                            {
                                var loggedUser = new User(user.id, login, inputPassword, user.role);
                                return loggedUser;
                            }
                    }
                    Console.SetCursorPosition(0, 16);
                    Console.WriteLine("НЕПРАВИЛЬНО ВВЕДЁН ЛОГИН ИЛИ ПАРОЛЬ");
                }
                else if (keyPressed.Key == (ConsoleKey)KeyBinds.Escape)
                {
                    Console.SetCursorPosition(0, 9);
                    Console.WriteLine("                                                 ");
                    Console.SetCursorPosition(0, 14);
                    Console.WriteLine("                                                        \n                                                \n                                                    \n                                                   \n");
                    goto StartPoint;
                }
            }
        }
    }
}
