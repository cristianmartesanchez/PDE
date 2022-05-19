using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PDE.DataAccess;
using PDE.DataAccess.Repositories;
using PDE.DataAccess.Service;
using PDE.Models.Interfaces;
using PDE.Models.Service;
using PDE.Persistence;
using PDE.Persistence.Padron;
using System;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10000);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

builder.Services.AddHttpClient<IMiembroService, MiembroService>(client => { client.BaseAddress = new Uri(configuration["ApiBaseURI"]); });
builder.Services.AddHttpClient<IProvinciaService, ProvinciaService>(client => { client.BaseAddress = new Uri(configuration["ApiBaseURI"]); });
builder.Services.AddHttpClient<ICargoService, CargoService>(client => { client.BaseAddress = new Uri(configuration["ApiBaseURI"]); });
builder.Services.AddHttpClient<ICargosTerritorialesService, CargosTerritorialesService>(client => { client.BaseAddress = new Uri(configuration["ApiBaseURI"]); });
builder.Services.AddHttpClient<ILocalidadService, LocalidadService>(client => { client.BaseAddress = new Uri(configuration["ApiBaseURI"]); });
builder.Services.AddHttpClient<IPadronService, PadronService>(client => { client.BaseAddress = new Uri(configuration["ApiBaseURI"]); });
builder.Services.AddHttpClient<IEstructuraService, EstructuraService>(client => { client.BaseAddress = new Uri(configuration["ApiBaseURI"]); });
builder.Services.AddHttpClient<IAuthenticateService, AuthenticateService>(client => { client.BaseAddress = new Uri(configuration["ApiBaseURI"]); });
builder.Services.AddHttpClient<IMetasService, MetasService>(client => { client.BaseAddress = new Uri(configuration["ApiBaseURI"]); });

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

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=Login}");

app.Run();
