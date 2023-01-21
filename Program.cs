using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test_Versta24.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Versta24dbContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IOrderRepository, EFOrderRepository>();

builder.Services.Configure<MvcOptions>(opts =>
{
    opts.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(v => "Введите значение");
    opts.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((v, y) => "Недопустимое значение");
});

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();
