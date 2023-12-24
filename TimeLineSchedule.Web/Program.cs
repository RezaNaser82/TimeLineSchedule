using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TimeLineSchedule.Core.Services.Interface;
using TimeLineSchedule.Core.Services;
using TimeLineSchedule.DataLayer.Context;
using TimeLineSchedule.DataLayer.Entities;
using System.Configuration;
using Hangfire;
using Hangfire.SqlServer;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
builder.Logging.AddConsole();
// Add services to the container.
services.AddControllersWithViews();

#region DataBase Context and Configuration
services.AddDbContext<TimeLineContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection")));

builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseDefaultTypeSerializer()
    .UseSqlServerStorage(builder.Configuration.GetConnectionString("AppConnection"), new SqlServerStorageOptions
    {
        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        QueuePollInterval = TimeSpan.Zero,
        UseRecommendedIsolationLevel = true,
        DisableGlobalLocks = true
    }));

builder.Services.AddHangfireServer();


services.AddScoped<IUserService, UserService>();
services.AddScoped<IExcelService, ExcelService>();
services.AddScoped<IClassDataService, ClassDataService>();
services.AddScoped<IClassesService, ClassesService>();
System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);



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
app.UseHangfireDashboard();

var recurringJobManager = app.Services.GetRequiredService<IRecurringJobManager>();
recurringJobManager.AddOrUpdate(
    "WeeklyClassCleanup",
    () => app.Services.CreateScope().ServiceProvider.GetRequiredService<IClassDataService>().CleanupClasses(),
    "0 0 * * 5"
);

app.MapControllerRoute(
     name: "areas",
     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
   );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

   

app.Run();
