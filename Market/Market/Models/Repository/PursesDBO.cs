using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Models.Repository
{
    public class PursesDBO
    {
        public int ProductId { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
