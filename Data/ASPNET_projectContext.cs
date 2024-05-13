using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASP.NET_project.Models;

namespace ASP.NET_project.Data
{
    public class ASPNET_projectContext : DbContext
    {
        public ASPNET_projectContext (DbContextOptions<ASPNET_projectContext> options)
            : base(options)
        {
        }

        public DbSet<ASP.NET_project.Models.Contacts> Contacts { get; set; } = default!;
    }
}
