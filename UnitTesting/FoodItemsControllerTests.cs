using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Core_Project.Models;
using Core_Project.Repositories;
using System.Linq;
using Food_WebApp1.Controllers;

public class FoodItemsControllerTests
{
    private readonly Mock<IFoodItemRepository> _mockFoodItemRepository;
    private readonly Mock<IFoodGroupRepository> _mockFoodGroupRepository;
    private readonly Mock<IProductRepository> _mockProductRepository;
    private readonly FoodItemsController _controller;

    public FoodItemsControllerTests()
    {
        _mockFoodItemRepository = new Mock<IFoodItemRepository>();
        _mockFoodGroupRepository = new Mock<IFoodGroupRepository>();
        _mockProductRepository = new Mock<IProductRepository>();
        _controller = new FoodItemsController(
            _mockFoodItemRepository.Object,
            _mockFoodGroupRepository.Object,
            _mockProductRepository.Object);
    }

    [Fact]
    public async Task Index_ReturnsViewResult_WithFoodItemsAndFilters()
    {
        // Arrange
        var foodItems = new List<FoodItem>
        {
            new FoodItem { IdFoodItem = 1, Label = "Apple", IdFoodGroup = 1 },
            new FoodItem { IdFoodItem = 2, Label = "Banana", IdFoodGroup = 2 }
        };
        var foodGroups = new List<FoodGroup>
        {
            new FoodGroup { IdFoodGroup = 1, Label = "Fruits" },
            new FoodGroup { IdFoodGroup = 2, Label = "Vegetables" }
        };
        _mockFoodItemRepository.Setup(repo => repo.GetAllWithNavigationAsync()).ReturnsAsync(foodItems);
        _mockFoodGroupRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(foodGroups);

        // Act
        var result = await _controller.Index(1, null, null);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<FoodItem>>(viewResult.Model);
        Assert.Single(model); // Only one matches filter
    }

    [Fact]
    public async Task Create_Post_ReturnsRedirectToIndex_WhenValidModel()
    {
        // Arrange
        var foodItem = new FoodItem { IdFoodItem = 1, Label = "Orange" };

        // Act
        var result = await _controller.Create(foodItem);

        // Assert
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectResult.ActionName);
        _mockFoodItemRepository.Verify(repo => repo.AddAsync(foodItem), Times.Once);
    }

    [Fact]
    public async Task Edit_ReturnsNotFound_WhenIdIsNull()
    {
        // Act
        var result = await _controller.Edit(null);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task DeleteConfirmed_DeletesFoodItemAndRedirects()
    {
        // Arrange
        var foodItem = new FoodItem { IdFoodItem = 1, Label = "Tomato", Products = new List<Product>() };
        _mockFoodItemRepository.Setup(repo => repo.GetByIdWithNavigationAsync(1)).ReturnsAsync(foodItem);

        // Act
        var result = await _controller.DeleteConfirmed(1);

        // Assert
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectResult.ActionName);
        _mockFoodItemRepository.Verify(repo => repo.DeleteAsync(1), Times.Once);
    }
}
