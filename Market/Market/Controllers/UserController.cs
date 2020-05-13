using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.Models.AdminModels;
using Market.Models.CartModels;
using Market.Models.Repository;
using Market.Models.UserModels;
using Market.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IMarketRepository _PursesRepository;
        private readonly IMarketRepository _CartRepository;

        public UserController(IMarketRepository PursesRepository, IMarketRepository CartRepository)
        {
            _PursesRepository = PursesRepository;
            _CartRepository = CartRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> UserPurses()
        {
            var model = new UserPurseViewModel();
            var PursesDBOList = await _PursesRepository.DisplayAllPurses();

            model.UserPurses = PursesDBOList
                .Select(PursesDBO => new UserPurseNameandID() { PurseName = PursesDBO.PurseName, ID = PursesDBO.ProductId, Description = PursesDBO.Description})
                .ToList();

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult PurseDescription()
        {
            var model = new UserPurseNameandID();  
            return View(model);
        }

      

        public IActionResult UserAddToCart()
        {
            var model = new UserAddToCartViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddCartItem(UserAddToCartViewModel postModel)
        {
            var dboCart = new CartDBO();
            dboCart.Quantity = postModel.Quantity;
            dboCart.CartId = postModel.CartId;
            dboCart.ID = postModel.ID;
            dboCart.ProductID = postModel.ProductID;
            dboCart.PurseName = postModel.PurseName;
            dboCart.Price = postModel.Price;

            _CartRepository.InsertCartItem(dboCart);

            return RedirectToAction(nameof(CartController.CartItems));
        }



    }

}