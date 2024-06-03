using Microsoft.EntityFrameworkCore;
using DAL.DbModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes("lbvf2ghjrcbuhjr6ikyhntgbqwcvbghdk56slssdsdssnfksf343ksadfaf"))
    };

    options.Events = new JwtBearerEvents {
        OnMessageReceived = context =>
        {
            context.Token = context.Request.Cookies["efrD"];

            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAuthorization();

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

app.UseAuthentication();
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
