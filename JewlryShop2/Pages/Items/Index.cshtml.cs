using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JewlryShop2.Data;
using JewlryShop2.Models;

namespace JewlryShop2.Pages.Items
{
    public class IndexModel : PageModel
    {
        private readonly JewlryShop2.Data.JewelryContext _context;

        public IndexModel(JewlryShop2.Data.JewelryContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; } = default!;


        public async Task OnGetAsync()

        {

            // && i.Customer.Gmail == sessionGmail

            string sessionGmail = HttpContext.Session.GetString("Gmail");
            string sessionUserType = HttpContext.Session.GetString("UserType");

            if (sessionUserType == "Admin")
            {
                Item = await _context.Item.Include(i => i.Cart)
                    .Include(i => i.Cart.Customer).Include(i => i.Jewelry).ToListAsync();

            }
            else
            {

                Item = await _context.Item.Include(i => i.Cart)
                    .Include(i => i.Cart.Customer).Where(i => i.Cart.Customer.Gmail == sessionGmail).Include(i => i.Jewelry).ToListAsync();

            }

        }
        //   Cart = await _context.Cart.ToListAsync();
        //}
        //    Cart = await _context.Cart.
        //        Include(i => i.Customer && i.).ToListAsync();
        //}
    }
    //public async Task OnGetAsync()
    //{
    //    Item = await _context.Item
    //        .Include(i => i.Cart)
    //        .Include(i => i.Cart.Customer)
    //        .Include(i => i.Jewelry).ToListAsync();
    //}
}

