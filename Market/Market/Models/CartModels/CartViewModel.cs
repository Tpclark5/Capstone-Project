using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Models.CartModels
{
    public class CartViewModel
    {
        public IEnumerable<CartItemNameAndId> CartItems { get; set; }
    }
}
