using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace NEGROZ
{
    internal enum KeyBinds
    {
        Escape = ConsoleKey.Escape,
        Enter = ConsoleKey.Enter,
        Save = ConsoleKey.S,
        F1 = ConsoleKey.F1,
        F2 = ConsoleKey.F2,
        F3 = ConsoleKey.F3,
        F4 = ConsoleKey.F4,
        Delete = ConsoleKey.Delete
    }
    internal interface ICRUD
    {
        void Create();
        int Read();
        List<User> Update(List<User> user, User userInSystem);
        List<User> Delete(User user, User userInSystem);
        List<User> Search(User userInSystem);

    }
    internal class Administrator : ICRUD
    {
        enum Roles
        {
            Administrator = 1,
            HR = 2,
            WR = 3,
            Accountant = 4,
            Cashier = 5
        }

        const byte OPTIMIZEDPOSITION = 3;
        bool isReturn;
        string json = string.Empty;
        public void Create()
        {
            ConsoleKey returnKey;
            //Очистка
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("                                                                        \n                                                                                       \n                                                                                          \n                                                                              \n                                                                            \n                                                                                    \n                                                                      \n                                                                               \n                                                                                   ");
            Console.SetCursorPosition(94, 3);
            Console.WriteLine("                               ");
            Console.SetCursorPosition(94, 3);
            Console.WriteLine("\tROLES:                                        ");
            Console.SetCursorPosition(94, 4);
            Console.WriteLine("\"Administrator\" - 1\t");
            Console.SetCursorPosition(94, 5);
            Console.WriteLine("\"HR\" - 2\t");
            Console.SetCursorPosition(94, 6);
            Console.WriteLine("\"WR\" - 3\t");
            Console.SetCursorPosition(94, 7);
            Console.WriteLine("\"Accountant\" - 4\t");
            Console.SetCursorPosition(94, 8);
            Console.WriteLine("\"Cashier\" - 5\t");
            //Добавление нового юзера
            int id = 0, intRole;
            string login = "", password = "", role = "";
            bool result = false, result2 = false;
            ConsoleKey saveKey;
        LogPoint:
            Console.SetCursorPosition(0, 16);
            Console.WriteLine("\t                                                                                   \t");
            Console.SetCursorPosition(0, 16);
            Console.WriteLine("\tESC - вернуться в админ меню или нажмите любую клавишу для обнуления добавления\t");
            returnKey = Console.ReadKey(true).Key;
            if (returnKey == (ConsoleKey)KeyBinds.Escape)
                return;
            Console.SetCursorPosition(0, 16);
            Console.WriteLine("\t                                                                                     \t");
            do
            {
                Console.SetCursorPosition(0, 3);
                Console.WriteLine("                  ");
                Console.SetCursorPosition(0, 3);
                Console.Write("ID:");
                string str = Console.ReadLine();
                result = int.TryParse(str, out id);
                Console.SetCursorPosition(0, 12);
                Console.WriteLine("                                        \n                                        \n                                              ");
                Console.SetCursorPosition(0, 12);
                Console.Write("Нажмите любую кнопку, чтобы продолжить.\nНажмите ESCAPE, чтобы начать сначала.");
                returnKey = Console.ReadKey(true).Key;
                Console.SetCursorPosition(0, 12);
                Console.WriteLine("                                        \n                                        \n                                              ");
                if (returnKey == (ConsoleKey)KeyBinds.Escape)
                    goto LogPoint;
                else
                    if (result)
                {
                RepeatPoint:
                    Console.SetCursorPosition(0, 4);
                    Console.WriteLine("                                     ");
                    Console.SetCursorPosition(0, 4);
                    Console.Write("Login:");
                    login = Console.ReadLine();
                    Console.SetCursorPosition(0, 12);
                    Console.WriteLine("                                        \n                                        \n                                              ");
                    Console.SetCursorPosition(0, 12);
                    Console.Write("Нажмите любую кнопку, чтобы продолжить.\nНажмите ESCAPE, чтобы начать сначала.");
                    returnKey = Console.ReadKey(true).Key;
                    Console.SetCursorPosition(0, 12);
                    Console.WriteLine("                                        \n                                        \n                                              ");
                    if (returnKey == (ConsoleKey)KeyBinds.Escape)
                        goto RepeatPoint;
                    RepeatPoint2:
                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine("                                                       ");
                    Console.SetCursorPosition(0, 5);
                    Console.Write("Password:");
                    password = Console.ReadLine();
                    Console.SetCursorPosition(0, 12);
                    Console.WriteLine("                                         \n                                        \n                                              ");
                    Console.SetCursorPosition(0, 12);
                    Console.Write("Нажмите любую кнопку, чтобы продолжить.\nНажмите ESCAPE, чтобы начать сначала.");
                    returnKey = Console.ReadKey(true).Key;
                    Console.SetCursorPosition(0, 12);
                    Console.WriteLine("                                         \n                                        \n                                              ");
                    if (returnKey == (ConsoleKey)KeyBinds.Escape)
                        goto RepeatPoint2;
                    do
                    {
                    RepeatPoint3:
                        Console.SetCursorPosition(0, 6);
                        Console.WriteLine("                                          ");
                        Console.SetCursorPosition(0, 6);
                        Console.Write("Role:");
                        string s = Console.ReadLine();
                        intRole = int.Parse(s);
                        Console.SetCursorPosition(0, 12);
                        Console.WriteLine("                                         \n                                        \n                                              ");
                        Console.SetCursorPosition(0, 12);
                        Console.Write("Нажмите любую кнопку, чтобы продолжить.\nНажмите ESCAPE, чтобы начать сначала.");
                        returnKey = Console.ReadKey(true).Key;
                        Console.SetCursorPosition(0, 12);
                        Console.WriteLine("                                         \n                                        \n                                              ");
                        if (returnKey == (ConsoleKey)KeyBinds.Escape)
                            goto RepeatPoint3;
                        switch (intRole)
                        {
                            case (int)Roles.Administrator:
                                role = "Administrator";
                                result2 = true;
                                break;
                            case (int)Roles.HR:
                                role = "HR";
                                result2 = true;
                                break;
                            case (int)Roles.WR:
                                role = "WR";
                                result2 = true;
                                break;
                            case (int)Roles.Accountant:
                                role = "Accountant";
                                result2 = true;
                                break;
                            case (int)Roles.Cashier:
                                role = "Cashier";
                                result2 = true;
                                break;
                            default:
                                result2 = false;
                                break;
                        }
                    } while (!result2);
                }
            } while (!result);
            while (true)
            {
                Console.SetCursorPosition(0, 12);
                Console.WriteLine("                                     \n                                        \n                                              ");
                Console.SetCursorPosition(94, 9);
                Console.WriteLine("                                ");
                Console.SetCursorPosition(94, 9);
                Console.WriteLine("S - сохранение и выход");
                Console.SetCursorPosition(94, 10);
                Console.WriteLine("                                ");
                Console.SetCursorPosition(94, 10);
                Console.WriteLine("ESC - выход");
                saveKey = Console.ReadKey(true).Key;
                if (saveKey == ConsoleKey.S)
                {
                    var usersDB = SerealizationNDeserialization.GetData();
                    foreach (var user in usersDB)
                    {
                        if (user.id == id || user.login == login)
                        {
                            Console.WriteLine("ТАКОЙ ПОЛЬЗОВАТЕЛЬ УЖЕ СУЩЕСТВУЕТ");
                            ConsoleKey key = Console.ReadKey(true).Key;
                            if (key == (ConsoleKey)KeyBinds.Enter)
                            {
                                goto LogPoint;
                            }
                        }
                    }
                    var newUser = new User(id, login, password, role);
                    SerealizationNDeserialization.AdminSerialization(newUser);
                    return;
                }
                else if (saveKey == (ConsoleKey)KeyBinds.Escape)
                {
                    return;
                }
                else
                    continue;
            }

        }

        public List<User> Delete(User user, User userInSystem)
        {
            string newLogin, oldLogin = user.login, newRole, oldRole = user.role, newPassword, oldPassword = user.password;
            int newID, oldID = user.id;
            bool whiling = true, isWhiling = true;
            ConsoleKey saveKey;
            var usersDB = SerealizationNDeserialization.GetData();
            Console.WriteLine($"\t\t\t\tДобро пожаловать на магазин даркнета, {userInSystem.login}!\t\t Роль: {userInSystem.role}");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(90, i + 3);
                Console.WriteLine("|");
            }
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("                                                                        \n                                                                                       \n                                                                                          \n                                                                              \n                                                                            \n                                                                                    \n                                                                      \n                                                                               \n                                                                                   ");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("\tID\tLogin\tPassword\t\t\t\tRole");
            Console.SetCursorPosition(94, 3);
            Console.WriteLine("                               ");
            Console.SetCursorPosition(94, 3);
            Console.WriteLine("Изменение данных");
            Console.SetCursorPosition(94, 11);
            Console.WriteLine("                              ");
            Console.SetCursorPosition(94, 11);
            Console.WriteLine("ESC - вернуться");
            Console.SetCursorPosition(94, 5);
            Console.WriteLine("                             ");
            Console.SetCursorPosition(94, 6);
            Console.WriteLine("                              ");
            Console.SetCursorPosition(94, 6);
            Console.WriteLine("F1 - ID");
            Console.SetCursorPosition(94, 7);
            Console.WriteLine("                             ");
            Console.SetCursorPosition(94, 7);
            Console.WriteLine("F2 - Login");
            Console.SetCursorPosition(94, 8);
            Console.WriteLine("                              ");
            Console.SetCursorPosition(94, 8);
            Console.WriteLine("F3 - Password");
            Console.SetCursorPosition(94, 9);
            Console.WriteLine("                             ");
            Console.SetCursorPosition(94, 9);
            Console.WriteLine("F4 - Role");
            Console.SetCursorPosition(94, 10);
            Console.WriteLine("                             ");
            Console.SetCursorPosition(94, 10);
            Console.WriteLine("DEL - Удалить");
            Console.SetCursorPosition(94, 11);
            Console.WriteLine("                             ");
            Console.SetCursorPosition(94, 11);
            Console.WriteLine("S - Сохранение");
            Console.SetCursorPosition(2, 4);
            Console.WriteLine("                                                                           ");
            Console.SetCursorPosition(2, 4);
            Console.WriteLine($"\t{user.id}\t{user.login}\t{user.password}\t\t\t\t{user.role}");
            while (whiling)
            {
                ConsoleKey editKey = Console.ReadKey(true).Key;
                Console.SetCursorPosition(0, 6);
                Console.WriteLine("                                                                   ");
                Console.SetCursorPosition(0, 6);
                switch (editKey)
                {
                    case (ConsoleKey)KeyBinds.F1:
                        Console.Write("New ID: ");
                        while (isWhiling)
                        {
                            string str = Console.ReadLine();
                            bool parsing = int.TryParse(str, out newID);
                            if (parsing)
                            {
                                if (oldID != newID)
                                {
                                    oldID = user.id;
                                    user.id = newID;
                                }
                                break;
                            }  
                        }
                        break;
                    case (ConsoleKey)KeyBinds.F2:
                        Console.Write("New Login: ");
                        newLogin = Console.ReadLine();
                        if (oldLogin != newLogin)
                        {
                            oldLogin = user.login;
                            user.login = newLogin;
                        }
                        break;
                    case (ConsoleKey)KeyBinds.F3:
                        Console.Write("New Password: ");
                        newPassword = Console.ReadLine();
                        if (oldPassword != newPassword)
                        {
                            oldPassword = user.password;
                            user.password = newPassword;
                        }
                        break;
                    case (ConsoleKey)KeyBinds.F4:
                        Console.Write("New Role(Administrator,HR,WR,Cashier,Accountant): ");
                        newRole = Console.ReadLine();
                        if (newRole != "Administrator" && newRole != "HR" && newRole != "WR" && newRole != "Cashier" && newRole != "Accountant")
                            continue;
                        if (oldRole != newRole)
                        {
                            oldRole = user.role;
                            user.role = newRole;
                        }
                        break;
                    case (ConsoleKey)KeyBinds.Escape:
                        return usersDB;
                    default:
                        break;
                    case (ConsoleKey)KeyBinds.Save:
                        whiling = false;
                        break;
                    case (ConsoleKey)KeyBinds.Delete:
                        foreach (var oldUser in usersDB)
                        {
                            if (oldUser.id == oldID || oldUser.login == oldLogin || oldUser.password == oldPassword && oldUser.role == oldRole)
                            {
                                usersDB.Remove(oldUser);
                                break;
                            }
                        }
                        return usersDB;
                }
            }
            var newUser = new User(user.id, user.login, user.password, user.role);
            foreach (var oldUser in usersDB)
            {
                if (oldUser.id == oldID || oldUser.login == oldLogin || oldUser.password == oldPassword || oldUser.role == oldRole)
                {
                    usersDB.Remove(oldUser);
                    break;
                }  
            }
            usersDB.Add(newUser);
            return usersDB;
        }

        public int Read()
        {
            //Вывод списка пользователей
            var usersDB = SerealizationNDeserialization.GetData();
            foreach (var user in usersDB)
            {
                Console.WriteLine($"\t{user.id}\t{user.login}\t{user.password}\t\t\t\t{user.role}");
            }
            var arrow = new ArrowMenu(usersDB.Count + OPTIMIZEDPOSITION, OPTIMIZEDPOSITION);
            int chosenPosition = arrow.Arrows();
            return chosenPosition - OPTIMIZEDPOSITION;
        }

        public List<User> Update(List<User> usersList, User userInSystem)
        {
            var usersDB = SerealizationNDeserialization.GetData();
            if (isReturn)
                return usersDB;
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(90, i + 3);
                Console.WriteLine("|");
            }
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("                                                                        \n                                                                                       \n                                                                                          \n                                                                              \n                                                                            \n                                                                                    \n                                                                      \n                                                                               \n                                                                                   ");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("\tID\tLogin\tPassword\t\t\t\tRole");
            Console.SetCursorPosition(94, 3);
            Console.WriteLine("                               ");
            Console.SetCursorPosition(94, 3);
            Console.WriteLine("Изменение данных");
            Console.SetCursorPosition(94, 4);
            Console.WriteLine("                              ");
            Console.SetCursorPosition(94, 4);
            Console.WriteLine("ESC - вернуться");
            Console.SetCursorPosition(94, 5);
            Console.WriteLine("                             ");
            Console.SetCursorPosition(2, 4);
            foreach (var user in usersList)
            {
                Console.WriteLine($"\t{user.id}\t{user.login}\t{user.password}\t\t\t\t{user.role}");
            }
            var arrow = new ArrowMenu(usersList.Count + 1 + OPTIMIZEDPOSITION, OPTIMIZEDPOSITION + 1);
            int chosenPosition = arrow.Arrows() - OPTIMIZEDPOSITION;
            if (chosenPosition == -447)
            {
                return usersDB;
            }
            return Delete(usersList[chosenPosition - 1], userInSystem);

        }
        /// <summary>
        /// Функция возвращает позицию выбранного параметра для сортировки. Используется стрелочное меню.
        /// </summary>
        /// <returns></returns>
        private int SearchPosition()
        {
            while (true)
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("                                                                        \n                                                                                                                   \n                                                                                                           \n                                                                                             \n                                                                            \n                                                                                    \n                                                                      \n                                                                               \n                                                                                   ");
                Console.SetCursorPosition(94, 3);
                Console.WriteLine("                               ");
                Console.SetCursorPosition(94, 3);
                Console.WriteLine("Поиск по атрибутам");
                Console.SetCursorPosition(94, 4);
                Console.WriteLine("                              ");
                Console.SetCursorPosition(94, 4);
                Console.WriteLine("ESC - вернуться");
                Console.SetCursorPosition(94, 5);
                Console.WriteLine("                             ");
                Console.SetCursorPosition(2, 4);
                Console.WriteLine("                             ");
                Console.SetCursorPosition(2, 4);
                Console.WriteLine("ID:");
                Console.SetCursorPosition(2, 5);
                Console.WriteLine("                             ");
                Console.SetCursorPosition(2, 5);
                Console.WriteLine("Login:");
                Console.SetCursorPosition(2, 6);
                Console.WriteLine("                             ");
                Console.SetCursorPosition(2, 6);
                Console.WriteLine("Password:");
                Console.SetCursorPosition(2, 7);
                Console.WriteLine("                             ");
                Console.SetCursorPosition(2, 7);
                Console.WriteLine("Role:");
                for (int i = 0; i < 10; i++)
                {
                    Console.SetCursorPosition(90, i + 3);
                    Console.WriteLine("|");
                }
                var arrow = new ArrowMenu(5 + OPTIMIZEDPOSITION, OPTIMIZEDPOSITION + 1);
                int chosenPosition = arrow.Arrows();
                if (chosenPosition == -444)
                {
                    isReturn = true;
                    return chosenPosition;
                }
                return chosenPosition - OPTIMIZEDPOSITION;
            }
        }
        /// <summary>
        /// Функция возвращает список найденных юзеров, относительно запроса админа.
        /// </summary>
        /// <param name="userInSystem"></param>
        /// <returns></returns>
        public List<User> Search(User userInSystem)
        {
            bool result3;
            int id2, position;
            var usersList = new List<User>();
            var usersDB = SerealizationNDeserialization.GetData();
            ConsoleKey searchKey;
            while (true)
            {
                isReturn = false;
                position = SearchPosition();
                Console.WriteLine($"\t\t\t\tДобро пожаловать на магазин даркнета, {userInSystem.login}!\t\t Роль: {userInSystem.role}");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                Console.SetCursorPosition(94, 3);
                Console.WriteLine("                               ");
                Console.SetCursorPosition(94, 3);
                Console.WriteLine("Поиск по атрибутам");
                Console.SetCursorPosition(94, 4);
                Console.WriteLine("                              ");
                Console.SetCursorPosition(94, 5);
                Console.WriteLine("                             ");
                Console.SetCursorPosition(2, 4);
                Console.WriteLine("                             ");
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("                                                                    \n                                                                        \n                                                                             \n                                                                              \n                                                                            \n                                                                                    \n                                                                      \n                                                                               \n                                                                                   ");
                for (int i = 0; i < 10; i++)
                {
                    Console.SetCursorPosition(90, i + 3);
                    Console.WriteLine("|");
                }
                Console.SetCursorPosition(2, 4);
                Console.WriteLine("ID:");
                Console.SetCursorPosition(2, 5);
                Console.WriteLine("                             ");
                Console.SetCursorPosition(2, 5);
                Console.WriteLine("Login:");
                Console.SetCursorPosition(2, 6);
                Console.WriteLine("                             ");
                Console.SetCursorPosition(2, 6);
                Console.WriteLine("Password:");
                Console.SetCursorPosition(2, 7);
                Console.WriteLine("                             ");
                Console.SetCursorPosition(2, 7);
                Console.WriteLine("Role:");
                if (position == 1)
                {
                    Console.SetCursorPosition(2, 5);
                    Console.WriteLine("                             ");
                    Console.WriteLine("                             ");
                    Console.WriteLine("                             ");
                    Console.SetCursorPosition(94, 4);
                    Console.WriteLine("ESC - Вернуться в АДМеню");
                    Console.SetCursorPosition(94, 5);
                    Console.WriteLine("Любая - Поиск");
                    searchKey = Console.ReadKey(true).Key;
                    if (searchKey == (ConsoleKey)KeyBinds.Escape)
                    {
                        isReturn = true;
                        return usersList;
                    }
                    Console.SetCursorPosition(6, 4);
                    string strid = Console.ReadLine();
                    result3 = int.TryParse(strid, out id2);
                    if (result3)
                    {
                        Console.SetCursorPosition(2, 4);
                        Console.WriteLine("                               ");
                        foreach (var user in usersDB)
                            if (user.id == id2)
                                usersList.Add(user);
                    }
                    else
                        continue;
                }
                else if (position == 2)
                {
                    Console.SetCursorPosition(2, 4);
                    Console.WriteLine("                                                           ");
                    Console.SetCursorPosition(2, 6);
                    Console.WriteLine("                                                                ");
                    Console.WriteLine("                                       ");
                    Console.SetCursorPosition(94, 4);
                    Console.WriteLine("ESC - Вернуться в АДМеню");
                    Console.SetCursorPosition(94, 5);
                    Console.WriteLine("Любая - Поиск");
                    searchKey = Console.ReadKey(true).Key;
                    if (searchKey == (ConsoleKey)KeyBinds.Escape)
                        return usersList;
                    Console.SetCursorPosition(8, 5);
                    string strLogin = Console.ReadLine();
                    Console.SetCursorPosition(2, 5);
                    Console.WriteLine("                               ");
                    foreach (var user in usersDB)
                        if (user.login == strLogin)
                            usersList.Add(user);
                    searchKey = Console.ReadKey(true).Key;
                    if (searchKey == (ConsoleKey)KeyBinds.Escape)
                    {
                        isReturn = true;
                        return usersList;
                    }

                }
                else if (position == 3)
                {
                    Console.SetCursorPosition(2, 4);
                    Console.WriteLine("                                                                             ");
                    Console.WriteLine("                                                                           ");
                    Console.SetCursorPosition(2, 7);
                    Console.WriteLine("                             ");
                    Console.SetCursorPosition(94, 4);
                    Console.WriteLine("ESC - Вернуться в АДМеню");
                    Console.SetCursorPosition(94, 5);
                    Console.WriteLine("Любая - Поиск");
                    searchKey = Console.ReadKey(true).Key;
                    if (searchKey == (ConsoleKey)KeyBinds.Escape)
                        return usersList;
                    Console.SetCursorPosition(11, 6);
                    string strPassword = Console.ReadLine();
                    Console.SetCursorPosition(2, 6);
                    Console.WriteLine("                                                ");
                    foreach (var user in usersDB)
                        if (user.password == strPassword)
                            usersList.Add(user);
                    searchKey = Console.ReadKey(true).Key;
                    if (searchKey == (ConsoleKey)KeyBinds.Escape)
                    {
                        isReturn = true;
                        return usersList;
                    }
                }
                else if (position == 4)
                {
                    Console.SetCursorPosition(2, 4);
                    Console.WriteLine("                                                                             ");
                    Console.WriteLine("                                                                           ");
                    Console.WriteLine("                             ");
                    Console.SetCursorPosition(94, 4);
                    Console.WriteLine("ESC - Вернуться в АДМеню");
                    Console.SetCursorPosition(94, 5);
                    Console.WriteLine("Любая - Поиск");
                    searchKey = Console.ReadKey(true).Key;
                    if (searchKey == (ConsoleKey)KeyBinds.Escape)
                        return usersList;
                    Console.SetCursorPosition(7, 7);
                    string strRole = Console.ReadLine();
                    Console.SetCursorPosition(2, 7);
                    Console.WriteLine("                                                ");
                    foreach (var user in usersDB)
                        if (user.role == strRole)
                            usersList.Add(user);
                    searchKey = Console.ReadKey(true).Key;
                    if (searchKey == (ConsoleKey)KeyBinds.Escape)
                    {
                        isReturn = true;
                        return usersList;
                    }
                }
                return usersList;
            }
            return usersList;
        }
        public void ADMenu(User userInSystem)
        {
            MenuPoint:
            var usersDB = SerealizationNDeserialization.GetData();
            while (true)
            {
                Console.Clear();
                //Оформление меню
                Console.WriteLine($"\t\t\t\tДобро пожаловать на магазин даркнета, {userInSystem.login}!\t\t Роль: {userInSystem.role}");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("\tID\tLogin\tPassword\t\t\t\tRole");
                for (int i = 0; i < 10; i++)
                {
                    Console.SetCursorPosition(90, i + 3);
                    Console.WriteLine("|");
                }
                Console.SetCursorPosition(94, 3);
                Console.WriteLine("F1 - Добавить пользователя");
                Console.SetCursorPosition(94, 4);
                Console.WriteLine("F2 - Найти пользователя");
                Console.SetCursorPosition(0, 3);
                int position = Read();
                ConsoleKey keyPressed = Console.ReadKey(true).Key;
                switch (keyPressed)
                {
                    case (ConsoleKey)KeyBinds.F1:
                        Create();
                        continue;
                    case (ConsoleKey)KeyBinds.F2:
                        json = JsonConvert.SerializeObject(Update(Search(userInSystem), userInSystem));
                        File.WriteAllText($@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\NEGROZ\Users.json", json);
                        var newUsersDB = SerealizationNDeserialization.GetData();
                        break;
                    case (ConsoleKey)KeyBinds.Escape:
                        Console.Clear();
                        return;
                    case (ConsoleKey)KeyBinds.Enter:
                        json = JsonConvert.SerializeObject(Delete(usersDB[position], userInSystem));
                        File.WriteAllText($@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\NEGROZ\Users.json", json);
                        usersDB = SerealizationNDeserialization.GetData();
                        goto MenuPoint;
                        continue;
                    default:
                        break;
                }
            }
        }
    }
}
    /*internal class HR : ICRUD
    {
        public void Create()
        {

        }

        public List<User> Delete(User user, User userInSystem)
        {

        }

        public int Read()
        {
            return 0;
        }

        public void Update(List<User> usersList, User userInSystem)
        {

        }
    }
    internal class WarehouseManager : ICRUD
    {
        public void Create()
        {

        }

        public List<User> Delete(User user, User userInSystem)
        {

        }

        public int Read()
        {
            return 0;
        }

        public void Update(List<User> usersList, User userInSystem)
        {

        }
    }
    internal class Accountant : ICRUD
    {
        public void Create()
        {

        }

        public List<User> Delete(User user, User userInSystem)
        {
            
        }

        public int Read()
        {
            return 0;
        }

        public void Update(List<User> usersList, User userInSystem)
        {

        }
    }
    internal class Cashier
    {

    }
}*/
