using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASP.NET_project.Data;
using ASP.NET_project.Models;

namespace ASP.NET_project.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ASP.NET_project.Data.ASPNET_projectContext _context;

        public DeleteModel(ASP.NET_project.Data.ASPNET_projectContext context)
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

            var contacts = await _context.Contacts.FirstOrDefaultAsync(m => m.Id == id);

            if (contacts == null)
            {
                return NotFound();
            }
            else 
            {
                Contacts = contacts;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }
            var contacts = await _context.Contacts.FindAsync(id);

            if (contacts != null)
            {
                Contacts = contacts;
                _context.Contacts.Remove(Contacts);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
