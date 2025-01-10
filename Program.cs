using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proiect4.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configure DbContext pentru baza de date
builder.Services.AddDbContext<Proiect4Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Proiect4Context") ?? throw new InvalidOperationException("Connection string 'Proiect4Context' not found.")));

// Configure Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; // Poți schimba în true dacă vrei să necesite confirmare
})
.AddEntityFrameworkStores<Proiect4Context>();

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

app.UseAuthentication(); // Activează autentificarea
app.UseAuthorization();  // Activează autorizarea

app.MapRazorPages();

app.Run();