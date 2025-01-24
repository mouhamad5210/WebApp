using Core_Project.Models;
using Core_Project.Repositories;
using Food_WebApp1.Utilities;
using Food_WebApp1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Food_WebApp1.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;

        public AuthController(IUserRepository userRepository, ICompanyRepository companyRepository)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
        }

        /// <summary>
        /// HTTP GET action responsible for rendering the login page.
        /// </summary>
        [HttpGet]
        public IActionResult Login(int? state, string message = "")
        {
            ViewBag.message = message;
            ViewBag.state = state;

            if (SessionHelper.IsUserLoggedIn())
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        /// <summary>
        /// HTTP POST action responsible for handling login logic.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (SessionHelper.IsUserLoggedIn())
            {
                return RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.message = "Please enter all the required information.";
                ViewBag.state = 400;
                return View(model);
            }

            try
            {
                // Retrieve user from the database
                var users = await _userRepository.GetAllWithNavigationAsync();
                var userExist = users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

                if (userExist != null)
                {
                    // Set session variables
                    SessionHelper.Login(userExist.Username, userExist.IsAdmin, userExist.IdCompany,userExist.Company.Label);

                    return RedirectToAction("Index", "Home", new
                    {
                        message = "Login successful",
                        state = 200
                    });
                }
                else
                {
                    ViewBag.message = "Login failed: username or password incorrect.";
                    ViewBag.state = 400;
                    return View(model);
                }
            }
            catch (Exception)
            {
                ViewBag.message = "An error occurred while connecting to the database.";
                ViewBag.state = 500;
                return View(model);
            }
        }

        /// <summary>
        /// HTTP GET action responsible for rendering the registration page.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            if (SessionHelper.IsUserLoggedIn())
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Companies = await _companyRepository.GetAllAsync();

            return View();
        }

        /// <summary>
        /// HTTP POST action responsible for handling user registration logic.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Companies = await _companyRepository.GetAllAsync();
                ViewBag.message = "Data entered is not valid.";
                ViewBag.state = 400;
                return View(model);
            }

            try
            {
                // Check if the username already exists
                var userExists = (await _userRepository.GetAllAsync())
                    .FirstOrDefault(u => u.Username == model.Username);

                if (userExists != null)
                {
                    ViewBag.message = "Username already exists. Please choose another one.";
                    ViewBag.state = 400;
                    return View(model);
                }

                // Check if the company exists
                var existingCompany = (await _companyRepository.GetAllAsync())
                    .FirstOrDefault(c => c.Label == model.CompanyName);

                if (existingCompany == null)
                {
                    // Create a new company
                    existingCompany = new Company { Label = model.CompanyName };
                    await _companyRepository.AddAsync(existingCompany);
                    
                }

                // Create and save the user
                var user = new User
                {
                    Username = model.Username,
                    Password = model.Password,
                    IsAdmin=false,
                    IdCompany = existingCompany.IdCompany
                };



                await _userRepository.AddAsync(user);

                return RedirectToAction("Login", "Auth", new
                {
                    message = "Registration successful. Please log in with your information.",
                    state = 200
                });
            }
            catch (Exception ex)
            {
                ViewBag.Companies = await _companyRepository.GetAllAsync();
                ViewBag.message = $"An error occurred while saving to the database: {ex.Message}";
                ViewBag.state = 500;
                Console.WriteLine(ex); // Logs the exception to the console
                return View(model);
            }

        }

        /// <summary>
        /// HTTP GET action responsible for logging out the user.
        /// </summary>
        [HttpGet]
        public IActionResult Logout()
        {
            if (!SessionHelper.IsUserLoggedIn())
            {
                return RedirectToAction("Login", "Auth");
            }

            SessionHelper.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}
