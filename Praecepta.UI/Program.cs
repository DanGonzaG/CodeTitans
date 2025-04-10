using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Praecepta.UI.Data;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*var Idiomas = new[]
{
    new CultureInfo("en-US"),
    new CultureInfo("es-ES"),
};

var localizacionEidioma = new RequestLocalizationOptions();
localizacionEidioma.SupportedCultures = Idiomas;
localizacionEidioma.SupportedUICultures = Idiomas;
localizacionEidioma.SetDefaultCulture("es-ES");
localizacionEidioma.ApplyCurrentCultureToResponseHeaders = true;*/

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();



var app = builder.Build();

//app.UseRequestLocalization(localizacionEidioma);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
