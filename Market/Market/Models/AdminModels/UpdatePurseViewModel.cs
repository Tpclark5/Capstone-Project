using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Models.AdminModels
{
    public class UpdatePurseViewModel
    {
        public string OldBrand { get; set; }
        public string OldDescription { get; set; }
        public double OldPrice { get; set; }
        public string OldColor { get; set; }

        public string NewBrand { get; set; }

        public string NewDescription { get; set; }
        public string NewColor { get; set; }

        public double NewPrice { get; set; }

        public int ProductId { get; set; }
    }
}
