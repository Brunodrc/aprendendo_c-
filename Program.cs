using Microsoft.EntityFrameworkCore;
using mydotnet.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();
string mysqlconnection =
builder.Configuration.GetConnectionString("MyDbContext");
builder.Services.AddDbContext<MyDbContext>(options => options.UseMySql(mysqlconnection,
ServerVersion.AutoDetect(mysqlconnection)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
