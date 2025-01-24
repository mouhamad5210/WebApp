using Core_Project.Models;
using Core_Project.Repositories;
using Food_WebApp1.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moq;

public class ProductsControllerTests
{
    private readonly Mock<IProductRepository> _mockProductRepository;
    private readonly Mock<ICompanyRepository> _mockCompanyRepository;
    private readonly Mock<IFoodItemRepository> _mockFoodItemRepository;
    private readonly ProductsController _controller;

    public ProductsControllerTests()
    {
        _mockProductRepository = new Mock<IProductRepository>();
        _mockCompanyRepository = new Mock<ICompanyRepository>();
        _mockFoodItemRepository = new Mock<IFoodItemRepository>();
        _controller = new ProductsController(
            _mockProductRepository.Object,
            _mockCompanyRepository.Object,
            _mockFoodItemRepository.Object);
    }

    [Fact]
    public async Task Index_ReturnsFilteredProducts_WhenFiltersAreApplied()
    {
        // Arrange
        var products = new List<Product>
    {
        new Product { IdProduct = 1, Label = "Product A", EnergyKcal = 100 },
        new Product { IdProduct = 2, Label = "Product B", EnergyKcal = 200 },
        new Product { IdProduct = 3, Label = "Product C", EnergyKcal = 300 }
    };

        var companies = new List<Company>
    {
        new Company { IdCompany = 1, Label = "Company A" }
    };

        var mockProductRepository = new Mock<IProductRepository>();
        mockProductRepository.Setup(repo => repo.GetAllWithNavigationAsync()).ReturnsAsync(products);

        var mockCompanyRepository = new Mock<ICompanyRepository>();
        mockCompanyRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(companies);

        var mockFoodItemRepository = new Mock<IFoodItemRepository>();

        var controller = new ProductsController(mockProductRepository.Object, mockCompanyRepository.Object, mockFoodItemRepository.Object);

        // Act
        var result = await controller.Index(200, null, null, null, null, null, null);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<Product>>(viewResult.Model);
        Assert.Equal(2, model.Count()); // Two products with EnergyKcal <= 200
    }

    [Fact]
    public async Task Details_ReturnsNotFound_WhenIdIsNull()
    {
        // Arrange
        var mockProductRepository = new Mock<IProductRepository>();
        var mockCompanyRepository = new Mock<ICompanyRepository>();
        var mockFoodItemRepository = new Mock<IFoodItemRepository>();

        var controller = new ProductsController(mockProductRepository.Object, mockCompanyRepository.Object, mockFoodItemRepository.Object);

        // Act
        var result = await controller.Details(null);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
    [Fact]
    public async Task Create_Post_ReturnsView_WhenModelStateIsInvalid()
    {
        // Arrange
        var product = new Product
        {
            IdProduct = 1,
            Label = "", // Invalid data (e.g., missing required field)
            IdFoodItem = 2,
            Prix = 10.0m,
            ImageUrl = "https://example.com/image.jpg",
            Description = "Sample product"
        };

        var mockProductRepository = new Mock<IProductRepository>();
        var mockCompanyRepository = new Mock<ICompanyRepository>();
        mockCompanyRepository.Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(new List<Company> { new Company { IdCompany = 1, Label = "Company A" } });

        var mockFoodItemRepository = new Mock<IFoodItemRepository>();
        mockFoodItemRepository.Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(new List<FoodItem> { new FoodItem { IdFoodItem = 2, Label = "Food A" } });

        var controller = new ProductsController(
            mockProductRepository.Object,
            mockCompanyRepository.Object,
            mockFoodItemRepository.Object
        );

        // Simulate ModelState validation failure
        controller.ModelState.AddModelError("Label", "The Label field is required.");

        // Act
        var result = await controller.Create(product);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);

        // Ensure ViewData is populated
        var viewDataCompanies = Assert.IsType<SelectList>(viewResult.ViewData["IdCompany"]);
        var viewDataFoodItems = Assert.IsType<SelectList>(viewResult.ViewData["IdFoodItem"]);
        Assert.NotEmpty(viewDataCompanies.Items);
        Assert.NotEmpty(viewDataFoodItems.Items);
    }



    [Fact]
    public async Task DeleteConfirmed_DeletesProductAndRedirectsToIndex()
    {
        // Arrange
        var productId = 1;

        var mockProductRepository = new Mock<IProductRepository>();
        mockProductRepository.Setup(repo => repo.DeleteAsync(productId)).Returns(Task.CompletedTask);

        var mockCompanyRepository = new Mock<ICompanyRepository>();
        var mockFoodItemRepository = new Mock<IFoodItemRepository>();

        var controller = new ProductsController(mockProductRepository.Object, mockCompanyRepository.Object, mockFoodItemRepository.Object);

        // Act
        var result = await controller.DeleteConfirmed(productId);

        // Assert
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectResult.ActionName);
        mockProductRepository.Verify(repo => repo.DeleteAsync(productId), Times.Once);
    }

}
