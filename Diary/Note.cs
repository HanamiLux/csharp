using System;

namespace Diary
{
    class Note
    {
        public string name, description;
        public DateTime currentDate, date;
        public Note(string name, string description, DateTime date)
        {
            this.name = name;
            this.description = description;
            currentDate = DateTime.Now;
            this.date = date;
        }
    }
}
