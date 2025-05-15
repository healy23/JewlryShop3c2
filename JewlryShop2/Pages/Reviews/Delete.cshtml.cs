using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JewlryShop2.Data;
using JewlryShop2.Models;

namespace JewlryShop2.Pages.Reviews
{
    public class DeleteModel : PageModel
    {
        private readonly JewlryShop2.Data.JewelryContext _context;

        public DeleteModel(JewlryShop2.Data.JewelryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Review Review { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                 .Include(r => r.Customer)
                .Include(r => r.Jewelry).
                FirstOrDefaultAsync(m => m.ID == id);
            //var review = await _context.Reviews
             // .Include(r => r.Customer)
                //.Include(r => r.Jewelry).ToListAsync();
            if (review == null)
            {
                return NotFound();
            }
            else
            {
                Review = review;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.FindAsync(id);
            if (review != null)
            {
                Review = review;
                _context.Reviews.Remove(Review);
                await _context.SaveChangesAsync();
            }


            return RedirectToPage("./Index");
        }
    }
}
