using Core_Project.Models;

namespace Food_WebApp1.Utilities
{
    public static class SessionHelper
    {
        private static IHttpContextAccessor? _httpContextAccessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private static ISession Session => _httpContextAccessor?.HttpContext?.Session
            ?? throw new InvalidOperationException("Session is not available.");

        // Check if the user is logged in
        public static bool IsUserLoggedIn()
        {
            return !string.IsNullOrEmpty(Session.GetString("username"));
        }

        // Check if the logged-in user is an admin
        public static bool IsUserAdmin()
        {
            return Session.GetString("isAdmin") == "true";
        }

        public static int GetCompanyID()
        {
            return (int)Session.GetInt32("companyID");
        }

        public static string GetCompanyName()
        {
            return Session.GetString("companyName");
        }

        // Set session variables for user login
        public static void Login(string username, bool isAdmin,int companyID, string companyName)
        {
            Session.SetString("username", username);
            Session.SetString("isAdmin", isAdmin.ToString().ToLower());
            Session.SetInt32("companyID", companyID);
            Session.SetString("companyName", companyName);
        }

        // Clear session variables on logout
        public static void Logout()
        {
            Session.Clear();
        }
    }
}
