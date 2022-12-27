using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

namespace NEGROZ
{
    internal static class SerealizationNDeserialization
    {
        static string path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\NEGROZ";
        /// <summary>
        /// Первичная сериализация данных пользователя и последующая десериализация их.<br/>
        /// Использование данных для входа в систему.<br/>
        /// Имеется возможность добавления новых элементов для сериализации в "недоБД"
        /// </summary>
        public static void AdminSerialization(User userData)
        {
                var usersList = GetData();
                usersList.Add(userData);
                string json = JsonConvert.SerializeObject(usersList);
                File.WriteAllText($@"{path}\Users.json", json);   
        }

        /// <summary>
        /// Десериализует имеющиеся данные, не добавляя при этом новые.
        /// </summary>
        /// <returns>List</User></returns>
        public static List<User> GetData()
        {
            if (!File.Exists($@"{path}\Users.json"))
            {
                var newList = new List<User>();
                var admin = new User(0, "ADMIN", "NEGROZ", "Administrator");
                Directory.CreateDirectory(path);
                newList.Add(admin);
                string json = JsonConvert.SerializeObject(newList);
                File.Create($@"{path}\Users.json").Close();
                File.WriteAllText($@"{path}\Users.json", json);
            }
            string data = File.ReadAllText($@"{path}\Users.json");
            List<User> usersDataList = JsonConvert.DeserializeObject<List<User>>(data);
            var sortedUsersDataList = from user in usersDataList
                                      orderby user.id
                                      select user;
            usersDataList = sortedUsersDataList.ToList();
            return usersDataList;
        }
    }
}
