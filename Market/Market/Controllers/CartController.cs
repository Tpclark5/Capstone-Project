using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.Models.CartModels;
using Market.Models.Repository;
using Market.Service;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    public class CartController : Controller
    {
        private readonly IMarketRepository _CartRepository;
       

        public CartController(IMarketRepository CartRepository)
        {
            _CartRepository = CartRepository;
        }

            [HttpGet]
            public async Task<IActionResult> CartItems()
            {
                var model = new CartViewModel();
                var CartDBOList = await _CartRepository.SelectAllCartItems();

                model.CartItems = CartDBOList
                    .Select(CartDBO => new CartItemNameAndId() { CartId = CartDBO.CartId, ProductId = CartDBO.ProductID, CustomerId = CartDBO.CustomerID, CartItemName = CartDBO.PurseName })
                    .ToList();

                return View(model);
            }

       
        [HttpGet]
            public IActionResult AddToCart()
            {
                var model = new AddToCartViewModel();
                return View(model);
            }

            [HttpPost]
            public IActionResult AddCartItem(AddToCartViewModel postModel)
            {
                var dboCart = new CartDBO();
                dboCart.Quantity = postModel.Quantity;
                dboCart.CartId = postModel.CartId;
                dboCart.CustomerID = postModel.CustomerID;
                dboCart.ProductID = postModel.ProductID;
                dboCart.PurseName = postModel.CartItemName;
                dboCart.Price = postModel.Price;

                _CartRepository.InsertCartItem(dboCart);

                return RedirectToAction(nameof(CartItems));
            }

            public IActionResult DeleteSelectedCartItem(int productId)
            {
                _CartRepository.DeleteSelectedCartItem(productId);
                return RedirectToAction(nameof(CartItems));
            }
    }
}