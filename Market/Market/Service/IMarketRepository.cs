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

        Task<IEnumerable<CartDBO>> SelectAllCartItems();
        Task<CartDBO> SelectOneCartItem(int ProductId);
        Task<bool> DeleteSelectedCartItem(int ProductId);
        Task<bool> InsertCartItem(CartDBO dboCart);

        Task<IEnumerable<UserDBO>> DisplayAllPurses();
        Task<UserDBO> UserSelectedPurse(int ProductId);

        Task<bool> InsertCustomer(CustomerDBO dboCustomer);

        Task<bool> getsubtotal(int subtotal);
        Task<bool> getgrandtotal(int grandtotal);


    }
}
