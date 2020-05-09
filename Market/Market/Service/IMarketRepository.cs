using Market.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Service
{
    public interface IMarketRepository
    {
        Task<bool> InsertPurses(PursesDBO dboPurse);
        Task<IEnumerable<PursesDBO>> SelectAllPurses();
        Task<bool> UpdateSelectedPurses(PursesDBO dboPurse);
        Task<PursesDBO> SelectOnePurse(int ProductId);
        Task<bool> DeleteSelectedPurse(int ProductId);

    }
}
