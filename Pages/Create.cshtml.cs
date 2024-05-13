using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASP.NET_project.Data;
using ASP.NET_project.Models;

namespace ASP.NET_project.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ASP.NET_project.Data.ASPNET_projectContext _context;

        public CreateModel(ASP.NET_project.Data.ASPNET_projectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Contacts Contacts { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Contacts == null || Contacts == null)
            {
                return Page();
            }

            _context.Contacts.Add(Contacts);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
