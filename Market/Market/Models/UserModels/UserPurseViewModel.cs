using Market.Models.AdminModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Models.UserModels
{
    public class UserPurseViewModel
    {
        public IEnumerable<UserPurseNameandID> UserPurses { get; set; }
    }
}
