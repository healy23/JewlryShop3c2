﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JewlryShop2.Data;
using JewlryShop2.Models;

namespace JewlryShop2.Pages.Jewelrys
{
    public class DeleteModel : PageModel
    {
        private readonly JewlryShop2.Data.JewelryContext _context;

        public DeleteModel(JewlryShop2.Data.JewelryContext context)
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

            var jewelry = await _context.Jewelrys.FirstOrDefaultAsync(m => m.JewelryID == id);

            if (jewelry == null)
            {
                return NotFound();
            }
            else
            {
                Jewelry = jewelry;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jewelry = await _context.Jewelrys.FindAsync(id);
            if (jewelry != null)
            {
                Jewelry = jewelry;
                _context.Jewelrys.Remove(Jewelry);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
