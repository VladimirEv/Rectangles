using Microsoft.EntityFrameworkCore;
using RectangleLibrary1;
using RectangleLibrary1.IRectangleGetProperty;
using Rectangles.DataAccess.Data;
using Rectangles.DataAccess.Repository;
using Rectangles.DataAccess.Repository.IRepository;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

builder.Services.AddScoped<IColorBodyRepository, ColorBodyRepository>();
builder.Services.AddScoped<IColorLineRepository, ColorLineRepository>();
builder.Services.AddScoped<IPointRepository, PointRepository>();
builder.Services.AddScoped<IRectangleRepository, RectangleRepository>();
builder.Services.AddScoped <IRectangleService, RectangleService>();
builder.Services.AddScoped<IRectangleServiceChangingCoordinates, RectangleServiceChangingCoordinates>();
builder.Services.AddScoped<IRectangleServiceHelp, RectangleServiceHelp>();
builder.Services.AddScoped<IRectangleServiceChangingCoordinatesColorRec, RectangleServiceChangingCoordinatesColorRec>();

var app = builder.Build();

var cultureInfo = new CultureInfo("es-ES");
cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Main/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Main}/{action=Index}/{id?}");

app.Run();


   

