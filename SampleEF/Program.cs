using FastReport.Data;
using Microsoft.EntityFrameworkCore;
using SampleEF.Data;
using SampleEF.Data.Dal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//menambahkan DI
builder.Services.AddScoped<IRestaurantData,RestaurantData>();
builder.Services.AddScoped<ISamurai, SamuraiDal>();
//EF Core
builder.Services.AddDbContext<SamuraiContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("SamuraiConnection"))
   .EnableSensitiveDataLogging());

//fast report
FastReport.Utils.RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));


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
//use fast report
app.UseFastReport();


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
