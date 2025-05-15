using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JewlryShop2.Data;
using JewlryShop2.Models;

namespace JewlryShop2.Pages.JewleryInPurchase
{
    public class DetailsModel : PageModel
    {
        private readonly JewlryShop2.Data.JewelryContext _context;

        public DetailsModel(JewlryShop2.Data.JewelryContext context)
        {
            _context = context;
        }

        public JewelryInPurchase JewelryInPurchase { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jewelryinpurchase = await _context.JewelryInPurchases.FirstOrDefaultAsync(m => m.ID == id);
            if (jewelryinpurchase == null)
            {
                return NotFound();
            }
            else
            {
                JewelryInPurchase = jewelryinpurchase;
            }
            return Page();
        }
    }
}
