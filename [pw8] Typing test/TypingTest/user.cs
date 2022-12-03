using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingTest
{
    internal class user
    {
        public string name;
        public double spm;
        public double sps;
        public user(string name, double sps, double spm)
        {
            this.name = name;
            this.sps = sps;
            this.spm = spm; 
        }
    }
}
