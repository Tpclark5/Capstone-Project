using Market.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Models.AdminModels
{
    public class PurseViewModel
    {
        public IEnumerable<PurseNameandID> Purses { get; set; }
    }
}
