using Microsoft.EntityFrameworkCore;
using total_test_1.Services;
using Microsoft.AspNetCore.Identity;
using total_test_1.Models.Admin;
using total_test_1.Models.Reviews;
using total_test_1.Models.Schedule;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddDefaultIdentity<AdminUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ReviewsContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("ReviewsConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddDbContext<ScheduleContext>(options =>
{
	var connectionString = builder.Configuration.GetConnectionString("ScheduleConnection");
	options.UseSqlServer(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

app.Run();
