using JewlryShop2.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JewlryShop2.Pages.Jewelrys
{
    public class IndexModel : PageModel
    {
        private readonly JewlryShop2.Data.JewelryContext _context;

        public IndexModel(JewlryShop2.Data.JewelryContext context)
        {
            _context = context;
        }

        public IList<Jewelry> Jewelry { get;set; } = default!;

        

        public async Task OnGetAsync(string SearchString)
         {
             IQueryable<Jewelry> JewelrysIQ = from s in _context.Jewelrys select s;
             if (!string.IsNullOrEmpty(SearchString))
             {
                 JewelrysIQ = JewelrysIQ.Where(s => s.Material.Contains(SearchString));

             }

             Jewelry = await JewelrysIQ.ToListAsync();
         }
    }
}
