using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JewlryShop2.Data;
using JewlryShop2.Models;

namespace JewlryShop2.Pages.Reviews
{
    public class CreateModel : PageModel
    {
        private readonly JewlryShop2.Data.JewelryContext _context;

        public CreateModel(JewlryShop2.Data.JewelryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "Name");
        ViewData["JewelryID"] = new SelectList(_context.Jewelrys, "JewelryID", "JewelryName");
            return Page();
        }

        [BindProperty]
        public Review Review { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reviews.Add(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
