using Microsoft.EntityFrameworkCore;
using SampleEF.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//menambahkan DI
builder.Services.AddScoped<IRestaurantData,RestaurantData>();

//EF Core
builder.Services.AddDbContext<SamuraiContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SampleEFDb"))
   .EnableSensitiveDataLogging());

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
