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
    public class IndexModel : PageModel
    {
        private readonly JewlryShop2.Data.JewelryContext _context;

        public IndexModel(JewlryShop2.Data.JewelryContext context)
        {
            _context = context;
        }

        public IList<Review> Review { get;set; } = default!;

        /*
       public async Task OnGetAsync(string SearchString)
        {
            IQueryable<Review> ReviewsIQ = from r in _context.Reviews select r;
            if (!string.IsNullOrEmpty(SearchString))
            {
                ReviewsIQ = ReviewsIQ.Where(r => r.StarAmount.Contains(SearchString));
              
            }

            Review = await _context.Reviews
                .Include(r => r.Customer)
                .Include(r => r.Jewelry).ToListAsync();
          
        } */

        public async Task OnGetAsync(string SearchString="", int id=0)
        {
            IQueryable<Review> ReviewsIQ = _context.Reviews
                .Include(r => r.Customer)
                .Include(r => r.Jewelry); // Ensure Jewelry is included for filtering

            if (id !=0)
            {
                ReviewsIQ = ReviewsIQ.Where(r => r.JewelryID == id);
            }


            if (!string.IsNullOrEmpty(SearchString))
            {
                if (int.TryParse(SearchString, out int searchValue)) // Check if input is a number
                {
                    ReviewsIQ = ReviewsIQ.Where(r => r.StarAmount == searchValue);
                }
                else // If not a number, search by Jewelry name
                {
                    ReviewsIQ = ReviewsIQ.Where(r => r.Jewelry.JewelryName.Contains(SearchString)).OrderByDescending(r => r.StarAmount);
                }
            }

            Review = await ReviewsIQ.ToListAsync(); // Apply the filtered query
        }

    }
}
