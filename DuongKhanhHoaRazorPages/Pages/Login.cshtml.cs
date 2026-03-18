using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DuongKhanhHoaRazorPages.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please select a role")]
        public string? SelectedRole { get; set; }

        [BindProperty]
        public bool RememberMe { get; set; }

        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
            // Check if user is already authenticated
            if (User.Identity?.IsAuthenticated ?? false)
            {
                RedirectToPage("/Index");
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // TODO: Implement actual authentication logic
                // This is a placeholder for the authentication process
                
                if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                {
                    ErrorMessage = "Email and password are required.";
                    return Page();
                }

                // Validate role
                if (string.IsNullOrEmpty(SelectedRole) || !new[] { "admin", "staff", "lecturer" }.Contains(SelectedRole))
                {
                    ErrorMessage = "Invalid role selected.";
                    return Page();
                }

                // TODO: Replace with actual database authentication
                // Example: Check credentials against database
                // if (!AuthenticateUser(Email, Password, SelectedRole))
                // {
                //     ErrorMessage = "Invalid email or password.";
                //     return Page();
                // }

                // Placeholder authentication (remove in production)
                if (Email == "admin@fpt.edu.vn" && Password == "admin123")
                {
                    // TODO: Create authentication ticket and sign in user
                    // This is just a placeholder response
                    return RedirectToPage("/Index");
                }
                
                ErrorMessage = "Invalid credentials. Please try again.";
                return Page();
            }
            catch (Exception ex)
            {
                ErrorMessage = "An error occurred during login. Please try again.";
                // TODO: Log exception
                return Page();
            }
        }
    }
}
