using BookStoreApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMemoryCache();
builder.Services.AddSession();

builder.Services.AddDbContext<BookstoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreContext")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<BookstoreContext>()
    .AddDefaultTokenProviders();

    builder.Services.AddMvc().AddNToastNotifyNoty(new NotyOptions
    {
	    ProgressBar = true,
	    Timeout = 5000,
	    Theme = "mint"
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

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.UseNToastNotify();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
