using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Models.CartModels
{
    public class CartItemNameAndId
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public string CartItemName { get; set; }
    }
}
