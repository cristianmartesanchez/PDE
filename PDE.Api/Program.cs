using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PDE.DataAccess.Repositories;
using PDE.Models.Interfaces;
using PDE.DataAccess;
using PDE.Persistence;
using PDE.Persistence.Padron;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBPDEContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("PDEContext")));

builder.Services.AddDbContext<PadronContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("PadronContext")));

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
