using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cakes
{
    internal class MainMenu
    {
        
        public string title;
        List<Option> options = new List<Option>();
        public int mainMenuId;
        /// <summary>
        /// Создание меню программы с использованием класса Options для комфорта.
        /// Состоит из (Названия пункта, всех опций пункта и их id, id самого пункта)
        /// </summary>
        public MainMenu(string inputTitle, List<Option> inputOptions, int inputId)
        {
         title = inputTitle;
         options = inputOptions;
         mainMenuId = inputId;
        }
    }
}
