using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Models.UserModels
{
    public class UserAddToCartViewModel
    {
        public int CartId { get; set; }
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string PurseName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
