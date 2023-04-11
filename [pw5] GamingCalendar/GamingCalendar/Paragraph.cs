using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace GamingCalendar
{
    public class Paragraph
    {
        public string name { get; set; }
        public string img { get; set; }
        public bool isSelected { get; set; }
        public Paragraph(string name, string imgUri = "/Images/sakura.png", bool isSelected = false)
        {
            this.name = name;
            this.img = imgUri;
            this.isSelected = isSelected;
        }
    }
}
