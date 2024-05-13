using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NET_project.Data;
using ASP.NET_project.Models;

namespace ASP.NET_project.Pages
{
    public class EditModel : PageModel
    {
        private readonly ASP.NET_project.Data.ASPNET_projectContext _context;

        public EditModel(ASP.NET_project.Data.ASPNET_projectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contacts Contacts { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contacts =  await _context.Contacts.FirstOrDefaultAsync(m => m.Id == id);
            if (contacts == null)
            {
                return NotFound();
            }
            Contacts = contacts;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Contacts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactsExists(Contacts.Id))
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

        private bool ContactsExists(int id)
        {
          return (_context.Contacts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
