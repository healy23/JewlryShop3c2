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

namespace JewlryShop2.Pages.JewleryInPurchase
{
    public class EditModel : PageModel
    {
        private readonly JewlryShop2.Data.JewelryContext _context;

        public EditModel(JewlryShop2.Data.JewelryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JewelryInPurchase JewelryInPurchase { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jewelryinpurchase =  await _context.JewelryInPurchases.FirstOrDefaultAsync(m => m.ID == id);
            if (jewelryinpurchase == null)
            {
                return NotFound();
            }
            JewelryInPurchase = jewelryinpurchase;
           ViewData["JewelryID"] = new SelectList(_context.Jewelrys, "JewelryID", "JewelryID");
           ViewData["PurchaseID"] = new SelectList(_context.Purchases, "ID", "ID");
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

            _context.Attach(JewelryInPurchase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JewelryInPurchaseExists(JewelryInPurchase.ID))
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

        private bool JewelryInPurchaseExists(int id)
        {
            return _context.JewelryInPurchases.Any(e => e.ID == id);
        }
    }
}
