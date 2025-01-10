using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Proiect4.Data;
using Proiect4.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurare DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurare Identity
builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;  // ✅ Fără confirmare email
    options.Password.RequireDigit = false;           // ✅ Fără cifre obligatorii
    options.Password.RequireUppercase = false;       // ✅ Fără majuscule
    options.Password.RequireNonAlphanumeric = false; // ✅ Fără caractere speciale
    options.Password.RequiredLength = 6;            // ✅ Parolă minimă de 6 caractere
})
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 🔥 Asigură-te că Razor Pages sunt mapate
app.MapRazorPages();

app.Run();
