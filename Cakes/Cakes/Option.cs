using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cakes
{
    internal class Option
    {
        /// <summary>
        /// Создание класса для подменю (имя подменю и его id для стрелочного меню)
        /// </summary>
         public readonly string option;
         public readonly int subMenuId;
         public readonly int cost;
        public Option(string inputOption, int inputId, int inputCost)
        {
            this.option = inputOption;
            this.subMenuId = inputId;
            this.cost = inputCost;
        }

    }
}
