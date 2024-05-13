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
    public class IndexModel : PageModel
    {
        private readonly ASP.NET_project.Data.ASPNET_projectContext _context;

        public IndexModel(ASP.NET_project.Data.ASPNET_projectContext context)
        {
            _context = context;
        }

        public IList<Contacts> Contacts { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Contacts != null)
            {
                Contacts = await _context.Contacts.ToListAsync();
            }
        }
    }
}
