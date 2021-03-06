﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Models.CartModels
{
    public class AddToCartViewModel
    {
        public int CartId { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public string CartItemName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
