using Backend.DataAccessLayer.Concrete;
using Backend.BusinessLayer.Abstract;
using Backend.BusinessLayer.Concrete;
using Backend.DataAccessLayer.Abstract;
using Backend.DataAccessLayer.Concrete.Repositories;
using Microsoft.EntityFrameworkCore;
using Backend.EntityLayer.Concrete;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<Context>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
