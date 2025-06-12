using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JewlryShop2.Pages.Login
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnPost()
        {
            HttpContext.Session.Clear(); // clear all session data
            return RedirectToPage("/Login/Index");
        }
    }
}

