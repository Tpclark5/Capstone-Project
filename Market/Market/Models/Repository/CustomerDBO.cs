using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Models.Repository
{
    public class CustomerDBO
    {
       
        public int CustomerID { get; set; }
        public int ID { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string Email { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public int zipcode { get; set; }
        public int cardnumber { get; set; }
        public int expirationdate { get; set; }
        public int cvv { get; set; }
        public int subtotal { get; set; }
        public int grandtotal { get; set; }



    }
}
