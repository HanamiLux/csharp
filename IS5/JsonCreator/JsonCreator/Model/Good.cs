using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCreator.Model
{
    internal class Good 
    {
        public string name { get; set; }
        public int amount { get; set; }
        public double pricePerOne { get; set; }
        public int typeId { get; set; }
        public int tierId { get; set; }
        public int realtorId { get; set; }
        public int builderId { get; set; }

    }
}
