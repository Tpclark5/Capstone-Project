using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Models.CartModels
{
    public class ProceedToCheckoutViewModel
    {
        public int CustomerID { get; set; }
        public int ID { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Invalid Entry, Please Enter A Valid Name", MinimumLength = 2)]
        public string firstname { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Invalid Entry, Please Enter A Valid Name", MinimumLength = 2)]
        public string lastname { get; set; }

        [Required(ErrorMessage = "You must provide an email address")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Invalid Entry, Please Enter A Valid Address", MinimumLength = 2)]
        public string address { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Invalid Entry, Please Enter A Valid City", MinimumLength = 2)]
        public string city { get; set; }
        [Required(ErrorMessage = "You must provide an ZIPCODE")]
        [StringLength(5, ErrorMessage = "Invalid Entry, Please Enter A Valid ZIPCODE", MinimumLength = 5)]
        public int zipcode { get; set; }

        [Required(ErrorMessage = "You must provide an Card Number")]
        [DataType(DataType.CreditCard)]
        [StringLength(16, ErrorMessage = "Invalid Entry, Please Enter A Valid Card Number", MinimumLength = 16)]
        public int cardnumber { get; set; }
        [Required(ErrorMessage = "You must provide an email address")]
        [StringLength(4, ErrorMessage = "Invalid Entry, Please Enter A Valid 4 Digit Expiration MM/YY", MinimumLength = 4)]
        public int expirationdate { get; set; }

        [Required(ErrorMessage = "You must provide an cvv")]
        [StringLength(4, ErrorMessage = "Invalid Entry, Please Enter A Valid CVV", MinimumLength = 3)]
        public int cvv { get; set; }
        public int subtotal { get; set; }
        public int grandtotal { get; set; }

        public string ErrorMessage { get; set; }
    }
}
