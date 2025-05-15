using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JewlryShop2.Data;
using JewlryShop2.Models;

namespace JewlryShop2.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly JewlryShop2.Data.JewelryContext _context;

        public IndexModel(JewlryShop2.Data.JewelryContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync(string SearchString)
        {
            IQueryable<Customer> CustomersIQ = from c in _context.Customers select c;
            if (!string.IsNullOrEmpty(SearchString))
            {
                CustomersIQ = CustomersIQ.Where(c => c.Name.Contains(SearchString) || c.LastName.Contains(SearchString));
               
            }

            Customer = await CustomersIQ.ToListAsync();
        }
    }
}
