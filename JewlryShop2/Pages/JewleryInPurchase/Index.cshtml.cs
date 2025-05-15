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
    public class IndexModel : PageModel
    {
        private readonly JewlryShop2.Data.JewelryContext _context;

        public IndexModel(JewlryShop2.Data.JewelryContext context)
        {
            _context = context;
        }

        public IList<JewelryInPurchase> JewelryInPurchase { get;set; } = default!;

        public async Task OnGetAsync()
        {
            JewelryInPurchase = await _context.JewelryInPurchases
                .Include(j => j.Jewelry)
                .Include(j => j.Purchase).ToListAsync();
        }
    }
}
