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
      private readonly IMarketRepository _PursesRepository;

      public AdminController(IMarketRepository PursesRepository)
      {
       _PursesRepository = PursesRepository;
      }

            [HttpGet]
            public async Task<IActionResult> Purses()
            {
                var model = new PurseViewModel();
                var PursesDBOList = await _PursesRepository.SelectAllPurses();

                model.Purses = PursesDBOList
                    .Select(PursesDBO => new PurseNameandID() { PurseName = PursesDBO.PurseName, ProductId = PursesDBO.ProductId })
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
                dboPurses.PurseName = postModel.PurseName;
                dboPurses.Brand = postModel.Brand;
                dboPurses.Color = postModel.Color;
                dboPurses.Price = postModel.Price;
                dboPurses.Description = postModel.Description;

                _PursesRepository.InsertPurses(dboPurses);

                return RedirectToAction(nameof(Purses));
            }

            public IActionResult DeleteSelectedPurse(int productId)
            {
                _PursesRepository.DeleteSelectedPurse(productId);
                return RedirectToAction(nameof(Purses));
            }

            [HttpGet]
            public async Task<IActionResult> UpdatePurse(int productId)
            {
                var model = new UpdatePurseViewModel();

                var currentPurse = await _PursesRepository.SelectOnePurse(productId);

                model.NewPurseName = string.Empty;
                model.OldPurseName = currentPurse.PurseName;

                model.NewBrand = string.Empty;
                model.OldBrand = currentPurse.Brand;

                model.NewDescription = string.Empty;
                model.OldDescription = currentPurse.Description;

                model.NewColor = string.Empty;
                model.OldColor = currentPurse.Color;

                model.NewPrice = default(int);
                model.OldPrice = currentPurse.Price;

                model.ProductId = productId;

                return View(model);
            }

            [HttpPost]
            public IActionResult UpdatePurse(UpdatePurseViewModel model)
            {
                var dboPurse = new PursesDBO();
                dboPurse.PurseName = model.NewPurseName;
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