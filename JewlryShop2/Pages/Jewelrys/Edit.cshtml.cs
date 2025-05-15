﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JewlryShop2.Data;
using JewlryShop2.Models;

namespace JewlryShop2.Pages.Jewelrys
{
    public class EditModel : PageModel
    {
        private readonly JewlryShop2.Data.JewelryContext _context;

        public EditModel(JewlryShop2.Data.JewelryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Jewelry Jewelry { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jewelry =  await _context.Jewelrys.FirstOrDefaultAsync(m => m.JewelryID == id);
            if (jewelry == null)
            {
                return NotFound();
            }
            Jewelry = jewelry;
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

            _context.Attach(Jewelry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JewelryExists(Jewelry.JewelryID))
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

        private bool JewelryExists(int id)
        {
            return _context.Jewelrys.Any(e => e.JewelryID == id);
        }
    }
}
