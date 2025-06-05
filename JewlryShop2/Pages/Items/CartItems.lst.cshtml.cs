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
    public class CartItemsModel : PageModel
    {
        private readonly JewlryShop2.Data.JewelryContext _context;

        public CartItemsModel(JewlryShop2.Data.JewelryContext context)
        {
            _context = context;
        }

        public IList<Item> CartItems { get;set; } = default!;
        public int CartId { get; set; }

        public async Task OnGetAsync(int CartId)
        {
            this.CartId = CartId;
            CartItems = await _context.Item
                .Include(i => i.Cart)
                .Include(i => i.Jewelry).ToListAsync();

            IQueryable<Item> ItemIQ = from s in _context.Item select s;
            ItemIQ = ItemIQ.Where(s => s.CartID == CartId);
            CartItems = await ItemIQ.ToListAsync();
        }
    }
}
