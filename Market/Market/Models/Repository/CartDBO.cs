﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Models.Repository
{
    public class CartDBO
    {
        public int CartId { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public string PurseName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
