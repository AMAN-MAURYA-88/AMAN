using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AMAN.Areas.Identity.Data;
//using AMAN.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Edbcs") ?? throw new InvalidOperationException("Connection string 'AMANContextConnection' not found.");

builder.Services.AddDbContext<AMANContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AMANUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<AMANContext>();

builder.Services.AddControllersWithViews();

// ✅ Add session services
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);// Session timeout = 30 minutes
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // ⏱ 30-minute timeout
    options.SlidingExpiration = true; // Extend session if user is active
    options.LoginPath = "/Identity/Account/Login"; // Redirect here if expired
    options.LogoutPath = "/Identity/Account/Logout";
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
app.UseSession(); // ✅ Enable session middleware    // ⚠️ Must come before UseAuthorization 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index1}/{id?}");

app.MapRazorPages();
app.Run();
