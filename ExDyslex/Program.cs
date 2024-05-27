using Microsoft.EntityFrameworkCore;
using DAL.DbModels;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//Routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}",
    new { area = "Public"});
app.MapControllerRoute(
    name: "PublicRoute",
    pattern: "Public/{controller=Home}/{action=Index}/{id?}",
    new { area = "Public"});
app.MapControllerRoute(
    name: "AdminRoute",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}",
    new { area = "Admin" });

app.Run();
