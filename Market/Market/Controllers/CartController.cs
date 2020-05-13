using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.Models.CartModels;
using Market.Models.Repository;
using Market.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IMarketRepository _CartRepository;
        private readonly IMarketRepository _CustomerRepository;

        public CartController(IMarketRepository CartRepository, IMarketRepository CustomerRepository)
        {
            _CartRepository = CartRepository;
            _CustomerRepository = CustomerRepository;
        }

            
            public async Task<IActionResult> CartItems()
            {
                var model = new CartViewModel();
                var CartDBOList = await _CartRepository.SelectAllCartItems();

                model.CartItems = CartDBOList
                    .Select(CartDBO => new CartItemNameAndId() { ProductId = CartDBO.ID, CartItemName = CartDBO.PurseName })
                    .ToList();

                return View(model);
            }

       
       [HttpPost]
            public IActionResult DeleteSelectedCartItem(int productId)
            {
                _CartRepository.DeleteSelectedCartItem(productId);
                return RedirectToAction(nameof(CartItems));
            }


        [HttpGet]
        public IActionResult ProceedToCheckout()
        {
            var model = new ProceedToCheckoutViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult ProceedToCheckout(ProceedToCheckoutViewModel postModel)
        {
            var dboCustomer = new CustomerDBO();
            dboCustomer.ID = postModel.ID;
            dboCustomer.firstname = postModel.firstname;
            dboCustomer.lastname = postModel.lastname;
            dboCustomer.Email = postModel.Email;
            dboCustomer.address = postModel.address;
            dboCustomer.city = postModel.city;
            dboCustomer.zipcode = postModel.zipcode;
            dboCustomer.cardnumber = postModel.cardnumber;
            dboCustomer.expirationdate = postModel.expirationdate;
            dboCustomer.cvv = postModel.cvv;
            dboCustomer.subtotal = postModel.subtotal;
            dboCustomer.grandtotal = postModel.grandtotal;


            _CustomerRepository.InsertCustomer(dboCustomer);

            return RedirectToAction(nameof(CartController.CartItems));
        }
        
     
        [HttpPost]
        public IActionResult FinalCheckout()
        {
            return View();
        }
    }
}