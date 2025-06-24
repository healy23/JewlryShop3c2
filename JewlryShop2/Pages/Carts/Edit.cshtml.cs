using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JewlryShop2.Data;
using JewlryShop2.Models;

namespace JewlryShop2.Pages.Carts
{
    public class EditModel : PageModel
    {
        private readonly JewlryShop2.Data.JewelryContext _context;

        public EditModel(JewlryShop2.Data.JewelryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cart Cart { get; set; } = default!;
        //public IActionResult OnGet()
        //{
        //    ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "Name");
        //    return Page();
        //}
        public async Task<IActionResult> OnGetAsync(int? id)
        {

            ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "Name");
            if (id == null)
            {
                return NotFound();
            }

            var cart =  await _context.Cart.FirstOrDefaultAsync(m => m.CartId == id);
            if (cart == null)
            {
                return NotFound();
            }
            Cart = cart;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(Cart.CartId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.CartId == id);
        }
    }
}
