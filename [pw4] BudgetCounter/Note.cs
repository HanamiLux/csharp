using System;

namespace Diary
{
    class Note
    {
        public string name {  get;  set; }
        public string type { get; set; }
        private int amount = 0;
        private static int counter;
        public int count;
        public static int summary = 0;

        public int money
        {
            get { return amount; }
            set { isIncome = (value < 0) ? false : true; amount = Math.Abs(value); }
        }

        public bool isIncome { get;  set; }

        public DateTime date;
        public Note( string name, string type, int amount, DateTime date)
        {
            this.count = counter++;
            summary += amount;
            this.name = name;
            this.amount = amount;
            this.type = type;
            this.date = date;
        }
    }
}
