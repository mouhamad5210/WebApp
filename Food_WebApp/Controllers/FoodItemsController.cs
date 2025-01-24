using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Core_Project.Models;
using Core_Project.Repositories;

namespace Food_WebApp1.Controllers
{
    public class FoodItemsController : Controller
    {
        private readonly IFoodItemRepository _foodItemRepository;
        private readonly IFoodGroupRepository _foodGroupRepository;
        private readonly IProductRepository _productRepository;

        public FoodItemsController(
            IFoodItemRepository foodItemRepository,
            IFoodGroupRepository foodGroupRepository,
            IProductRepository productRepository)
        {
            _foodItemRepository = foodItemRepository;
            _foodGroupRepository = foodGroupRepository;
            _productRepository = productRepository;
        }

        // GET: FoodItems
        public async Task<IActionResult> Index(int? FoodGroup, int? MaxEnergy, int? MaxFat)
        {
            // Populate FoodGroups for the filter dropdown
            var foodGroups = await _foodGroupRepository.GetAllAsync();
            ViewBag.FoodGroups = foodGroups.Select(fg => new SelectListItem
            {
                Value = fg.IdFoodGroup.ToString(),
                Text = fg.Label
            }).ToList();

            // Query the repository for FoodItems
            var foodItems = await _foodItemRepository.GetAllWithNavigationAsync();

            // Apply filters only if parameters are provided
            if (FoodGroup.HasValue && FoodGroup > 0)
            {
                foodItems = foodItems.Where(f => f.IdFoodGroup == FoodGroup.Value);
            }
            //if (MaxEnergy.HasValue)
            //{
            //    foodItems = foodItems.Where(f => f.EnergyKcal.HasValue && f.EnergyKcal <= MaxEnergy.Value);
            //}
            //if (MaxFat.HasValue)
            //{
            //    foodItems = foodItems.Where(f => f.FatG.HasValue && f.FatG <= MaxFat.Value);
            //}

            return View(foodItems);
        }

        // GET: FoodItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodItem = await _foodItemRepository.GetByIdWithNavigationAsync(id.Value);
            if (foodItem == null)
            {
                return NotFound();
            }

            return View(foodItem);
        }

        // GET: FoodItems/Create
        public async Task<IActionResult> Create()
        {
            var foodGroups = await _foodGroupRepository.GetAllAsync();
            ViewData["IdFoodGroup"] = new SelectList(foodGroups, "IdFoodGroup", "Label");
            return View();
        }

        // POST: FoodItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFoodItem,IdFoodGroup,Label,EnergyKcal,FatG,CarbohydratG,ProteinG,SodiumMg,SugarG,ImageUrl,Description")] FoodItem foodItem)
        {
           try
                {
                    await _foodItemRepository.AddAsync(foodItem);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating FoodItem: {ex.Message}");
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the FoodItem. Please try again.");
                }

            var foodGroups = await _foodGroupRepository.GetAllAsync();
            ViewData["IdFoodGroup"] = new SelectList(foodGroups, "IdFoodGroup", "Label", foodItem.IdFoodGroup);
            return View(foodItem);
        }

        // GET: FoodItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodItem = await _foodItemRepository.GetByIdAsync(id.Value);
            if (foodItem == null)
            {
                return NotFound();
            }

            var foodGroups = await _foodGroupRepository.GetAllAsync();
            ViewData["IdFoodGroup"] = new SelectList(foodGroups, "IdFoodGroup", "Label", foodItem.IdFoodGroup);
            return View(foodItem);
        }

        // POST: FoodItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFoodItem,IdFoodGroup,Label,EnergyKcal,FatG,CarbohydratG,ProteinG,SodiumMg,SugarG,ImageUrl,Description")] FoodItem foodItem)
        {
            if (id != foodItem.IdFoodItem)
            {
                return NotFound();
            }

          
                try
                {
                    await _foodItemRepository.UpdateAsync(foodItem);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error editing FoodItem: {ex.Message}");
                    ModelState.AddModelError(string.Empty, "An error occurred while editing the FoodItem. Please try again.");
                }

            var foodGroups = await _foodGroupRepository.GetAllAsync();
            ViewData["IdFoodGroup"] = new SelectList(foodGroups, "IdFoodGroup", "Label", foodItem.IdFoodGroup);
            return View(foodItem);
        }

        // GET: FoodItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodItem = await _foodItemRepository.GetByIdWithNavigationAsync(id.Value);
            if (foodItem == null)
            {
                return NotFound();
            }

            return View(foodItem);
        }

        // POST: FoodItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var foodItem = await _foodItemRepository.GetByIdWithNavigationAsync(id);

                if (foodItem != null)
                {
                    // Remove related products
                    foreach (var product in foodItem.Products.ToList())
                    {
                        await _productRepository.DeleteAsync(product.IdProduct);
                    }

                    // Remove the FoodItem
                    await _foodItemRepository.DeleteAsync(foodItem.IdFoodItem);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting FoodItem: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while deleting the FoodItem. Please try again.");
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> FoodItemExists(int id)
        {
            var foodItem = await _foodItemRepository.GetByIdAsync(id);
            return foodItem != null;
        }
    }
}
