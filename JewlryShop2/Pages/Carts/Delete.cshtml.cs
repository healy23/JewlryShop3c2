using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JewlryShop2.Data;
using JewlryShop2.Models;

namespace JewlryShop2.Pages.Carts
{
    public class DeleteModel : PageModel
    {
        private readonly JewlryShop2.Data.JewelryContext _context;

        public DeleteModel(JewlryShop2.Data.JewelryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cart Cart { get; set; } = default!;

        //public async Task<IActionResult> OnGetAsync(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cart = await _context.Cart.FirstOrDefaultAsync(m => m.CartId == id);

        //    if (cart == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        Cart = cart;
        //    }
        //    return Page();
        //}
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cart = await _context.Cart
                .Include(c => c.Customer) // include the customer!
                .FirstOrDefaultAsync(m => m.CartId == id);

            if (Cart == null)
            {
                return NotFound();
            }
            return Page();
        }


        //public async Task<IActionResult> OnPostAsync(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cart = await _context.Cart.FindAsync(id);
        //    if (cart != null)
        //    {
        //        Cart = cart;
        //        _context.Cart.Remove(Cart);
        //        await _context.SaveChangesAsync();
        //    }

        //    return RedirectToPage("./Index");
        //}

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cart = await _context.Cart
                .Include(c => c.Customer) // include this if you access Customer after post
                .FirstOrDefaultAsync(m => m.CartId == id);

            if (Cart != null)
            {
                _context.Cart.Remove(Cart);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

    }
}
