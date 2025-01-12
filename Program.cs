﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proiect4.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(
    options =>
    {
        options.Conventions.AuthorizeFolder("/Users");
        options.Conventions.AuthorizeFolder("/Doctors");
        options.Conventions.AllowAnonymousToPage("/Doctors/Index");
        options.Conventions.AllowAnonymousToPage("/Doctors/Details");
    });
builder.Services.AddDbContext<Proiect4Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Proiect4Context") ?? throw new InvalidOperationException("Connection string 'Proiect4Context' not found.")));

builder.Services.AddDbContext<DbApplicationContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("Proiect4Context") ?? throw new InvalidOperationException("Connection string 'Proiect4Context' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.Password.RequireDigit = false;               
    options.Password.RequireLowercase = false;           
    options.Password.RequireUppercase = false;           
    options.Password.RequireNonAlphanumeric = false;     
    options.Password.RequiredLength = 1;                 
    options.Password.RequiredUniqueChars = 0;            
    options.SignIn.RequireConfirmedAccount = true;
})
 .AddEntityFrameworkStores<DbApplicationContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
