using Microsoft.EntityFrameworkCore;
using PDE.DataAccess;
using PDE.DataAccess.Repositories;
using PDE.Models.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DBPDEContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("PDEContext")));

builder.Services.AddDbContext<PadronContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("PadronContext")));

builder.Services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
