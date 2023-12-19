using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TimeLineSchedule.Core.Services.Interface;
using TimeLineSchedule.Core.Services;
using TimeLineSchedule.DataLayer.Context;
using TimeLineSchedule.DataLayer.Entities;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
builder.Logging.AddConsole();
// Add services to the container.
services.AddControllersWithViews();

#region DataBase Context and Configuration
services.AddDbContext<TimeLineContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection")));
services.AddTransient<IUserService, UserService>();
services.AddTransient<IExcelService, ExcelService>();
services.AddTransient<IClassDataService, ClassDataService>();
services.AddTransient<IClassesService, ClassesService>();
services.AddHostedService<ScheduledJobService>();
System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

// Other scoped, transient, or singleton services

#endregion

#region Authentication

services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

}).AddCookie(options =>
{
    options.LoginPath = "/Login";
    options.LogoutPath = "/Logout";
});

#endregion




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

app.MapControllerRoute(
     name: "areas",
     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
   );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

   

app.Run();
