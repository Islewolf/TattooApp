using Microsoft.EntityFrameworkCore;
using TattooApp.Models;
using TattooApp.Filters;
using System.Globalization;
//using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(opts => {
    opts.UseSqlServer(builder.Configuration[
        "ConnectionStrings:ProductConnection"]);
    opts.EnableSensitiveDataLogging(true);
});
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<GuidResponseAttribute>();
//builder.Services.Configure<MvcOptions>(opts => {
//    opts.Filters.Add<HttpsOnlyAttribute>();
//    opts.Filters.Add(new MessageAttribute(
//        "This is the globally-scoped filter"));
//});

var app = builder.Build();

// Set European culture (Faroese/Danish style dates)
var danishCulture = new CultureInfo("da-DK");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(danishCulture),
    SupportedCultures = new[] { danishCulture },
    SupportedUICultures = new[] { danishCulture }
};
app.UseRequestLocalization(localizationOptions);

app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.MapControllerRoute("forms", 
    "controllers/{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

var context = app.Services.CreateScope().ServiceProvider
    .GetRequiredService<DataContext>();
SeedData.SeedDatabase(context);

app.Run();
