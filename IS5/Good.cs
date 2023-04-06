using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS5
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
        public Good(string name, int amount, double pricePerOne, int typeId = 1, int tierId = 1, int realtorId = 1, int builderId = 1)
        {
            this.name = name;
            this.amount = amount;
            this.pricePerOne = pricePerOne;
            this.typeId = typeId;
            this.tierId = tierId;
            this.realtorId = realtorId;
            this.builderId = builderId;
        }

    }
}
