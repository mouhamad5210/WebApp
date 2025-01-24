using Core_Project.Models;
using Core_Project.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Project.Repositories
{
    public interface ICompanyRepository : IRepository<Company> { }
    public interface IFoodGroupRepository : IRepository<FoodGroup> { }
    public interface IFoodItemRepository : IRepository<FoodItem> {
        Task<IEnumerable<FoodItem>> GetAllWithNavigationAsync();
        Task<FoodItem?> GetByIdWithNavigationAsync(int id);
    }
    public interface IProductRepository : IRepository<Product> {
        Task<IEnumerable<Product>> GetAllWithNavigationAsync();
        Task<Product?> GetByIdWithNavigationAsync(int id);
    }
    public interface IUserRepository : IRepository<User> {
        Task<IEnumerable<User>> GetAllWithNavigationAsync();
        Task<User?> GetByIdWithNavigationAsync(int id);
    }
}
