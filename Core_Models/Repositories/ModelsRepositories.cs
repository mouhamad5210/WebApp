using Core_Project.Context;
using Core_Project.Models;
using Core_Project.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Project.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context) { }
    }

    public class FoodGroupRepository : Repository<FoodGroup>, IFoodGroupRepository
    {
        public FoodGroupRepository(ApplicationDbContext context) : base(context) { }
    }

    public class FoodItemRepository : Repository<FoodItem>, IFoodItemRepository
    {
        public FoodItemRepository(ApplicationDbContext context) : base(context) {
        }

        public async Task<IEnumerable<FoodItem>> GetAllWithNavigationAsync()
        {
            return await _context.FoodItems
                .Include(f => f.IdFoodGroupNavigation)
                .Include(f => f.Products)
                .ThenInclude(p => p.IdCompanyNavigation)
                .ToListAsync();
        }

        public async Task<FoodItem?> GetByIdWithNavigationAsync(int id)
        {
            return await _context.FoodItems
                .Include(f => f.IdFoodGroupNavigation)
                .Include(f => f.Products)
                .ThenInclude(p => p.IdCompanyNavigation)
                .FirstOrDefaultAsync(f => f.IdFoodItem == id);
        }
    }

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) {
        }

        public async Task<IEnumerable<Product>> GetAllWithNavigationAsync()
        {
            return await _context.Products
                .Include(p => p.IdCompanyNavigation)
                .Include(p => p.IdFoodItemNavigation)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdWithNavigationAsync(int id)
        {
            return await _context.Products
                .Include(p => p.IdCompanyNavigation)
                .Include(p => p.IdFoodItemNavigation)
                .FirstOrDefaultAsync(p => p.IdProduct == id);
        }


    }

    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }


        public async Task<IEnumerable<User>> GetAllWithNavigationAsync()
        {
            return await _context.Users
                .Include(p => p.Company)
                .ToListAsync();
        }
        public async Task<User?> GetByIdWithNavigationAsync(int id)
        {
            return await _context.Users
                .Include(p => p.Company)
                .FirstOrDefaultAsync(p => p.IdUser == id);
        }
    }
}


