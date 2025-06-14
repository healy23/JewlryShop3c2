//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using JewlryShop2.Data;
//using JewlryShop2.Models;

//namespace JewlryShop2.Pages.Customers
//{
//    public class EditModel : PageModel
//    {
//        private readonly JewlryShop2.Data.JewelryContext _context;

//        public EditModel(JewlryShop2.Data.JewelryContext context)
//        {
//            _context = context;
//        }

//        [BindProperty]
//        public Customer Customer { get; set; } = default!;

//        public async Task<IActionResult> OnGetAsync(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var customer =  await _context.Customers.FirstOrDefaultAsync(m => m.ID == id);
//            if (customer == null)
//            {
//                return NotFound();
//            }
//            Customer = customer;
//            return Page();
//        }


//        public async Task<IActionResult> OnPostAsync()
//        {
//            if (!ModelState.IsValid)
//            {
//                return Page();
//            }

//            _context.Attach(Customer).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!CustomerExists(Customer.ID))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return RedirectToPage("./Index");
//        }

//        private bool CustomerExists(int id)
//        {
//            return _context.Customers.Any(e => e.ID == id);
//        }
//    }
//}

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JewlryShop2.Data;
using JewlryShop2.Models;

namespace JewlryShop2.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly JewelryContext _context;

        public EditModel(JewlryShop2.Data.JewelryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.ID == id);
            if (customer == null)
            {
                return NotFound();
            }
            Customer = customer;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var customerToUpdate = await _context.Customers.FindAsync(Customer.ID);
            if (customerToUpdate == null)
            {
                return NotFound();
            }

            customerToUpdate.Name = Customer.Name;
            customerToUpdate.Gmail = Customer.Gmail;
            customerToUpdate.Password = Customer.Password;
            customerToUpdate.ClubMembership = Customer.ClubMembership;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(Customer.ID))
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

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.ID == id);
        }
    }
}
