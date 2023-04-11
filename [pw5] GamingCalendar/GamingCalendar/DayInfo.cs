using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCalendar
{
    internal class DayInfo
    {
        public DateTime time { get; private set; }
        public List<Paragraph> selectionList { get; private set; }
        public DayInfo(DateTime time, List<Paragraph> selectionList)
        {
            this.time = time;
            this.selectionList = selectionList;
        }
    }
}
