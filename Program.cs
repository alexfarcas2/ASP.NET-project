using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ASP.NET_project.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ASPNET_projectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ASPNET_projectContext") ?? throw new InvalidOperationException("Connection string 'ASPNET_projectContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
