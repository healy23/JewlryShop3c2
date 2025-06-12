using JewlryShop2.Models; // מודל Member
using Microsoft.AspNetCore.Http; // לגישה לסשן
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;


namespace JewlryShop2.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly JewlryShop2.Data.JewelryContext _context;

        public IndexModel(JewlryShop2.Data.JewelryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Gmail { get; set; }

        public string ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            var user = _context.Customers.FirstOrDefault(m => m.Gmail == Gmail);

            if (user != null)
            {
                bool isAdmin = user.Gmail == "admin@yourshop.com"; // set your real admin email here

                HttpContext.Session.SetString("Gmail", user.Gmail);
                HttpContext.Session.SetString("Name", user.Name);
                HttpContext.Session.SetString("UserType", isAdmin ? "Admin" : "Customer");
                HttpContext.Session.SetInt32("CustomerId", user.ID); // for easier filtering

                return RedirectToPage("/Index");

                // Redirect based on role
                //if (isAdmin)
                //    return RedirectToPage("/Admin/Dashboard");
                //else
                //    return RedirectToPage("/Customers/CustomerHome", new { id = user.ID });
            }
            else
            {
                ErrorMessage = "Gmail not found, please create an account.";
                return Page();
            }
        }

    }
}
