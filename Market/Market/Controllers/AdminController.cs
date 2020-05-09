using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.Models.AdminModels;
using Market.Models.Repository;
using Market.Service;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    public class AdminController : Controller
    {
        public class PursesController : Controller
        {
            private readonly IMarketRepository _PursesRepository;

            public PursesController(IMarketRepository PursesRepository)
            {
                _PursesRepository = PursesRepository;
            }

            [HttpPost]
            public async Task<IActionResult> Purses()
            {
                var model = new PurseViewModel();
                var PursesDBOList = await _PursesRepository.SelectAllPurses();

                model.Purses = PursesDBOList
                    .Select(PursesDBO => new PurseNameandID() { Brand = PursesDBO.Brand, ProductId = PursesDBO.ProductId })
                    .ToList();

                return View(model);
            }

            [HttpGet]
            public IActionResult AddPurse()
            {
                var model = new AddPurseViewModel();
                return View(model);
            }

            [HttpPost]
            public IActionResult AddPurse(AddPurseViewModel postModel)
            {
                var dboPurses = new PursesDBO();
                dboPurses.Brand = postModel.Brand;
                dboPurses.Color = postModel.Color;
                dboPurses.Price = postModel.Price;
                dboPurses.Description = postModel.Description;

                _PursesRepository.InsertPurses(dboPurses);

                return RedirectToAction(nameof(Purses));
            }

            public IActionResult DeleteSelectedPurse(int pursesId)
            {
                _PursesRepository.DeleteSelectedPurse(pursesId);
                return RedirectToAction(nameof(Purses));
            }

            [HttpGet]
            public async Task<IActionResult> UpdatePurse(int pursesID)
            {
                var model = new UpdatePurseViewModel();

                var currentPurse = await _PursesRepository.SelectOnePurse(pursesID);


                model.NewBrand = string.Empty;
                model.OldBrand = currentPurse.Brand;

                model.NewDescription = string.Empty;
                model.OldDescription = currentPurse.Description;

                model.NewColor = string.Empty;
                model.OldColor = currentPurse.Color;

                model.NewPrice = default(int);
                model.OldPrice = currentPurse.Price;

                model.ProductId = pursesID;

                return View(model);
            }

            [HttpPost]
            public IActionResult UpdatePurse(UpdatePurseViewModel model)
            {
                var dboPurse = new PursesDBO();
                dboPurse.Brand = model.NewBrand;
                dboPurse.Price = model.NewPrice;
                dboPurse.Color = model.NewColor;
                dboPurse.Description = model.NewDescription;
                dboPurse.ProductId = model.ProductId;

                _PursesRepository.UpdateSelectedPurses(dboPurse);

                return RedirectToAction(nameof(Purses));
            }

        }
    }
}