using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Core_Project.Models;
using Core_Project.Repositories;
using Food_WebApp1.Utilities;

namespace Food_WebApp1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IFoodItemRepository _foodItemRepository;

        public ProductsController(
            IProductRepository productRepository,
            ICompanyRepository companyRepository,
            IFoodItemRepository foodItemRepository)
        {
            _productRepository = productRepository;
            _companyRepository = companyRepository;
            _foodItemRepository = foodItemRepository;
        }

        public async Task<IActionResult> Index(
             int? MaxEnergy,
             int? MaxFat,
             int? MaxCarbohydrate,
             int? MaxProtein,
             int? MaxSodium,
             int? MaxSugar,
             int? CompanyId)
        {
            // Get all products with navigation properties
            var products = await _productRepository.GetAllWithNavigationAsync();

            // Apply filters for nutritional values
            if (MaxEnergy.HasValue)
            {
                products = products.Where(p => p.EnergyKcal.HasValue && p.EnergyKcal <= MaxEnergy.Value);
            }
            if (MaxFat.HasValue)
            {
                products = products.Where(p => p.FatG.HasValue && p.FatG <= MaxFat.Value);
            }
            if (MaxCarbohydrate.HasValue)
            {
                products = products.Where(p => p.CarbohydratG.HasValue && p.CarbohydratG <= MaxCarbohydrate.Value);
            }
            if (MaxProtein.HasValue)
            {
                products = products.Where(p => p.ProteinG.HasValue && p.ProteinG <= MaxProtein.Value);
            }
            if (MaxSodium.HasValue)
            {
                products = products.Where(p => p.SodiumMg.HasValue && p.SodiumMg <= MaxSodium.Value);
            }
            if (MaxSugar.HasValue)
            {
                products = products.Where(p => p.SugarG.HasValue && p.SugarG <= MaxSugar.Value);
            }

            // Apply filter for company
            if (CompanyId.HasValue && CompanyId > 0)
            {
                products = products.Where(p => p.IdCompany == CompanyId.Value);
            }

            // Populate the company dropdown for the filter
            var companies = await _companyRepository.GetAllAsync();
            ViewBag.Companies = companies.Select(c => new SelectListItem
            {
                Value = c.IdCompany.ToString(),
                Text = c.Label
            }).ToList();

            // Pass filtered products to the view
            return View(products);
        }


        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetByIdWithNavigationAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            var companies = await _companyRepository.GetAllAsync();
            var foodItems = await _foodItemRepository.GetAllAsync();

            ViewData["IdCompany"] = new SelectList(companies, "IdCompany", "Label");
            ViewData["IdFoodItem"] = new SelectList(foodItems, "IdFoodItem", "Label");
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProduct,IdFoodItem,Label,Prix,ImageUrl,Description,EnergyKcal,FatG,CarbohydratG,ProteinG,SodiumMg,SugarG")] Product product)
        {
                try
                {
                    var idCompany = SessionHelper.GetCompanyID();
                    product.IdCompany = idCompany;
                    await _productRepository.AddAsync(product);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating Product: {ex.Message}");
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the product. Please try again.");
                }

            var companies = await _companyRepository.GetAllAsync();
            var foodItems = await _foodItemRepository.GetAllAsync();

            ViewData["IdCompany"] = new SelectList(companies, "IdCompany", "Label", product.IdCompany);
            ViewData["IdFoodItem"] = new SelectList(foodItems, "IdFoodItem", "Label", product.IdFoodItem);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            var companies = await _companyRepository.GetAllAsync();
            var foodItems = await _foodItemRepository.GetAllAsync();

            ViewData["IdCompany"] = new SelectList(companies, "IdCompany", "Label", product.IdCompany);
            ViewData["IdFoodItem"] = new SelectList(foodItems, "IdFoodItem", "Label", product.IdFoodItem);
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduct,IdFoodItem,Label,Prix,ImageUrl,Description,EnergyKcal,FatG,CarbohydratG,ProteinG,SodiumMg,SugarG")] Product product)
        {
            if (id != product.IdProduct)
            {
                return NotFound();
            }

                try
                {
                    var idCompany = SessionHelper.GetCompanyID();
                    product.IdCompany = idCompany;
                    await _productRepository.UpdateAsync(product);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error editing Product: {ex.Message}");
                    ModelState.AddModelError(string.Empty, "An error occurred while editing the product. Please try again.");
                }
            var companies = await _companyRepository.GetAllAsync();
            var foodItems = await _foodItemRepository.GetAllAsync();

            ViewData["IdCompany"] = new SelectList(companies, "IdCompany", "Label", product.IdCompany);
            ViewData["IdFoodItem"] = new SelectList(foodItems, "IdFoodItem", "Label", product.IdFoodItem);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetByIdWithNavigationAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _productRepository.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting Product: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while deleting the product. Please try again.");
                return RedirectToAction(nameof(Index));
            }
        }
    
    public async Task<IActionResult> ProductsByCompany(int companyId)
        {
            // Fetch products for the specific company
            var products = await _productRepository.GetAllWithNavigationAsync();
            var companyProducts = products.Where(p => p.IdCompany == companyId);

            // Fetch the company name to display in the view
            var company = await _companyRepository.GetByIdAsync(companyId);
            ViewBag.CompanyName = company?.Label ?? "Unknown Company";

            return View(companyProducts);
        }

    }
}