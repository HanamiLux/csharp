using System;

namespace Diary
{
    class Note
    {
        public string guid;
        public DateTime currentDate;
        public DateTime date { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Note(string guid, string name, string description, DateTime date)
        {
            this.guid = guid;
            this.name = name;
            this.description = description;
            currentDate = DateTime.Now;
            this.date = date;
        }
        public Note()
        {
            this.guid = new Guid().ToString();
            this.name = "Note";
            this.description = string.Empty;
            currentDate = DateTime.Now;
            this.date = DateTime.Now;
        }
    }
}
